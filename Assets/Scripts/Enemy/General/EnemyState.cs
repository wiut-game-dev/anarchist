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
	public List<EffectActive> EffectOnEnemies;
	public Vector2 moveDirection;

	

	void Start()
	{
		
	}

	void Update()
	{
		if (Health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
