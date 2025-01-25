using UnityEngine;

public class AbilityCreate : MonoBehaviour
{
	public PlayerState state;
	public TempAbilityData data;
	public CostCompute computer;

	public void Create()
	{
		if(data.AbilityType == AbilityType.Spell)
		{
			if(data.SpellType == SpellType.Player)
			{
				Effect effect = new Effect(data.SpellEffectVariableCurrent, data.SpellEffectValueCurrent, data.SpellEffectVariableFinal, data.SpellEffectValueFinal, data.SpellEffectDuration, data.SpellEffectTimes);
				HitBox hitbox = new HitBox(data.HitBoxType, data.HitBoxRadius_or_Height, data.HitBoxWidth);
				SpellData spell = new SpellData(data.SpellDamage, data.ProjectileTrackMouse, false, effect, hitbox, data.ProjectileSpeed, 0, data.ProjectileLifeTime, data.SpellImagePath, data.SpellSoundPath);
				spell.Cost = computer.Compute(spell);
				state.AddAbility(spell);
			}
			else if(data.SpellType == SpellType.Projectile)
			{
				Effect effect = new Effect(data.SpellEffectVariableCurrent, data.SpellEffectValueCurrent, data.SpellEffectVariableFinal, data.SpellEffectValueFinal, data.SpellEffectDuration, data.SpellEffectTimes);
				HitBox hitbox = new HitBox(data.HitBoxType, data.HitBoxRadius_or_Height, data.HitBoxWidth);
				SpellData spell = new SpellData(data.SpellDamage, data.ProjectileTrackMouse, data.ProjectilePiercing, effect, hitbox, data.ProjectileSpeed, data.ProjectileTravelDistance, data.ProjectileLifeTime, data.SpellImagePath, data.SpellSoundPath);
				spell.Cost = computer.Compute(spell);
				state.AddAbility(spell);
			}
		}
		else if(data.AbilityType == AbilityType.Buff)
		{
			if(data.BuffType == BuffType.Permanent)
			{
				BuffData buff = new BuffData(data.BuffVariable, data.BuffValue);
				buff.Cost = computer.Compute(buff);
				state.AddAbility(buff);
			}
			else if(data.BuffType == BuffType.Temporary)
			{
				TempBuffData buffData = new TempBuffData(data.BuffVariable, data.BuffValue, data.BuffDuration);
				buffData.Cost = computer.Compute(buffData);
				state.AddAbility(buffData);
			}
		}
	}
}