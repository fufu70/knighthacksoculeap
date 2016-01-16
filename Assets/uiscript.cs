using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiscript : MonoBehaviour {

	// Get text objects
	public Text didyouknow;
	string[] facts;

	// Use this for initialization
	void Start () {

		//
		facts = new string[5]{
			"Simulation-based visual modeling of patterns found in living organisms\n" +
			"has a long history, bridging biology, theoretical studies of\nmorphogenesis, and computer graphics.",

			"This Virtual reality simulation mainly focus' on the modeling of venation pattern in leaves. \n",

			"Together with spiral phyllotaxis and the branching structures of tree architecture, " +
			"venation patterns are among the most admirable aspects of the natural beauty of plants. \n",

			"Venation patterns are strongly correlated with leaf shapes, in the simulation the leaf shape " +
			"is represented as a prefect square to wrap around a sphere using Mercator projection.\n",

			"The algorithm used is based on the biologically plausible hypothesis\n" +
			"that venation results from an feedback loop between leaf growth,\n" +
			"placement of auxin sources, and the development of veins.",
		};

		didyouknow.text = facts[(int)Random.Range(0, facts.Length)];
	}
}
