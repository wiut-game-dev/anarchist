using UnityEngine;

public class EnemyVisibility : MonoBehaviour
{
	public GameObject targetPlayer;
	EnemyState state;
	KnightEnemyBehaviour knight;

	[Range(0f, 360f)]
	public float angle;

	public bool targetIsVisible = false;

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
