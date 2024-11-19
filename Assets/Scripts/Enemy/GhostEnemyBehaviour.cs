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

	}

	// Update is called once per frame
	void Update()
	{
		switch (state.Activity)
		{
			case EnemyActivity.Idle:
				behave.Idle();
				break;
			case EnemyActivity.Roaming:
				behave.GetRoamPosition();
				break;
			case EnemyActivity.Chasing:
				behave.FollowThePlayer();
				break;
		}
	}
}
