using System.Collections.Generic;

using UnityEngine;


public class EnemyState : MonoBehaviour
{
	public bool LineOfSight; //what is this?
	public float Health;
	public float MaxHealth;
	public float Cooldown;
	public float Attack;
	public float AttackSpeed;
	public float AttackRange;
	public EnemyActivity EnemyActivity;
	public float Multiplier;
	public float Speed;
	public float SightDistance;
	public List<EffectActive> Effects = new();
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
		CheckEffects();
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
				//Debug.Log("STOP ROAM");
			}
		}
	}

	void CheckEffects()
	{
		List<int> toremove = new(); // <--->
		foreach(var effect in Effects)
		{
			effect.DurationCurrent -= Time.deltaTime;
			if(effect.DurationCurrent <= 0)
			{
				effect.Times -= 1;
				effect.DurationCurrent = effect.Duration;
				if(effect.Times <= 0)
				{
					switch(effect.VariableFinal)
					{
						case Variable.Health:
							Health -= effect.ValueFinal;
							break;
						case Variable.Attack:
							Attack -= effect.ValueFinal;
							break;
						case Variable.AttackSpeed:
							AttackSpeed -= effect.ValueFinal;
							break;
						case Variable.Speed:
							Speed -= effect.ValueFinal;
							break;
					}
					toremove.Add(Effects.IndexOf(effect));
				}
				switch(effect.VariableCurrent)
				{
					case Variable.Health:
						Health -= effect.ValueCurrent;
						break;
					case Variable.Attack:
						Attack -= effect.ValueCurrent;
						break;
					case Variable.AttackSpeed:
						AttackSpeed -= effect.ValueCurrent;
						break;
					case Variable.Speed:
						Speed -= effect.ValueCurrent;
						break;
				}
			}
		}
		for(int i=toremove.Count-1; i>=0; i--)
		{
			Effects.RemoveAt(toremove[i]);
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
