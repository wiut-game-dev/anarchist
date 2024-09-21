using System;
using System.Collections.Generic;

using UnityEngine;

public class PlayerState : ScriptableObject
{
	//that refers to unlocked abilities
	public List<BasicAbilityData> Abilities;
	public List<TempBuffData> Buffs;
	public List<EffectActive> Effects;
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
		foreach(var effect in Effects)
		{
			effect.DurationCurrent -= Time.deltaTime;
			if(effect.DurationCurrent <= 0)
			{
				effect.Times -= 1;
				if(effect.Times <= 0)
				{
					switch(effect.VariableFinal)
					{
						case Variable.Health:
							Health -= effect.ValueFinal;
							break;
						case Variable.Mana:
							Mana -= effect.ValueFinal;
							break;
						case Variable.Attack:
							Attack -= effect.ValueFinal;
							break;
						case Variable.AttackSpeed:
							AttackSpeed -= effect.ValueFinal;
							break;
						case Variable.ManaRecovery:
							ManaRecovery -= effect.ValueFinal;
							break;
						case Variable.Speed:
							Speed -= effect.ValueFinal;
							break;
						case Variable.MaxHealth:
							MaxHealth -= effect.ValueFinal;
							break;
						case Variable.MaxMana:
							MaxMana -= effect.ValueFinal;
							break;
					}
					Effects.Remove(effect);
					continue;
				}
				switch(effect.VariableCurrent)
				{
					case Variable.Health:
						Health -= effect.ValueCurrent;
						break;
					case Variable.Mana:
						Mana -= effect.ValueCurrent;
						break;
					case Variable.Attack:
						Attack -= effect.ValueCurrent;
						break;
					case Variable.AttackSpeed:
						AttackSpeed -= effect.ValueCurrent;
						break;
					case Variable.ManaRecovery:
						ManaRecovery -= effect.ValueCurrent;
						break;
					case Variable.Speed:
						Speed -= effect.ValueCurrent;
						break;
					case Variable.MaxHealth:
						MaxHealth -= effect.ValueCurrent;
						break;
					case Variable.MaxMana:
						MaxMana -= effect.ValueCurrent;
						break;
				}
			}
		}
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
				continue;
			}
			Mana+=Math.Min(ManaRecovery*Time.deltaTime, MaxMana-Mana);
		}
	}
}