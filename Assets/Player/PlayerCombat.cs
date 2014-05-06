using System;
using UnityEngine;

public class PlayerCombat : Living {
	public Rigidbody originalbullet;
	bool isdead=false;
	void Start() {
		health = 100;
	}
	void Update(){
		if (Input.GetMouseButton (0))
			playershoot ();
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

						GUI.EndGroup ();
				}
	}
	void playershoot(){
		int speed = 5;
		GameObject go = GameObject.FindWithTag ("MainCamera");
		Rigidbody bullet = Instantiate (originalbullet, go.transform.position, go.transform.rotation) as Rigidbody;
		Physics.IgnoreCollision (go.collider, bullet.collider);
		bullet.AddForce (bullet.transform.forward * speed);
		}
}