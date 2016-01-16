using UnityEngine;
using System.Collections;

public class playerBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moveCamera ();
	}

	//move player through arrow keys
	void moveCamera ()
	{
		if (Input.GetKey (KeyCode.W))
			transform.Translate (new Vector3 (0, 0, 1));
		if (Input.GetKey (KeyCode.S))
			transform.Translate (new Vector3 (0, 0, -1));
		if (Input.GetKey (KeyCode.A))
			transform.Translate (new Vector3 (-1, 0, 0));
		if (Input.GetKey (KeyCode.D))
			transform.Translate (new Vector3 (1, 0, 0));
	}
}
