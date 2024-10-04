public class EffectActive : Effect
{
	public float DurationCurrent;

	public EffectActive(Effect effect) : base(effect)
	{
		DurationCurrent = 0;
	}
}