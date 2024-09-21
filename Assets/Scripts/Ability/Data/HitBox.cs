using UnityEngine;

public class HitBox
{
	public HitBoxType Type;
	//rename if needed
	public int Radius_or_Height;
	public int Width;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
public enum HitBoxType
{
	Circle = 0,
	Rectangle = 1,
}