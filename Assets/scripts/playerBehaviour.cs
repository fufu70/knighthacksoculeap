using UnityEngine;
using System.Collections;

public class playerBehaviour : MonoBehaviour {

	//initialize variable
	float hsp;
	
	// Update is called once per frame
	void Update () {
		movePlayer ();
	}

	//move player through arrow keys
	void movePlayer ()
	{

		//move player place
		if (Input.GetKey (KeyCode.W))
			transform.Translate (new Vector3 (0, 0, 1));
		if (Input.GetKey (KeyCode.S))
			transform.Translate (new Vector3 (0, 0, -1));
		if (Input.GetKey (KeyCode.A))
			transform.Translate (new Vector3 (-1, 0, 0));
		if (Input.GetKey (KeyCode.D))
			transform.Translate (new Vector3 (1, 0, 0));

		//move camera vision

	}
}
