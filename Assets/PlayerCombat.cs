using System;
using UnityEngine;

public class PlayerCombat : Living {
	bool isdead=false;
	void Start() {
		health = 100;
	}
	public override void hitbyenemy(){
		print ("hi");
		if (!isdead){
			health -= 5;
			if (health <= 0) {
				Time.timeScale=0;
				//gameObject.SetActive(false);
				isdead = true;
			}
		}
	}
	void OnGUI(){
		if (isdead) {
						GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));

						GUI.Box (new Rect (0, 0, 100, 100), "You Have Died.");
						GUI.Button (new Rect (10, 40, 80, 30), "Main Menu");
						GUI.Button (new Rect (10, 140, 80, 30), "Quit Game");

						GUI.EndGroup ();
				}
	}
}