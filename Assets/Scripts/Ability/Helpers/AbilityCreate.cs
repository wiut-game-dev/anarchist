using UnityEngine;

public class AbilityCreate : MonoBehaviour
{
	public PlayerState state;
	public AbilityTempData data;
	public CostCompute computer;

	public void Create()
	{
		if(data.AbilityType == AbilityType.Spell)
		{
			if(data.SpellType == SpellType.Player)
			{
				Effect effect = new Effect()
				{
					Duration = data.SpellEffectDuration,
					Times = data.SpellEffectTimes,
					ValueCurrent = data.SpellEffectValueCurrent,
					ValueFinal = data.SpellEffectValueFinal,
					VariableCurrent = data.SpellEffectVariableCurrent,
					VariableFinal = data.SpellEffectVariableFinal
				};
				HitBox hitbox = new HitBox()
				{
					Radius_or_Height = data.HitBoxRadius_or_Height,
					Type = data.HitBoxType,
					Width = data.HitBoxWidth
				};
				SpellData spell = new SpellData()
				{
					SoundPath = data.SpellSoundPath,
					Speed = data.SpellSpeed,
					Damage = data.SpellDamage,
					Cost = 0,
					DamageType = data.SpellDamageType,
					Effect = effect,
					HitBox = hitbox,
					ImagePath = data.SpellImagePath,
					Lifetime = 0.1f,
					TrackMouse = false,
					TravelDistance = 0
				};
				spell.Cost = computer.Compute(spell);
				state.AddAbility(spell);
			}
			else if(data.SpellType == SpellType.Projectile)
			{
				Effect effect = new Effect()
				{
					Duration = data.SpellEffectDuration,
					Times = data.SpellEffectTimes,
					ValueCurrent = data.SpellEffectValueCurrent,
					ValueFinal = data.SpellEffectValueFinal,
					VariableCurrent = data.SpellEffectVariableCurrent,
					VariableFinal = data.SpellEffectVariableFinal
				};
				HitBox hitbox = new HitBox()
				{
					Radius_or_Height = data.HitBoxRadius_or_Height,
					Type = data.HitBoxType,
					Width = data.HitBoxWidth
				};
				SpellData spell = new SpellData()
				{
					SoundPath = data.SpellSoundPath,
					Speed = data.SpellSpeed,
					Damage = data.SpellDamage,
					Cost = 0,
					DamageType = data.SpellDamageType,
					Effect = effect,
					HitBox = hitbox,
					ImagePath = data.SpellImagePath,
					Lifetime = data.ProjectileLifeTime,
					TrackMouse = data.SpellTrackMouse,
					TravelDistance = data.ProjectileTravelDistance,
				};
				spell.Cost = computer.Compute(spell);
				state.AddAbility(spell);
			}
		}
		else if(data.AbilityType == AbilityType.Buff)
		{
			if(data.BuffType == BuffType.Permanent)
			{
				BuffData buff = new BuffData()
				{
					Cost = 0,
					Value = data.BuffValue,
					Variable = data.BuffVariable
				};
				buff.Cost = computer.Compute(buff);
				state.AddAbility(buff);
			}
			else if(data.BuffType == BuffType.Temporary)
			{
				TempBuffData buffData = new TempBuffData()
				{
					Cost = 0,
					Duration = data.BuffDuration,
					Value = data.BuffValue,
					Variable = data.BuffVariable
				};
				buffData.Cost = computer.Compute(buffData);
				state.AddAbility(buffData);
			}
		}
	}
}