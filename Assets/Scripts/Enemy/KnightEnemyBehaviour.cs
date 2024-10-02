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
        float distToPlayer = Vector2.Distance(transform.position, enemyVisibility.targetPlayer.transform.position);
        if (enemyVisibility.targetIsVisible)
        {
            FollowThePlayer();
        }
    }

    private void FollowThePlayer()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, enemyVisibility.targetPlayer.transform.position, state.Speed * Time.deltaTime);
        Vector2 direction = (enemyVisibility.targetPlayer.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(angle * Vector3.forward);

    }

    private void StopFollowingThePlayer()
    {

    }
}
