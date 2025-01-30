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
	public float TravelDistance;

	public SpellData(int damage, bool trackMouse, bool piercing, Effect effect, HitBox hitBox, float speed, float travelDistance, float lifetime, string imagePath = "", string soundPath = "")
	{
		Damage = damage;
		TrackMouse = trackMouse;
		Piercing = piercing;
		Effect = effect;
		HitBox = hitBox;
		Speed = speed;
		ImagePath = imagePath;
		SoundPath = soundPath;
		Lifetime = lifetime;
		TravelDistance = travelDistance;
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