using UnityEngine;

public class HitBox
{
	public HitBoxType Type; //rename if needed
	public int Radius_or_Height;
	public int Width;
	public HitBox(HitBox hitBox)
	{
		Type = hitBox.Type;
		Radius_or_Height = hitBox.Radius_or_Height;
		Width = hitBox.Width;
	}
	public HitBox()
	{

	}
}
public enum HitBoxType
{
	Circle = 0,
	Rectangle = 1,
}