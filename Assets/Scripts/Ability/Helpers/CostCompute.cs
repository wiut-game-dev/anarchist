using System;

using UnityEngine;

public class CostCompute : ScriptableObject
{
	public PlayerState state;
	public int Compute(SpellData data)
	{
		if(data is SpellData)
			return -1;
		double cost = 0;
		#region Area
		float HitBoxArea = 0;
		if(data.HitBox.Type == HitBoxType.Circle)
		{
			HitBoxArea = MathF.PI * data.HitBox.Radius_or_Height * data.HitBox.Radius_or_Height;
		}
		else if(data.HitBox.Type == HitBoxType.Rectangle)
		{
			HitBoxArea = data.HitBox.Width * data.HitBox.Radius_or_Height;
		}
		#endregion Area
		cost += Math.Pow(HitBoxArea, 2f / 3f) * data.Damage;
		#region Effect
		var effect = data.Effect;
		double effcost = 0;
		effcost += effect.ValueCurrent / effect.Duration;
		effcost += effect.ValueFinal / effect.Duration / effect.Times;
		effcost *= HitBoxArea * 0.5f;
		#endregion Effect
		cost += effcost;
		return (int)(Math.Round(cost*2*Math.Sqrt(data.Lifetime)));
	}

	public int Compute(BuffData data)
	{
		double baseval = 0;
		double val = data.Value;
		switch(data.Variable)
		{
			case Variable.Health:
				baseval = state.Health;
				break;
			case Variable.Attack:
				baseval = state.Attack;
				break;
			case Variable.AttackSpeed:
				baseval = state.AttackSpeed;
				break;
			case Variable.ManaRecovery:
				baseval = state.ManaRecovery/2f;
				break;
			case Variable.MaxHealth:
				baseval = state.MaxHealth / 3f;
				break;
			case Variable.MaxMana:
				baseval = state.MaxMana / 3f;
				break;
			case Variable.Speed:
				baseval = state.Speed / 2f;
				break;
		}
		return (int)Math.Round(val / baseval * 500f);
	}

	public int Compute(TempBuffData data)
	{
		double baseval = 0;
		double val = data.Value;
		switch(data.Variable)
		{
			case Variable.Health:
				baseval = state.Health;
				break;
			case Variable.Attack:
				baseval = state.Attack;
				break;
			case Variable.AttackSpeed:
				baseval = state.AttackSpeed;
				break;
			case Variable.ManaRecovery:
				baseval = state.ManaRecovery;
				break;
			case Variable.MaxHealth:
				baseval = state.MaxHealth / 3f;
				break;
			case Variable.MaxMana:
				baseval = state.MaxMana / 3f;
				break;
			case Variable.Speed:
				baseval = state.Speed / 2f;
				break;
		}
		return (int)Math.Round(val / baseval * data.Duration * 10f);
	}
}