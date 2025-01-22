using UnityEngine;

public class HitBox
{
	public HitBoxType Type; //rename if needed
	public int Radius_or_Height;
	public int Width;
	
}
public enum HitBoxType
{
	Circle = 0,
	Rectangle = 1,
}