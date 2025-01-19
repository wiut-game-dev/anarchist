using UnityEngine;

public class PeasantEnemyBehaviour : EnemyBehave
{
    public Rigidbody2D rb;
    public Animator Movements;


    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {

        enemyVisibility.FindAlly();
        if (state.Activity == EnemyActivity.Idle)
        {
            state.WaitTimeCurrent -= Time.deltaTime;
            if (state.WaitTimeCurrent <= 0)
            {
                state.WaitTimeCurrent = state.WaitTime;
                if (enemyVisibility.targetIsVisible)
                {
                    if (enemyVisibility.allyIsHere)
                    {
                        state.Activity = EnemyActivity.Chasing;
                    }
                    else
                    {
                        state.Activity = EnemyActivity.Idle;
                    }
                }
                else
                {
                    GetRoamPosition();
                }
            }
        }
        else if (state.Activity == EnemyActivity.Roaming)
        {
            if (enemyVisibility.targetIsVisible)
            {
                state.Activity = EnemyActivity.Idle;
                state.WaitTimeCurrent = 0;
            }
            Roam();
        }
        else if (state.Activity == EnemyActivity.Chasing)
        {
            if (enemyVisibility.targetIsVisible)
            {
                FollowThePlayer();
            }
            else
            {
                state.Activity = EnemyActivity.Idle;
            }
        }

        Movements.SetFloat("Horizontal", direction.x);
        Movements.SetFloat("Vertical", direction.y);
        Movements.SetFloat("Speed", transform.position.sqrMagnitude);
    }
}
