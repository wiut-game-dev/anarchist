using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightEnemyBehaviour : MonoBehaviour
{

    public EnemyVisibility enemyVisibility;
    public EnemyState state;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyVisibility.targetIsVisible)
        {
            FollowThePlayer();
        }
    }

    private void FollowThePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemyVisibility.target.position, state.Speed * Time.deltaTime);
    }
}
