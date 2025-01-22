using UnityEngine;

using Random = UnityEngine.Random;

public class EnemyBehave : MonoBehaviour
{
	public EnemyState state;
	public EnemyVisibility enemyVisibility;
	public PlayerState playerState;
	public Vector3 Direction;

	public virtual void Update()
	{
		
	}


	public virtual void FollowThePlayer()
	{
		transform.position = Vector2.MoveTowards(transform.position, enemyVisibility.targetPlayer.transform.position, state.Speed * Time.deltaTime);
		Direction = (enemyVisibility.targetPlayer.transform.position - transform.position).normalized;
	}


	public void GetRoamPosition()
	{
		state.Activity = EnemyActivity.Roaming;
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
		Direction = new Vector3(x, y, 0);
	}

	public void Roam()
	{
		var direction = Direction.normalized*Time.deltaTime*state.Speed;
		transform.position += direction;
		Direction -= direction;
		direction = direction.normalized;
		if(Direction.magnitude < 1f)
		{
			state.Activity = EnemyActivity.Idle;
			direction= Vector3.zero;
		}
	}


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
		if(state.Activity == EnemyActivity.Attacking)
		{
			if(!(other is null) && other.gameObject.tag == "PLAYER")
			{
				playerState.Health -= state.Attack;
			}
		}
	}
}
