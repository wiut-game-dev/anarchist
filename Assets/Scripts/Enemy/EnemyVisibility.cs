using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyVisibility : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 10f;

    [Range(0f, 360f)]
    public float angle;

    public bool targetIsVisible { get; private set; }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        targetIsVisible = CheckVisibility();
    }

    /*public bool CheckVisibilityToPoint(Vector3 worldPoint)
    {
        var directionToTarget = worldPoint - transform.position;

        var degreesToTarget = Vector2.Angle(transform.forward, directionToTarget);

        var withinArc = degreesToTarget < (angle/2);

        if (withinArc == false)
        {
            return false;
        }

        var distanceToTarget = directionToTarget.magnitude;
        var rayDistance = Mathf.Min(maxDistance, distanceToTarget);

        var ray = new Ray(transform.position, directionToTarget);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            if(hit.collider.transform == target)
            {
                return true;
            }
            return false;
        }
        else
        {
            return true;
        }
    }*/

    public bool CheckVisibility()
    {
        var directionToTarget = target.position - transform.position;

        var degreesToTarget =  Vector2.Angle(transform.forward, directionToTarget);

        var withinArc = degreesToTarget < (angle/2);

        if (withinArc == false)
        {
            return false;
        }
        
        var distanceToTarget = directionToTarget.magnitude;

        var rayDistance = Mathf.Min(maxDistance, distanceToTarget);

        var ray = new Ray(transform.position, directionToTarget);

        RaycastHit hit;

        var canSee = false;

        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            if(hit.collider.transform == target)
            {
                canSee = true;
            }
            Debug.DrawLine(transform.position, hit.point);

        }
        else
        {
            Debug.DrawLine(transform.position, directionToTarget.normalized * rayDistance);
        }
        return canSee;
    }
}
