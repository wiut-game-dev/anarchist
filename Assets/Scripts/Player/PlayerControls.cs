using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public PlayerState state;
	private Rigidbody2D rb;
	public Vector2 movement;
	public Animator Movements;
	private void Start()
	{
		state.Health = 100;
		state.Mana = 100;
		Effect effect = new Effect()
		{
			Duration = 1f,
			Times = 4,
			ValueCurrent = 10,
			ValueFinal = 50,
			VariableCurrent = Variable.Health,
			VariableFinal = Variable.Health,
		};
		SpellData spell = new SpellData()
		{
			Piercing = true,
			Damage = 20,
			Effect = effect,
			Lifetime = 1f,
			TravelDistance = 10f,
			HitBox = new HitBox()
			{
				Radius_or_Height = 2f,
				Type = HitBoxType.Circle,
				Width = 1,
			},
			Speed = 20,
			TrackMouse = true,
		};
		spell.Cost = state.coster.Compute(spell);
		Debug.Log(spell.Cost);
		state.AddAbility(spell);
	}

	void CheckAbilities()
	{
		if(Input.GetKeyDown(KeyCode.Q) && state.UnlockedAbilities.Count > 0)
		{
			state.ActiveAbility = state.UnlockedAbilities[0];
		}
		if(Input.GetKeyDown(KeyCode.E) && state.UnlockedAbilities.Count > 1)
		{
			state.ActiveAbility = state.UnlockedAbilities[1];
		}
		if(Input.GetKeyDown(KeyCode.R) && state.UnlockedAbilities.Count > 2)
		{
			state.ActiveAbility = state.UnlockedAbilities[2];
		}
		if(Input.GetKeyDown(KeyCode.F) && state.UnlockedAbilities.Count > 3)
		{
			state.ActiveAbility = state.UnlockedAbilities[3];
		}
		if(Input.GetKeyDown(KeyCode.C) && state.UnlockedAbilities.Count > 4)
		{
			state.ActiveAbility = state.UnlockedAbilities[4];
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(state.ActiveAbility.List == 0)
			{
				var spell = state.SpellAbilities[state.ActiveAbility.Index];
				if(spell.Cost > state.Mana)
					return;
				else
					state.Mana -= spell.Cost;
				if(spell.HitBox.Type == HitBoxType.Circle)
				{
					var circle = Instantiate(state.HitBoxCircle, GameObject.FindGameObjectWithTag("PLAYER").transform.position, Quaternion.identity);
					circle.GetComponent<HitboxActive>().Spell = new SpellData(spell);
				}

				else if(spell.HitBox.Type == HitBoxType.Rectangle)
				{
					var square = Instantiate(state.HitBoxSquare, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
					square.GetComponent<HitboxActive>().Spell = spell;
				}
			}
			else if(state.ActiveAbility.List == 1)
			{
				var spell = state.BuffAbilities[state.ActiveAbility.Index];
				if(spell.Cost > state.Mana)
					return;
				else
					state.Mana -= spell.Cost;
				switch(spell.Variable)
				{
					case Variable.Health:
						state.Health += spell.Value;
						break;
					case Variable.Attack:
						state.Attack += spell.Value;
						break;
					case Variable.AttackSpeed:
						state.AttackSpeed += spell.Value;
						break;
					case Variable.ManaRecovery:
						state.ManaRecovery += spell.Value;
						break;
					case Variable.Speed:
						state.Speed += spell.Value;
						break;
					case Variable.MaxHealth:
						state.MaxHealth += spell.Value;
						break;
					case Variable.MaxMana:
						state.MaxMana += spell.Value;
						break;
				}
			}
			else if(state.ActiveAbility.List == 2)
			{
				var spell = state.TempBuffAbilities[state.ActiveAbility.Index];
				if(spell.Cost > state.Mana)
					return;
				else
					state.Mana -= spell.Cost;
				switch(spell.Variable)
				{
					case Variable.Health:
						state.Health += spell.Value;
						break;
					case Variable.Attack:
						state.Attack += spell.Value;
						break;
					case Variable.AttackSpeed:
						state.AttackSpeed += spell.Value;
						break;
					case Variable.ManaRecovery:
						state.ManaRecovery += spell.Value;
						break;
					case Variable.Speed:
						state.Speed += spell.Value;
						break;
					case Variable.MaxHealth:
						state.MaxHealth += spell.Value;
						break;
					case Variable.MaxMana:
						state.MaxMana += spell.Value;
						break;
				}
			}
		}
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		state.Update();
		CheckAbilities();
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		Movements.SetFloat("Horizontal", movement.x);
		Movements.SetFloat("Vertical", movement.y);
		Movements.SetFloat("Speed", movement.sqrMagnitude);

	}
	void FixedUpdate()
	{
		movement.Normalize();
		rb.linearVelocity = new Vector2(movement.x * state.Speed * Time.fixedDeltaTime, movement.y * state.Speed * Time.fixedDeltaTime);
	}
}
