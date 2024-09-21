using System;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Player State")]
public class PlayerState : ScriptableObject
{
	//that refers to unlocked abilities
	public List<BasicAbilityData> Abilities;
	public List<TempBuffData> Buffs;
	public float Health;
	public float MaxHealth;
	public float Mana;
	public float MaxMana;
	public float ManaRecovery;
	public float Attack;
	public float AttackSpeed;
	public float Speed;
	void Start()
	{

	}

	void Update()
	{
		foreach(var buff in Buffs)
		{
			buff.Duration -= Time.deltaTime;
			if(buff.Duration <= 0)
			{
				Buffs.Remove(buff);
				switch(buff.Variable)
				{
					case Variable.Health:
						Health -= buff.Value;
						break;
					case Variable.Mana:
						Mana -= buff.Value;
						break;
					case Variable.Attack:
						Attack -= buff.Value;
						break;
					case Variable.AttackSpeed:
						AttackSpeed -= buff.Value;
						break;
					case Variable.ManaRecovery:
						ManaRecovery -= buff.Value;
						break;
					case Variable.Speed:
						Speed -= buff.Value;
						break;
					case Variable.MaxHealth:
						MaxHealth -= buff.Value;
						break;
					case Variable.MaxMana:
						MaxMana -= buff.Value;
						break;
				}
				break;
			}
			Mana+=Math.Min(ManaRecovery*Time.deltaTime, MaxMana-Mana);
		}
	}
}