using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public PlayerState state;
	private Rigidbody2D rb;
	public Vector2 movement;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
	}
	void FixedUpdate()
	{
		movement.Normalize();
		rb.velocity = new Vector2(movement.x * state.Speed * Time.fixedDeltaTime, movement.y * state.Speed * Time.fixedDeltaTime);
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log("AAAAAAA");
	}


}
