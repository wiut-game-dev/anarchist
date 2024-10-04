using UnityEngine;

public class T_HitBoxCreate : MonoBehaviour
{
	public GameObject HitBox;
	public float size = 1f;
	public PlayerState state;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.E)){
			HitBox.transform.localScale = new Vector3(size, size, size);
			Instantiate(HitBox, gameObject.transform.position, Quaternion.identity);
		}
	}
}
