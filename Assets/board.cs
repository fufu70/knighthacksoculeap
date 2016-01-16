using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class board : MonoBehaviour {

	private ArrayList vein_element_list;
	private ArrayList venation_element_list;
	private Dictionary<GameObject, ArrayList> connection_list;
	private Dictionary<GameObject, Vector3> normalized_connection_list;
	// for the board
	private float width;
	private float height;
	private System.Random randomGen;

	public GameObject vein_element;
	public Renderer rend;

	// Use this for initialization
	public void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = false;

		this.vein_element_list = new ArrayList ();
		this.venation_element_list = new ArrayList ();
		this.connection_list = new Dictionary<GameObject, ArrayList> ();
		this.normalized_connection_list = new Dictionary<GameObject, Vector3> ();
		this.randomGen = new System.Random ();

		this.width = this.transform.localScale.x;
		this.height = this.transform.localScale.y;

		this.AddInitialVeinElements ();
		for (int i = 0; i < 10; i++) {
			this.PlaceRandomVenation ();
		}
		this.SetupConnectionList ();
		this.NormalizeConnectionList ();
		this.AddNormalizedConnectionList ();
	}

	public void AddInitialVeinElements () {
		
		Vector3 l_position;

		// top left
		l_position = new Vector3 ( - (this.width / 2), (this.height / 2),this.transform.position.z);
		this.vein_element_list.Add(Instantiate (vein_element, l_position, Quaternion.identity));

		// top right
	}

	public void PlaceRandomVenation() {
		Vector3 l_position = new Vector3 (this.GetRandom (), this.GetRandom (), this.transform.position.z);

		foreach (GameObject element in this.vein_element_list) {
			if (Physics.OverlapSphere(l_position, 1).Length > 1) {
				PlaceRandomVenation ();
				return;
			}
		}
		this.venation_element_list.Add(l_position);
	}

	public void SetupConnectionList() {
		foreach (Vector3 venation_element in venation_element_list) {
			GameObject closest_element = this.GetClosestVeinElement (venation_element);
			if (!this.connection_list.ContainsKey (closest_element)) {
				this.connection_list.Add (closest_element, new ArrayList ());
			}
			this.connection_list[closest_element] .Add (venation_element);
		}
	}

	public void NormalizeConnectionList() {
		foreach (GameObject element in this.vein_element_list) {
			if (this.connection_list.ContainsKey (element) 
				&& this.connection_list [element].Count > 0) {
				Vector3 average = Vector3.zero;
				foreach (Vector3 venation_element in this.connection_list [element]) {
					average += venation_element;
				}

				this.normalized_connection_list.Add (element, average);
			}
		}
	}

	// add the element of a distance of 1
	// phi = atan2(y2-y1, x2-x1)
	// x = x1 + r * cos(phi)
	// y = y1 + r * sin(phi)
	public void AddNormalizedConnectionList() {
		ArrayList add_vector = new ArrayList ();

		foreach (GameObject element in this.vein_element_list) {
			if (this.connection_list.ContainsKey (element)) {
				double phi = Math.Atan2 (((Vector3)this.connection_list [element][0]).y - element.transform.position.y,
					((Vector3)this.connection_list [element][0]).x - element.transform.position.x);
				float x = (float) (element.transform.position.x + Math.Cos (phi));
				float y = (float) (element.transform.position.y + Math.Sin (phi));
				add_vector.Add(new Vector3 (x, y, element.transform.position.z));

			}
		}

		foreach (Vector3 l_position in add_vector) {
			this.vein_element_list.Add(Instantiate (vein_element, l_position, Quaternion.identity));
			this.ToCartesian (l_position);
		}
	}

	public void ToCartesian(Vector3 position) {
		float x = (float)(Math.Cos (position.x) * Math.Sin (position.y) * position.z);
		float y = (float)(Math.Sin (position.x) * Math.Sin (position.y) * position.z);
		float z = (float)(Math.Cos (position.y) * position.z);

		position.z = x;
		position.x = y;
		position.y = z;
		Instantiate (vein_element, position, Quaternion.identity);
	}

	// Update is called once per frame
	public void Update () {
		this.venation_element_list = new ArrayList ();
		this.connection_list = new Dictionary<GameObject, ArrayList> ();
		this.normalized_connection_list = new Dictionary<GameObject, Vector3> ();
		for (int i = 0; i < 10; i++) {
			this.PlaceRandomVenation ();
		}
		this.SetupConnectionList ();
		this.NormalizeConnectionList ();
		this.AddNormalizedConnectionList ();
	}

	public float GetRandom() {
		return (float) this.randomGen.Next ((int) -(this.width / 2), (int) this.width / 2);
	}

	private double GetDistance(float x1, float x2, float y1, float y2) {
		return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
	}

	public GameObject GetClosestVeinElement(Vector3 venation_element) {
		GameObject closest = (GameObject) this.vein_element_list[0];
		double closestDistance = this.GetDistance(closest.transform.position.x, venation_element.x, closest.transform.position.y, venation_element.y);

		foreach (GameObject element in vein_element_list) {
			if(closestDistance > this.GetDistance(element.transform.position.x, venation_element.x, element.transform.position.y, venation_element.y)) {
				closestDistance = this.GetDistance (element.transform.position.x, venation_element.x, element.transform.position.y, venation_element.y);
				closest = element;
			}
		}

		return closest;
	}
}