
using UnityEngine;

public class KnightEnemyBehaviour : MonoBehaviour
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
