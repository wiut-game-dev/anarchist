using UnityEngine;

public class T_HitBoxCreate : MonoBehaviour
{
	public GameObject HitBox;
	public float size = 1f;
	public PlayerState state;
	public float speed;
	// Start is called before the first frame update
	void Start()
	{
		speed = state.Speed;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.E)){
			HitBox.transform.localScale = new Vector3(size, size, size);
			Instantiate(HitBox, gameObject.transform.position, Quaternion.identity);
		}
		if(Input.GetKey(KeyCode.W))
		{
			gameObject.transform.position += Vector3.up * Time.deltaTime * speed;
		}
		if(Input.GetKey(KeyCode.S))
		{
			gameObject.transform.position += Vector3.down * Time.deltaTime * speed;
		}
		if(Input.GetKey(KeyCode.A))
		{
			gameObject.transform.position += Vector3.left * Time.deltaTime * speed;
		}
		if(Input.GetKey(KeyCode.D))
		{
			gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
		}
	}
}
