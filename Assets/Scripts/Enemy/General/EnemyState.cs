using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class EnemyState : MonoBehaviour
{
	public bool LineOfSight;
	public float Health;
	public float MaxHealth;
	public float Cooldown;
	public float Damage;
	public float AttackSpeed;
	public float AttackRange;
	public float Multiplier;
	public float Speed;
	public float SightDistance;
	public List<EffectActive> Effects;
	public Vector2 moveDirection;



	void Start()
	{

	}

	void Update()
	{
		if(Health <= 0)
		{
			Destroy(gameObject);
		}
	}

	public bool AddEffect(Effect effect)
	{
		var comp = new EffectEqualityComparer();

		var ex = Effects.Find(x => comp.Equals(x, effect));
		if(ex != null)
		{
			ex.Times = effect.Times;
			ex.DurationCurrent = 0;
			return false;
		}
		else
		{
			Effects.Add(new EffectActive(effect));
			return true;
		}
	}
}
