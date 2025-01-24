public class SpellData : BasicAbilityData
{
	public DamageType DamageType = DamageType.Pure;
	public int Damage;
	public bool TrackMouse;
	public bool Piercing;
	public Effect Effect;
	public HitBox HitBox;
	public float Speed;
	public string ImagePath;
	public string SoundPath; //so it basically creates an object from prefab in a shape of a hitbox and applies damage on touch
	public float Lifetime;
	public float TravelDistance; // Start is called before the first frame update
	public SpellData()
	{

	}

	public SpellData(SpellData data)
	{
		Piercing = data.Piercing;
		Damage = data.Damage;
		TrackMouse = data.TrackMouse;
		Effect = new Effect(data.Effect);
		HitBox = new HitBox(data.HitBox);
		Speed = data.Speed;
		ImagePath = data.ImagePath;
		SoundPath = data.SoundPath;
		Lifetime = data.Lifetime;
		TravelDistance = data.TravelDistance;
	}
}
public enum DamageType
{
	Pure = 0,
}