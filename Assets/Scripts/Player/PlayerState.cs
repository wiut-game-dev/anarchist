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

	//these two refer to unlocked abilities
	public List<AbilityIndex> UnlockedAbilities;
	public AbilityIndex ActiveAbility;
	public List<SpellData> SpellAbilities;
	public List<BuffData> BuffAbilities;
	public List<TempBuffData> TempBuffAbilities;
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

	public void AddAbility(SpellData spell)
	{
		UnlockedAbilities.Add(new AbilityIndex{List = 0, Index = SpellAbilities.Count});
		SpellAbilities.Add(spell);
	}

	public void AddAbility(BuffData spell)
	{
		UnlockedAbilities.Add(new AbilityIndex{List = 1, Index = BuffAbilities.Count});
		BuffAbilities.Add(spell);
	}

	public void AddAbility(TempBuffData spell)
	{
		UnlockedAbilities.Add(new AbilityIndex{List = 2, Index = TempBuffAbilities.Count});
		TempBuffAbilities.Add(spell);
	}

	void CheckAbilities()
	{
		if(Input.GetButtonDown("Q") && UnlockedAbilities.Count > 0)
		{
			ActiveAbility = UnlockedAbilities[0];
		}
		if(Input.GetButtonDown("E") && UnlockedAbilities.Count > 1)
		{
			ActiveAbility = UnlockedAbilities[1];
		}
		if(Input.GetButtonDown("R") && UnlockedAbilities.Count > 2)
		{
			ActiveAbility = UnlockedAbilities[2];
		}
		if(Input.GetButtonDown("F") && UnlockedAbilities.Count > 3)
		{
			ActiveAbility = UnlockedAbilities[3];
		}
		if(Input.GetButtonDown("C") && UnlockedAbilities.Count > 4)
		{
			ActiveAbility = UnlockedAbilities[4];
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(ActiveAbility.List == 0)
			{
				var spell = SpellAbilities[ActiveAbility.Index];
				if(spell.HitBox.Type == HitBoxType.Circle)
				{
					var circle = Instantiate(HitBoxCircle, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
					circle.GetComponent<HitboxActive>().Spell = spell;
				}
				else if(spell.HitBox.Type == HitBoxType.Rectangle)
				{
					var square = Instantiate(HitBoxSquare, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
					square.GetComponent<HitboxActive>().Spell = spell;
				}
			}
			else if(ActiveAbility.List == 1)
			{
				var spell = BuffAbilities[ActiveAbility.Index];
				switch(spell.Variable)
				{
					case Variable.Health:
						Health += spell.Value;
						break;
					case Variable.Attack:
						Attack += spell.Value;
						break;
					case Variable.AttackSpeed:
						AttackSpeed += spell.Value;
						break;
					case Variable.ManaRecovery:
						ManaRecovery += spell.Value;
						break;
					case Variable.Speed:
						Speed += spell.Value;
						break;
					case Variable.MaxHealth:
						MaxHealth += spell.Value;
						break;
					case Variable.MaxMana:
						MaxMana += spell.Value;
						break;
				}
			}
			else if(ActiveAbility.List == 2)
			{
				var spell = TempBuffAbilities[ActiveAbility.Index];
				switch(spell.Variable)
				{
					case Variable.Health:
						Health += spell.Value;
						break;
					case Variable.Attack:
						Attack += spell.Value;
						break;
					case Variable.AttackSpeed:
						AttackSpeed += spell.Value;
						break;
					case Variable.ManaRecovery:
						ManaRecovery += spell.Value;
						break;
					case Variable.Speed:
						Speed += spell.Value;
						break;
					case Variable.MaxHealth:
						MaxHealth += spell.Value;
						break;
					case Variable.MaxMana:
						MaxMana += spell.Value;
						break;
				}
			}
		}
	}

	void Update()
	{
		CheckAbilities();
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
			Mana += Math.Min(ManaRecovery * Time.deltaTime, MaxMana - Mana);
		}
	}
}