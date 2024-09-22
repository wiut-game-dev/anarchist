using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PeasantEnemyBehaviour : MonoBehaviour
{
    public EnemyState state;
    public Rigidbody2D rb;
    public Transform playerTarget;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget)
        {
            Vector2 direction = (playerTarget.position - transform.position).normalized;
            state.moveDirection = direction;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.position = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        }
    }

    private void FixedUpdate()
    {
        if (playerTarget)
        {
            rb.velocity = new Vector2(state.moveDirection.x, state.moveDirection.y) * state.Speed; //some sort of error fix tomorrow
        }
    }
}
