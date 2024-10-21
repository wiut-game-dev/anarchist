using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelArtLoad : MonoBehaviour {


    private void Start() {
        Texture2D texture2D = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        texture2D.filterMode = FilterMode.Point;

        byte[] byteArray = System.IO.File.ReadAllBytes(Application.dataPath + "/DrawPixels/pixelArt.png");
        texture2D.LoadImage(byteArray);

        GetComponent<MeshRenderer>().material.mainTexture = texture2D;
    }

}