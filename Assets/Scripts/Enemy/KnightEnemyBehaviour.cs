using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightEnemyBehaviour : MonoBehaviour
{

    public EnemyVisibility enemyVisibility;
    public EnemyBehave behave;
    public EnemyState state;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, enemyVisibility.targetPlayer.transform.position);
        if (enemyVisibility.targetIsVisible)
        {
            behave.FollowThePlayer();
        }
    }
}
