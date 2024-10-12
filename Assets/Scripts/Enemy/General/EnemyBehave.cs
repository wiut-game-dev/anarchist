using UnityEngine;

using Random = UnityEngine.Random;

public class EnemyBehave : MonoBehaviour
{
	public EnemyState state;
	private GameObject[] allyEnemy;
	public bool allyIsHere = false;
	public float RoamDuration;
	public float RoamCurrentDuration;
	public EnemyVisibility enemyVisibility;
	public GameObject itself;


	public void FollowThePlayer()
	{
		transform.position = Vector2.MoveTowards(this.transform.position, enemyVisibility.targetPlayer.transform.position, state.Speed * Time.deltaTime);
		Vector2 direction = (enemyVisibility.targetPlayer.transform.position - transform.position).normalized;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler(angle * Vector3.forward);

	}

	public void FindAlly()
	{
		allyEnemy = GameObject.FindGameObjectsWithTag("AllyEnemy");

		for(int i = 0; i < allyEnemy.Length; i++)
		{
			Vector2 position = allyEnemy[i].transform.position;
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

	public void Update()
	{
		if(state.Activity == EnemyActivity.Idle)
		{
			state.WaitTimeCurrent -= Time.deltaTime;
			if(state.WaitTimeCurrent <= 0)
			{
				state.Activity = EnemyActivity.Roaming;
				Roam();
			}
		}
	}

	public void Roam()
	{
		Debug.Log("ROAM");
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
		state.Activity = EnemyActivity.Roaming;
	}
}
