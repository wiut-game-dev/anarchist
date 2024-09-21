using UnityEngine;

public class HitBox : ScriptableObject
{
	public HitBoxType Type;
	public int Radius;
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