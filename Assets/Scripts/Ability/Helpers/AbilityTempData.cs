using UnityEngine;

public class AbilityTempData : ScriptableObject
{
	public AbilityType AbilityType;

	public SpellType SpellType;

	public BuffType BuffType;
	public Variable BuffVariable;

	public int BuffValue;
	public int BuffDuration;

	public DamageType SpellDamageType;
	public int SpellDamage;

	public bool ProjectileTrackMouse;
	public float ProjectileSpeed;

	public string SpellImagePath;
	public string SpellSoundPath;

	public float ProjectileLifeTime;
	public float ProjectileTravelDistance;

	public Variable SpellEffectVariableCurrent;
	public Variable SpellEffectVariableFinal;

	public int SpellEffectValueCurrent;
	public int SpellEffectValueFinal;

	public float SpellEffectDuration;
	public int SpellEffectTimes;

	public HitBoxType HitBoxType;
	public int HitBoxRadius_or_Height;
	public int HitBoxWidth;
}

public enum AbilityType
{
	Spell = 0,
	Buff = 1,
}
public enum SpellType
{
	Player = 0,
	Projectile = 1,
}
public enum BuffType
{
	Permanent = 0,
	Temporary = 1,
}