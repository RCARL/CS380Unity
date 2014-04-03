using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour {
	public Inventory inventory = new Inventory();
	public int max;
	public int cur;
	
	public float barLength;
	public float maxBarLength;

	void Start () {
		max = inventory.capacity;
		barLength = Screen.width / 2;
		maxBarLength = Screen.width / 2;
	}
	void Update () {
		cur = inventory.current;
		adjust (0);
	}
	void OnGUI () {
		//Capacity bar
		GUI.Box (new Rect (10, 18, barLength, 20), "");
		GUI.Box (new Rect (10, 18, maxBarLength, 20), cur + "/" + max);

		//Labels
		GUI.Label (new Rect (5, 0, 80, 20), "Capacity");
		GUI.Label (new Rect (5, 50, 80, 40), "Iron");
		GUI.Label (new Rect (5, 70, 80, 40), "" + inventory.numIron[0]);
		GUI.Label (new Rect (5, 100, 80, 40), "Platinum");
		GUI.Label (new Rect (5, 120, 80, 40), "" + inventory.numPlatinum[0]);
		GUI.Label (new Rect (5, 150, 80, 40), "Titanium");
		GUI.Label (new Rect (5, 170, 80, 40), "" + inventory.numTitanium[0]);
		GUI.Label (new Rect (155, 50, 80, 40), "Beryllium");
		GUI.Label (new Rect (155, 70, 80, 40), "" + inventory.numBeryllium[0]);
		GUI.Label (new Rect (155, 100, 80, 40), "Uranium");
		GUI.Label (new Rect (155, 120, 80, 40), "" + inventory.numUranium[0]);
		GUI.Label (new Rect (155, 150, 80, 40), "Plutonium");
		GUI.Label (new Rect (155, 170, 80, 40), "" + inventory.numPlutonium[0]);
		GUI.Label (new Rect (310, 50, 80, 40), "Copper");
		GUI.Label (new Rect (310, 70, 80, 40), "" + inventory.numCopper[0]);
		GUI.Label (new Rect (310, 100, 80, 40), "Silver");
		GUI.Label (new Rect (310, 120, 80, 40), "" + inventory.numSilver[0]);
		GUI.Label (new Rect (465, 50, 80, 40), "Total Mass");
		GUI.Label (new Rect (465, 70, 80, 40), "" + inventory.totalMass);

		//Tester buttons
		if (GUI.Button (new Rect (10,200,100,40), "Add Iron")) {
			inventory.addResource(Resource.iron(1), 1);
		}
		if (GUI.Button (new Rect (130,200,100,40), "Remove Iron")) {
			inventory.removeResource(Resource.iron(1), 1);
		}
		if (GUI.Button (new Rect (10,250,100,40), "Add Beryllium")) {
			inventory.addResource(Resource.beryllium(1), 1);
		}
		if (GUI.Button (new Rect (130,250,100,40), "Remove Beryllium")) {
			inventory.removeResource(Resource.beryllium(1), 1);
		}
		if (GUI.Button (new Rect (10,300,100,40), "Add Copper")) {
			inventory.addResource(Resource.copper(1), 1);
		}
		if (GUI.Button (new Rect (130,300,100,40), "Remove Copper")) {
			inventory.removeResource(Resource.copper(1), 1);
		}
	}
	//Adjusts the mass bar
	public void adjust (int adj) {
		cur += adj;
		if (cur > max) {
			cur = max;
		}
		if (cur < 0) {
			cur = 0;
		}
		
		barLength = (Screen.width / 2) * (cur / (float) max);
	}
}
