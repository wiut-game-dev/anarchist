using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public PlayerMovement target;

    public float distanceMultiplier;

    void LateUpdate()
    {
        Vector3 targetPosition = target.transform.position;

        targetPosition.z = transform.position.z;

        targetPosition += target.transform.up * distanceMultiplier; 

        transform.position = targetPosition;
    }
}
