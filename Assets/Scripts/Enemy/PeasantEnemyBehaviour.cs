using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class PeasantEnemyBehaviour : MonoBehaviour
{
	public EnemyState state;
	public EnemyVisibility enemyVisibility;
	public EnemyBehave behave;
	public Rigidbody2D rb;



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

		behave.FindAlly();
		if(state.Activity == EnemyActivity.Idle)
		{
			if(enemyVisibility.targetIsVisible)
			{
				if(behave.allyIsHere)
				{
					behave.FollowThePlayer();
				}
			}
			else
			{
				state.WaitTimeCurrent -= Time.deltaTime;
				if(state.WaitTimeCurrent <= 0)
				{
					state.Activity = EnemyActivity.Roaming;
					behave.GetRoamPosition();
				}
			} 
		}

	}

	private void FixedUpdate()
	{

	}






}
