using UnityEngine;

public class HitboxActive : MonoBehaviour
{
	public SpellData Spell;
	void Start()
	{
		//rotate hitbox in the direction of the mouse
		//detect where mouse looks and travel this distance
		//replace texture from Spell.ImagePath and sound from Spell.SoundPath
		if(Spell.HitBox.Type == HitBoxType.Circle)
		{
			gameObject.transform.localScale = new Vector3(Spell.HitBox.Radius_or_Height, Spell.HitBox.Radius_or_Height, 1);
		}else if(Spell.HitBox.Type == HitBoxType.Rectangle)
		{
			gameObject.transform.localScale= new Vector3(Spell.HitBox.Width, Spell.HitBox.Radius_or_Height, 1);
		}
	}

	void Update()
	{
		Spell.Lifetime -= Time.deltaTime;
		if(Spell.Lifetime <= 0)
			Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		try
		{
			var state = other.gameObject.GetComponent<EnemyState>();
			state.Health -= Spell.Damage;
			state.AddEffect(Spell.Effect);
		}
		catch
		{
			Debug.Log("NOT_ENEMY");
		}
	}
}