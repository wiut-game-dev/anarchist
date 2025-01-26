using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
	public GameObject Player;
	public WorldState world;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float x = Player.transform.position.x, y = Player.transform.position.y;
		while(x > world.BorderCurrentX)
		{
			world.BorderCurrentX += world.BorderX;
		}
		while(x < -world.BorderCurrentX)
		{
			world.BorderCurrentX -= world.BorderX;
		}
		while(y > world.BorderCurrentY)
		{
			world.BorderCurrentY += world.BorderY;
		}
		while(y < -world.BorderCurrentY)
		{
			world.BorderCurrentY -= world.BorderY;
		}
	}
}
