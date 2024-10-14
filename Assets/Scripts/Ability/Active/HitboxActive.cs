using System;

using UnityEngine;

public class HitboxActive : MonoBehaviour
{
	public SpellData Spell;
	public GameObject Player { get; private set; }
	private Vector3 Direction;
	void Start()
	{
		Player = GameObject.Find("Player");
		var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var playerPos = Player.transform.position;
		Direction = (mouse - playerPos).normalized;
		gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, Direction);
		//replace texture from Spell.ImagePath and sound from Spell.SoundPath
		if(Spell.HitBox.Type == HitBoxType.Circle)
		{
			gameObject.transform.localScale = new Vector3(Spell.HitBox.Radius_or_Height, Spell.HitBox.Radius_or_Height, 1);
		}
		else if(Spell.HitBox.Type == HitBoxType.Rectangle)
		{
			gameObject.transform.localScale = new Vector3(Spell.HitBox.Width, Spell.HitBox.Radius_or_Height, 1);
		}
	}
	void Update()
	{
		if(Spell.TravelDistance > 0)
		{
			var move = Direction * Time.deltaTime * Spell.Speed;
			if(Spell.TrackMouse)
			{
				move = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - Player.transform.position).normalized * Time.deltaTime * Spell.Speed;
			}
			Spell.TravelDistance -= move.magnitude;
			gameObject.transform.position += move;
		}
		else
		{
			Spell.Lifetime -= Time.deltaTime;
			if(Spell.Lifetime <= 0)
				Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		try
		{
			var state = other.gameObject.GetComponent<EnemyState>();
			state.Health -= Spell.Damage;
			Debug.Log(state.AddEffect(Spell.Effect) + " " + other.tag);
		}
		catch
		{
			//Debug.Log("PROBABLY_NOT_ENEMY");
		}
	}
}