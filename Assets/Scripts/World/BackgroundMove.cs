using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
	public GameObject Player;
	public WorldState world;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		float x = transform.position.x, y = transform.position.y;
		world.LeftX = x - world.StepX;
		world.RightX = x + world.StepX;
		world.BottomY = y - world.StepY;
		world.TopY = y + world.StepY;
	}

	// Update is called once per frame
	void Update()
	{
		//transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, 10);
		//return; //that is the code to grant player magical power
		float x = Player.transform.position.x, y = Player.transform.position.y;
		if(x < world.LeftX)
		{
			world.LeftX -= world.StepX;
			world.RightX -= world.StepX;
			transform.position += new Vector3(-world.StepX, 0, 0);
		}
		else if(x > world.RightX)
		{
			world.LeftX += world.StepX;
			world.RightX += world.StepX;
			transform.position += new Vector3(world.StepX, 0, 0);
		}
		if(y < world.BottomY)
		{
			world.BottomY -= world.StepY;
			world.TopY -= world.StepY;
			transform.position += new Vector3(0, -world.StepY, 0);
		}
		else if(y > world.TopY)
		{
			world.BottomY += world.StepY;
			world.TopY += world.StepY;
			transform.position += new Vector3(0, world.StepY, 0);
		}
	}
}
