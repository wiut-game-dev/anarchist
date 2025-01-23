using System;

using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
	public GameObject targetPlayer { get; set; }
	public bool allyIsHere = false;
	EnemyState state;

	public bool targetIsVisible = false;

	public void FindAlly()
	{
		var allyEnemy = GameObject.FindGameObjectsWithTag("AllyEnemy");
		allyIsHere = false;
		for(int i = 0; i < allyEnemy.Length; i++)
		{
			Vector2 position = allyEnemy[i].transform.position - transform.position;
			if(allyEnemy != null && allyEnemy[i] != this.gameObject && position.magnitude <= state.SightDistance)
			{
				allyIsHere = true;
			}
		}
	}

	void Start()
	{
		state = GetComponent<EnemyState>();
		targetPlayer = GameObject.Find("Player");
	}

	void Update()
	{
		CheckSight();
	}


	public void CheckSight()
	{
		var direction = targetPlayer.transform.position - transform.position;
		var distance = direction.magnitude;
		if(distance < state.SightDistance)
		{
			targetIsVisible = true;
		}
		else
		{
			targetIsVisible = false;
		}
	}
}
