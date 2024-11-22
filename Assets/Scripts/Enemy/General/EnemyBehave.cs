using UnityEngine;

using Random = UnityEngine.Random;

public class EnemyBehave : MonoBehaviour
{
	public EnemyState state;
	private GameObject[] allyEnemy;
	public bool allyIsHere = false;
	public EnemyVisibility enemyVisibility;
	public PlayerState playerState;


	public virtual void FollowThePlayer()
	{
		transform.position = Vector2.MoveTowards(this.transform.position, enemyVisibility.targetPlayer.transform.position, state.Speed * Time.deltaTime);
		Vector2 direction = (enemyVisibility.targetPlayer.transform.position - transform.position).normalized;
		/*float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(angle * Vector3.forward);*/

	}

	public void FindAlly()
	{
		allyEnemy = GameObject.FindGameObjectsWithTag("AllyEnemy");

		for(int i = 0; i < allyEnemy.Length; i++)
		{
			Vector2 position = allyEnemy[i].transform.position - transform.position;
			if(allyEnemy != null && allyEnemy[i] != this.gameObject && position.magnitude <= state.SightDistance)
			{
				allyIsHere = true;
			}
			else
			{
				allyIsHere = false;
			}
		}
	}

	public virtual void Update()
	{
	}

	public void GetRoamPosition()
	{
		//Debug.Log("ROAM");
		state.Activity= EnemyActivity.Roaming;
		float x = Random.Range(state.MinArea, state.MaxArea);
		float y = Random.Range(state.MinArea, state.MaxArea);
		if(Random.Range(0, 2) == 0)
		{
			x *= -1;

		}
		if(Random.Range(0, 2) == 0)
		{
			y *= -1;
		}
		state.moveDirection = new Vector3(x, y, 0);
	}

	public void Roam() {
		gameObject.transform.position += state.moveDirection * Time.deltaTime * state.Speed * 0.1f;
		state.moveDirection *= (1 - Time.deltaTime * 0.1f * state.Speed);
		if (state.moveDirection.magnitude < 1f)
		{	
			state.Activity = EnemyActivity.Idle;
			//Debug.Log("STOP ROAM");
		}
	}

	//public void Idle()
	//{
	//	if (enemyVisibility.targetIsVisible)
	//	{
	//		state.Activity = EnemyActivity.Chasing;
	//	}
	//	else
	//	{
	//		state.WaitTimeCurrent -= Time.deltaTime;
	//		if (state.WaitTimeCurrent <= 0)
	//		{
	//			state.Activity = EnemyActivity.Roaming;
	//		}
	//	}
	//}

	public void AttackEnter()
	{
		state.Activity = EnemyActivity.Attacking;
		state.Collider.size = state.Collider.size.normalized * state.AttackRange;
	}

	public void AttackQuit()
	{
		state.Activity = EnemyActivity.Idle;
		state.Collider.size = state.Collider.size.normalized * state.IdleSize;
	}
	public virtual void OnTriggerStay2D(Collider2D other)
	{
		if (state.Activity == EnemyActivity.Attacking)
		{
			if (!(other is null) && other.gameObject.tag == "PLAYER")
			{
				playerState.Health -= state.Attack;
			}
		}
	}
}
