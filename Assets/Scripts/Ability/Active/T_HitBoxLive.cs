using UnityEngine;

public class T_HitBoxLive : MonoBehaviour
{
	public float lifetime=0.5f;
	// Start is called before the first frame update
	void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name != "Player")
		{
			Destroy(other.gameObject);
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