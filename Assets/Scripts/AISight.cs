using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISight : MonoBehaviour
{
    public float distance;
    public float angle;
    public LayerMask objectsLayers;
    public LayerMask obstacleLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, objectsLayers);

        for (int i = 0; i < colliders.Length; i++)
        {
            Collider col = colliders[i];
            Vector3 directionToController = Vector3.Normalize(col.bounds.center - transform.position); //Maybe use another method more applicable to 2d instead of 3d
        }

    }
}
