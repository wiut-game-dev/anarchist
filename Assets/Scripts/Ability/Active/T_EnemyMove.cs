using UnityEngine;

public class T_EnemyMove : MonoBehaviour
{
	private void Update()
	{
		gameObject.transform.position += new Vector3(Random.Range(-5f*Time.deltaTime, 5f*Time.deltaTime), Random.Range(-5f*Time.deltaTime, 5f*Time.deltaTime), 0);
	}

	void OnTriggerStay()
	{
		Debug.Log("Eouch");
	}

	private void Start()
	{
		gameObject.transform.position+=new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
	}
}