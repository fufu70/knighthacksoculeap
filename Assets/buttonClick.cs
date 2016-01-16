using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonClick : MonoBehaviour {

	// Use this for initialization
	public void Click()
	{
		SceneManager.LoadScene (1);
	}
}
