using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
	public GameObject targetPlayer{ get;private set;}
	public bool allyIsHere = false;
	EnemyState state;

	[Range(0f, 360f)]
	public float angle;

	public bool targetIsVisible = false;

	public void FindAlly()
	{
		var allyEnemy = GameObject.FindGameObjectsWithTag("AllyEnemy");

		for (int i = 0; i < allyEnemy.Length; i++)
		{
			Vector2 position = allyEnemy[i].transform.position - transform.position;
			if (allyEnemy != null && allyEnemy[i] != this.gameObject && position.magnitude <= state.SightDistance)
			{
				allyIsHere = true;
			}
			else
			{
				allyIsHere = false;
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
		//RaycastHit2D hit = Physics2D.Raycast(this.transform.position, targetPlayer.transform.position - this.transform.position, state.SightDistance);
		//print(hit.collider);
		//if(hit.collider.gameObject == targetPlayer)
		//{
		//	targetIsVisible = true;
		//	Debug.DrawLine(transform.position, targetPlayer.transform.position, Color.green);
		//}
		//else
		//{
		//	Debug.DrawLine(transform.position, targetPlayer.transform.position, Color.red);
		//}
	}
}
