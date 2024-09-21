using System.Collections.Generic;

using UnityEngine;

public class PlayerState : ScriptableObject
{
	//that refers to unlocked abilities
	public List<BasicAbilityData> Abilities;
	public List<TempBuffData> Buffs;
	public int Health;
	public int MaxHealth;
	public int Mana;
	public int MaxMana;
	public int ManaRecovery;
	public int Attack;
	public int AttackSpeed;
	public int Speed;
	void Start()
	{

	}

	void Update()
	{

	}
}