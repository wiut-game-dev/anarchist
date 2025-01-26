public class BuffData : BasicAbilityData
{
	public Variable Variable;
	public int Value;
	public BuffData(Variable var, int val)
	{
		Variable = var;
		Value = val;
	}

	public BuffData(BuffData data)
	{
		Variable = data.Variable;
		Value = data.Value;
	}
}