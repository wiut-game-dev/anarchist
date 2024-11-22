using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class PeasantEnemyBehaviour : EnemyBehave
{
	public Rigidbody2D rb;



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

		FindAlly();
		if(state.Activity == EnemyActivity.Idle)
		{
			state.WaitTimeCurrent -= Time.deltaTime;
			if(state.WaitTimeCurrent <= 0)
			{
				state.WaitTimeCurrent = state.WaitTime;
				if(enemyVisibility.targetIsVisible)
				{
					if(enemyVisibility.allyIsHere)
					{
						state.Activity = EnemyActivity.Chasing;
						FollowThePlayer();
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
			Roam();
		}

	}
}
