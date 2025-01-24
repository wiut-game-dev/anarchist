using System;

using UnityEngine;
[CreateAssetMenu(menuName = "Cost Compute")]
public class CostCompute : ScriptableObject
{
	public PlayerState state;
	public int Compute(SpellData data)
	{
		double cost = 0;
		#region Area
		float HitBoxArea = 0;
		float TravelArea = 0;
		if(data.HitBox.Type == HitBoxType.Circle)
		{
			HitBoxArea = MathF.PI * data.HitBox.Radius_or_Height * data.HitBox.Radius_or_Height;
		}
		else if(data.HitBox.Type == HitBoxType.Rectangle)
		{
			HitBoxArea = data.HitBox.Width * data.HitBox.Radius_or_Height;
		}
		TravelArea = data.TravelDistance * data.HitBox.Radius_or_Height;
		if(!data.Piercing)
			TravelArea = (float)Math.Pow(TravelArea, 1f / 2);
		#endregion Area
		cost += Math.Pow(HitBoxArea, 1f / 4) * data.Damage+data.Lifetime;
		Debug.Log(cost);
		cost += Math.Pow(TravelArea, 1f / 3) * data.Damage;
		Debug.Log(cost);
		#region Effect
		var effect = data.Effect;
		double effcost = 0;
		effcost += effect.ValueCurrent / effect.Duration * (effect.Times-1);
		effcost += effect.ValueFinal / effect.Duration / effect.Times;
		effcost *= Math.Pow(HitBoxArea, 1f / 2) * 0.5f;
		#endregion Effect
		cost += effcost;
		Debug.Log(cost);
		return (int)(Math.Round(cost/3));
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
				baseval = state.ManaRecovery / 4f;
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