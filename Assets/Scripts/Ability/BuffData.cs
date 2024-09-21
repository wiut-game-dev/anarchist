using UnityEngine;

public class BuffData : ScriptableObject
{
	public BuffType Type;
	public Variable Variable;
	public int Value;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
public enum BuffType
{
	Permanent = 0,
	Temporary = 1,
}