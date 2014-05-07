using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {
	public bool poppedUp;
	public static string map = "AsteroidsTestScene";
	public static Vector3 defaultRespawn = new Vector3(-1413.0f,229.0f,-1000.0f);
	// Use this for initialization
	void Start () {
		poppedUp = false;
	}

	void OnGUI () {
		if (Input.GetKeyDown ("h"))
						poppedUp = true;
		if (poppedUp) {
			GUI.Box(new Rect((Screen.width / 2) - Screen.width / 8, (Screen.height / 2) - Screen.height / 8, Screen.width / 4, Screen.height / 6), "Leave Planet?");
			if (GUI.Button (new Rect ((Screen.width / 2) - Screen.width / 10, (Screen.height / 2) - Screen.height / 18, Screen.width / 12, Screen.height / 18), "Yes")) {
				poppedUp = false;
				map = Application.loadedLevelName;
				Debug.Log(map);
				Application.LoadLevel ("AsteroidsTestScene");
			}
			if (GUI.Button (new Rect ((Screen.width / 2) + Screen.width / 50, (Screen.height / 2) - Screen.height / 18, Screen.width / 12, Screen.height / 18), "No")) {
				poppedUp = false;
				//Code for when no is hit goes here
			}
		}
	}
}