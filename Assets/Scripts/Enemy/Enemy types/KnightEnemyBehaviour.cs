
using UnityEngine;

public class KnightEnemyBehaviour : EnemyBehave
{

	public Rigidbody2D rb;


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
					state.Activity = EnemyActivity.Chasing;
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

	}
}
