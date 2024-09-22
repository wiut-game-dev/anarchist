public class PlayerSpellData : BasicAbilityData
{
	public DamageType DamageType = DamageType.Pure;
	public int Damage;
	public Effect Effect;
	public HitBox HitBox;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
public enum SpellType
{
	FromPlayer = 0,
	FromEntity = 1,
}
//that's just for now, then we can add other types
public enum DamageType
{
	Pure = 0,
}