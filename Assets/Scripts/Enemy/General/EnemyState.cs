using System.Collections.Generic;

using UnityEngine;


public class EnemyState : MonoBehaviour
{
	public bool LineOfSight; //what is this?
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
	public float MinArea;
	public float MaxArea;
	public EnemyActivity Activity;
	public float WaitTime;

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

	private void FixedUpdate()
	{
		
	}

	public bool AddEffect(Effect effect)
	{
		var comp = new EffectEqualityComparer();

		var exEff = Effects.Find(x => comp.Equals(x, effect));
		if(exEff != null)
		{
			exEff.Times = effect.Times;
			exEff.DurationCurrent = 0;
			return false;
		}
		else
		{
			Effects.Add(new EffectActive(effect));
			return true;
		}
	}
}

public enum EnemyActivity
{
	Roaming = 0,
	Patorlling = 1,
	Chasing = 2,
	Attacking = 3,
	Searching = 4,
	Escaping = 5
}
