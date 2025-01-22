using UnityEngine;

public class T_HitBoxLive : MonoBehaviour
{
	public float lifetime=0.5f;
	public float damage = 50;

	void OnTriggerEnter2D(Collider2D other)
	{
		try
		{
			var state = other.gameObject.GetComponent<EnemyState>();
			state.Health -= damage;
		}
		catch
		{

		}
	}
	// Update is called once per frame
	void Update()
	{
		lifetime -=Time.deltaTime;
		if(lifetime <= 0)
		{
			Destroy(gameObject);
		}
	}
}