using UnityEngine;
using System.Collections;

public class ChangeS: MonoBehaviour {
	public static Vector3 defaultRespawn = new Vector3(-1413.0f,229.0f,-1000.0f);
	public static string map = Application.loadedLevelName;

	void Update () {
		if (Input.GetKeyDown ("s")) {
			map = Application.loadedLevelName;
			Application.LoadLevel ("AsteroidsTestScene");
			}

	}
}
