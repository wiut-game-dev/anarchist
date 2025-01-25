
public class HitBox
{
	public HitBoxType Type; //rename if needed
	public float Radius_or_Height;
	public float Width;
	public HitBox(HitBox hitBox)
	{
		Type = hitBox.Type;
		Radius_or_Height = hitBox.Radius_or_Height;
		Width = hitBox.Width;
	}
	public HitBox(HitBoxType type, float radius_or_height, float width = 0f)
	{
		Type = type;
		Radius_or_Height = radius_or_height;
		Width = width;
	}
}
public enum HitBoxType
{
	Circle = 0,
	Rectangle = 1,
}