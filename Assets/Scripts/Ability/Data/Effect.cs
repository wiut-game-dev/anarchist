using System.Collections.Generic;

public class Effect
{
	public Variable VariableCurrent;
	public int ValueCurrent;
	public Variable VariableFinal;
	public int ValueFinal;
	public float Duration;//duration is time in seconds after which times are reduces and change applied
	public int Times;
	// Start is called before the first frame update
	public Effect()
	{

	}
	public Effect(Effect effect)
	{
		VariableCurrent = effect.VariableCurrent;
		ValueCurrent = effect.ValueCurrent;
		VariableFinal = effect.VariableFinal;
		ValueFinal = effect.ValueFinal;
		Duration = effect.Duration;
		Times = effect.Times;
	}
}
public enum Variable
{
	Health = 0,
	MaxHealth = 1,
	Mana = 2,
	MaxMana = 3,
	ManaRecovery = 4,
	Attack = 5,
	AttackSpeed = 6,
	Speed = 7,
	Knockback = 8, //can be positive or negative
}
class EffectEqualityComparer: IEqualityComparer<Effect>
{
	public bool Equals(Effect x, Effect y)
	{
		if(x == null || y == null)
			return false;
		return(x.Duration==y.Duration&&x.VariableCurrent==y.VariableCurrent&&x.VariableFinal==y.VariableFinal&&x.ValueCurrent==y.ValueCurrent&&x.ValueFinal==y.ValueFinal);
	}

	public int GetHashCode(Effect obj)
	{
		return obj.GetHashCode();
	}
}