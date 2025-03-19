using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public void Transition(int num)
    {
        SceneManager.LoadScene(num);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
