using UnityEngine;

public class FollowSword : MonoBehaviour
{
	public GameObject Sword;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		try{
		transform.position = Sword.transform.position+Vector3.left;
		}
		catch
		{
			Destroy(gameObject);
		}
	}
}
