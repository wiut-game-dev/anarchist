using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class TestScript : MonoBehaviour
{
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text="FPS: "+(int)(1/Time.deltaTime);
    }
}
