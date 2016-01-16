using UnityEngine;
using System.Collections;

public class beg_scenescript : MonoBehaviour {

	public GameObject canvas;
	public GameObject Borde;
	private Rigidbody rb;

	private bool move;

	// Use this for initialization
	public void Start () {
		move = false;
		rb = GetComponent<Rigidbody> ();
		Invoke ("startGame", 10);
	}

	public void Update()
	{
		if (move && transform.position.y < 0) {
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0f, 0f, 2.53f), 1f);
		} else if(move && transform.position.y >= 0){
			Borde.SetActive (true);
		}
	}

	public void startGame(){
		canvas.SetActive (false);
		move = true;
		Debug.Log ("start");
	}
}
