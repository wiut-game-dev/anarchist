using System;
using System.Collections.Generic;

using UnityEngine;
public struct AbilityIndex
{
	public int List;
	public int Index;
}
[CreateAssetMenu(menuName = "Player State")]
public class PlayerState : ScriptableObject
{
	public GameObject HitBoxCircle;
	public GameObject HitBoxSquare;

	public CostCompute coster;

	//these two refer to unlocked abilities
	public List<AbilityIndex> UnlockedAbilities = new();
	public AbilityIndex ActiveAbility;
	public List<SpellData> SpellAbilities = new();
	public List<BuffData> BuffAbilities = new();
	public List<TempBuffData> TempBuffAbilities = new();
	public List<EffectActive> Effects = new();
	public float Health;
	public float MaxHealth;
	public float Mana;
	public float MaxMana;
	public float ManaRecovery;
	public float Attack;
	public float AttackSpeed;
	public float Speed;

	public void AddAbility(SpellData spell)
	{
		UnlockedAbilities.Add(new AbilityIndex { List = 0, Index = SpellAbilities.Count });
		SpellAbilities.Add(spell);
	}

	public void AddAbility(BuffData spell)
	{
		UnlockedAbilities.Add(new AbilityIndex { List = 1, Index = BuffAbilities.Count });
		BuffAbilities.Add(spell);
	}

	public void AddAbility(TempBuffData spell)
	{
		UnlockedAbilities.Add(new AbilityIndex { List = 2, Index = TempBuffAbilities.Count });
		TempBuffAbilities.Add(spell);
	}

	public void Update()
	{

		if(Mana < MaxMana)
			Mana += Math.Min(ManaRecovery * Time.deltaTime, MaxMana - Mana);
		else
			Mana += ManaRecovery * Time.deltaTime * 0.1f;
		//you can basically copy this part for enemies
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
		//yep, above one (but removing stuff like mana and maxhealth)
		foreach(var buff in TempBuffAbilities)
		{
			buff.Duration -= Time.deltaTime;
			if(buff.Duration <= 0)
			{
				TempBuffAbilities.Remove(buff);
				switch(buff.Variable)
				{
					case Variable.Health:
						Health -= buff.Value;
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
			}
		}
	}
}