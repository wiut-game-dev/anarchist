using UnityEngine;

public class T_EnemyCreate : MonoBehaviour
{
	public float duration = 5;
	public float currentDuration = 0;
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
		if(currentDuration >= duration)
		{
			float x=0, y=0;
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
			currentDuration = 0;
		}
	}
}