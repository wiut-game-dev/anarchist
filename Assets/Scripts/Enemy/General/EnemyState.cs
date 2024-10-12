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
	public EnemyActivity EnemyActivity;
	public float Multiplier;
	public float Speed;
	public float SightDistance;
	public List<EffectActive> Effects;
	public Vector3 moveDirection;
	public float MinArea;
	public float MaxArea;
	public EnemyActivity Activity;
	public float WaitTimeCurrent;
	public float WaitTime = 5;
	void Start()
	{

	}

	void Update()
	{
		if(Health <= 0)
		{
			Destroy(gameObject);
		}
		if(Activity == EnemyActivity.Roaming)
		{
			gameObject.transform.position += moveDirection * Time.deltaTime *Speed*0.1f;
			moveDirection *= (1 - Time.deltaTime*0.1f*Speed);
			if(moveDirection.magnitude<1f)
			{
				Activity = EnemyActivity.Idle;
				WaitTimeCurrent = WaitTime;
				Debug.Log("STOP ROAM");
			}
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
	Idle = -1,
	Roaming = 0,
	Patorlling = 1,
	Chasing = 2,
	Attacking = 3,
	Searching = 4,
	Escaping = 5
}
