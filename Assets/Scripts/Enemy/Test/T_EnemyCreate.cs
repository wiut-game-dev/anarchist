using UnityEngine;

public class T_EnemyCreate : MonoBehaviour
{
	public float duration=5;
	public float currentDuration=0;
	public float minSpawnArea;
	public float maxSpawnArea;
	public GameObject Enemy;
	private void Start()
	{
		
	}

	private void Update()
	{
		currentDuration += Time.deltaTime;
		if (currentDuration >= duration)
		{
			Instantiate(Enemy, new Vector3(Random.Range(minSpawnArea, maxSpawnArea) +transform.position.x, Random.Range(minSpawnArea, maxSpawnArea) +transform.position.y, 0), Quaternion.identity);
			currentDuration = 0;
		}
	}
}