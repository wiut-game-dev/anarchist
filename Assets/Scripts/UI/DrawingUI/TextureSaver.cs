using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Saves the RenderTexture as a PNG file to the https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html
/// </summary>
public class TextureSaver : MonoBehaviour
{
    /// <summary>
    /// We will save the image from this RenderTexture. This means that even if we introduce Layers system we can render everything that 
    /// was painted onto the canvas. Alternatively we could pass a Texture2D[] array of all the layers to use (I'm not planning to implement layers)
    /// </summary>
    [SerializeField]
    private RenderTexture m_renderTexture;

    // Delegate for the save event
    public delegate void SaveCompletedEventHandler(string filePath);
    // Event that will be triggered when save is completed
    public event SaveCompletedEventHandler OnSaveCompleted;

    public void SaveTextureAsPNG()
    {
        StartCoroutine(SaveTextureAsPNGCoroutine());
    }

    /// <summary>
    /// Saves the image to PNG giving it a name as date and time.
    /// </summary>
    /// <returns></returns>
    private System.Collections.IEnumerator SaveTextureAsPNGCoroutine()
    {
        // Wait for the end of frame to ensure all rendering is done
        yield return new WaitForEndOfFrame();

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = m_renderTexture;

        Texture2D tex = new Texture2D(m_renderTexture.width, m_renderTexture.height, TextureFormat.RGBA32, false);
        tex.ReadPixels(new Rect(0, 0, m_renderTexture.width, m_renderTexture.height), 0, 0);
        tex.Apply();

        RenderTexture.active = currentRT;

        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);

        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = $"DrawingCapture_{timestamp}.png";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        File.WriteAllBytes(filePath, bytes);

        Debug.Log($"Saved PNG to: {filePath}");

        // Trigger the event with the file path
        OnSaveCompleted?.Invoke(filePath);
        Debug.Log($"PNG saved at {filePath}");
    }
}
