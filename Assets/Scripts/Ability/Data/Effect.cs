using UnityEngine;

public class Effect 
{
	public Variable VariableCurrent;
	public int ValueCurrent;
	public Variable VariableFinal;
	public int ValueFinal;
	public int Duration;//duration is time in seconds after which times are reduces and change applied
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
	MaxHealth=1,
	Mana =   2,
	MaxMana=3,
	ManaRecovery = 4,
	Attack = 5,
	AttackSpeed =  6,
	Speed =  7,
}