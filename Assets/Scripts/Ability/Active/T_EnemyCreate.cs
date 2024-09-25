using UnityEngine;

public class T_EnemyCreate : MonoBehaviour
{
	public float duration;
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
			Instantiate(Enemy, new Vector3(0, 0, 0), Quaternion.identity);
			currentDuration = 0;
		}
	}
}