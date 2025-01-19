using UnityEngine;

public class T_EnemyCreate : MonoBehaviour
{
	public float duration=5;
	public float currentDuration=0;
	public float minSpawnArea;
	public float maxSpawnArea;
	public GameObject Enemy;
	public Transform CameraPosition;

	private void Start()
	{
		
	}

	private void Update()
	{
		currentDuration += Time.deltaTime;
		if (currentDuration >= duration)
		{
			Instantiate(Enemy, new Vector3(Random.Range(Random.Range(-maxSpawnArea, -minSpawnArea), Random.Range(minSpawnArea, maxSpawnArea)) +CameraPosition.position.x, Random.Range(Random.Range(-maxSpawnArea, -minSpawnArea), Random.Range(minSpawnArea, maxSpawnArea)) + CameraPosition.position.y, 0), Quaternion.identity);
			currentDuration = 0;
		}
	}
}