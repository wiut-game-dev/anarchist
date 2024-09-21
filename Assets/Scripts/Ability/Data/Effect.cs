using UnityEngine;

public class Effect 
{
	public Variable VariableCurrent;
	public int ValueCurrent;
	public Variable VariableFinal;
	public int ValueFinal;
	public int Duration;
	public int Times;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
public enum Variable
{
	Health = 0,
	Mana =   1,
	ManaRecovery = 2,
	Attack = 3,
	AttackSpeed =  4,
	Speed =  5,
}