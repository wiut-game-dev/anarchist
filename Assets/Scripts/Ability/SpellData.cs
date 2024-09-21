public class SpellData : BasicAbilityData
{
	public SpellType Type;
	public DamageType DamageType = DamageType.Pure;
	public int? Lifetime = null;
	public int? TravelDistance = null;
	public int Damage;
	public int Cost;
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
public enum DamageType
{
	Pure = 0,
}