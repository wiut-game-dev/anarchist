public class SpellData : BasicAbilityData
{
	public DamageType DamageType = DamageType.Pure;
	public int Damage;
	public Effect Effect;
	public HitBox HitBox;
	public string ImagePath;
	public string SoundPath;
	//so it basically creates an object from prefab in a shape of a hitbox and applies damage on touch
	public float Lifetime;
	public float TravelDistance;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
public enum DamageType
{
	Pure = 0,
}