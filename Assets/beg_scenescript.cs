using UnityEngine;
using System.Collections;

public class beg_scenescript : MonoBehaviour {

	public GameObject canvas;
	public GameObject Borde;
	private Rigidbody rb;

	private bool move;

	// Use this for initialization
	public void Start () {
		rb = GetComponent<Rigidbody> ();
		Invoke ("startGame", 5);
	}

	public void Update()
	{
		if (move && transform.position.y < 0) {
			transform.Translate (new Vector3 (0f, 1f, 0f));
		}
	}

	public void startGame(){
		canvas.SetActive (false);
		move = true;
		Debug.Log ("start");
		Borde.SetActive (true);
	}
}
