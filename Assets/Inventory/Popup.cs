using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {
	public bool poppedUp;

	// Use this for initialization
	void Start () {
		poppedUp = false;
	}

	void OnGUI () {
		if (poppedUp) {
			GUI.Box(new Rect((Screen.width / 2) - Screen.width / 8, (Screen.height / 2) - Screen.height / 8, Screen.width / 4, Screen.height / 6), "Would you like to travel to this planet?");
			if (GUI.Button (new Rect ((Screen.width / 2) - Screen.width / 10, (Screen.height / 2) - Screen.height / 18, Screen.width / 12, Screen.height / 18), "Yes")) {
				poppedUp = false;
				//Code for when yes is hit goes here
			}
			if (GUI.Button (new Rect ((Screen.width / 2) + Screen.width / 50, (Screen.height / 2) - Screen.height / 18, Screen.width / 12, Screen.height / 18), "No")) {
				poppedUp = false;
				//Code for when no is hit goes here
			}
		}
	}
}