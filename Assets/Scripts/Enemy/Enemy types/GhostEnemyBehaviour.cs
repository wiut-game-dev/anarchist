using UnityEngine;

public class GhostEnemyBehaviour : EnemyBehaviour
{

    public Rigidbody2D rb;


    public override void FollowThePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemyVisibility.targetPlayer.transform.position, state.Speed * 10 * Time.deltaTime);
        Vector2 direction = (enemyVisibility.targetPlayer.transform.position - transform.position).normalized;
    }
    public override void OnTriggerStay2D(Collider2D other)
    {
        base.OnTriggerStay2D(other);
        if (other.gameObject.tag == "PLAYER")
            AttackQuit();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (state.Activity == EnemyActivity.Idle)
        {
            state.WaitTimeCurrent -= Time.deltaTime;
            if (state.WaitTimeCurrent <= 0)
            {
                state.WaitTimeCurrent = state.WaitTime;
                if (enemyVisibility.targetIsVisible)
                {
                    AttackEnter();
                }
                else
                {
                    state.Activity = EnemyActivity.Roaming;
                    GetRoamPosition();

                }
            }
        }
        else if (state.Activity == EnemyActivity.Roaming)
        {
            Roam();
        }
        else if (state.Activity == EnemyActivity.Attacking)
        {
            FollowThePlayer();
        }
    }
}
