using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BackgroundSpawn : MonoBehaviour
{
	public GameObject player;
	public GameObject background;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(Mathf.Abs(player.transform.position.y) > 70 || Mathf.Abs(player.transform.position.x) > 70)
			player.transform.position = new Vector3(0, 0, 0);
		Debug.Log(player.transform.position);
	}
}
