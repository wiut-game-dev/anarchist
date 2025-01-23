using Unity.VisualScripting;

using UnityEngine;

public class LookPlayer : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		var player = GameObject.Find("Player");
		// Calculate the direction from the object to the player
		Vector2 direction = (player.transform.position - transform.position).normalized;

		// Calculate the angle using Atan2
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		// Rotate the object to face the player
		transform.rotation = Quaternion.Euler(0, 0, angle+90);
	}
}
