using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GhostEnemyBehaviour : MonoBehaviour
{

	public EnemyVisibility enemyVisibility;
	public EnemyBehave behave;
	public EnemyState state;
	public Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
	{
		state.Health = 50;
		state.MinArea = 5;
		state.MaxArea = 10;
		state.Speed = 50;
		state.Attack = 20;
		state.AttackSpeed = 1;
		state.SightDistance = 20;
		state.Activity = EnemyActivity.Idle;
		state.WaitTime = 2;
		state.WaitTimeCurrent = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if(state.Activity == EnemyActivity.Idle)
		{
			state.WaitTimeCurrent -= Time.deltaTime;
			if(state.WaitTimeCurrent <= 0)
			{
				state.Activity = EnemyActivity.Roaming;
				behave.Roam();
			}
		}
		if(enemyVisibility.targetIsVisible)
		{
			behave.FollowThePlayer();
		}
	}
}
