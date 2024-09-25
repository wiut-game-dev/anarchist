using UnityEngine;

public class T_HitBoxLive : MonoBehaviour
{
	public float lifetime=0.5f;
	// Start is called before the first frame update
	void Start()
	{

	}

	void OnTriggerEnter()
	{
		Debug.Log("Touch!");
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