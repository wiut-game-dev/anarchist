using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public float maxDuration = 10;
	public float minDuration = 3;
	public float duration = 5;
	public float currentDuration = 0;
	public float minSpawnArea;
	public float maxSpawnArea;
	public WorldState state;
	public GameObject Enemy;
	public Transform CameraPosition;

	private void Start()
	{
		state.EnemiesKilled = 0;
		state.EnemiesAlive = 0;
		state.EnemiesSpawned = 0;
	}

	private void Update()
	{
		if(state.EnemiesSpawned == state.EnemiesLeft)
			return;
		currentDuration += Time.deltaTime;
		if(currentDuration >= duration)
		{
			float x = 0, y = 0;
			if(Random.Range(0, 2) == 0)//out by x
			{
				x = Random.Range(minSpawnArea, maxSpawnArea);
				y = Random.Range(0, maxSpawnArea);
				if(Random.Range(0, 2) == 0)
					x *= -1;
				if(Random.Range(0, 2) == 0)
					y *= -1;
			}
			else//out by y
			{
				x = Random.Range(0, maxSpawnArea);
				y = Random.Range(minSpawnArea, maxSpawnArea);
				if(Random.Range(0, 2) == 0)
					x *= -1;
				if(Random.Range(0, 2) == 0)
					y *= -1;
			}
			Vector3 pos = CameraPosition.position + new Vector3(x, y, 0);
			Instantiate(Enemy, pos, Quaternion.identity);
			state.EnemiesSpawned++;
			state.EnemiesAlive++;
			currentDuration = 0;
			duration = Random.Range(minDuration, maxDuration);
		}
	}
}