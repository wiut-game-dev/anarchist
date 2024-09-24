using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehaviour : MonoBehaviour
{
    public TestState state;

    void Start()
    {
        Print();
    }

    void Print()
    {
        int sum = state.n + 1;
        Debug.Log(sum);
    }
}
