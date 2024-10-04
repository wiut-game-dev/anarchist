using UnityEngine;

public class T_EnemyCreate : MonoBehaviour
{
	public float duration=5;
	public float currentDuration=0;
	public GameObject Enemy;
	private void Start()
	{
		
	}

	private void Update()
	{
		currentDuration += Time.deltaTime;
		if (currentDuration >= duration)
		{
			Instantiate(Enemy, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)), Quaternion.identity);
			currentDuration = 0;
		}
	}
}