public class TempBuffData : BuffData
{
	public float Duration;

	public TempBuffData(Variable var, int val, float duration) : base(var, val)
	{
		Duration = duration;
	}

	public TempBuffData(TempBuffData other) : base(other)
	{
		Duration = other.Duration;
	}
}