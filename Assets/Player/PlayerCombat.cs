using System.Collections;
using UnityEngine;

public class PlayerCombat : Living {
	public GameObject originalbullet;
	public GameObject muzzleLocation;
	bool isdead=false;
	void Start() {
		if (gameObject.tag == "Player") {
						health = 100;
		} 
		else {
						health = 500;
		}
		muzzleLocation = new GameObject ();
	}
	void Update(){
		if (gameObject.tag == "Player") {
			if (Input.GetMouseButtonDown (0))
				StartCoroutine("playershoot");
		} 
		else {
			if (Input.GetMouseButtonDown (0))
				StartCoroutine("shipshoot");
		}
	}
	public override void hitbyenemy(){
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
						if (GUI.Button (new Rect (10, 40, 80, 30), "Main Menu")){
								Application.LoadLevel ("MainMenu");
								Time.timeScale=1;
			}

						GUI.EndGroup ();
				} else {
						GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 10, 10), "");
				}
	}
	IEnumerator playershoot(){
		int speed = 5000;
		GameObject go = GameObject.FindWithTag ("MainCamera");
		muzzleLocation.transform.position = go.transform.position;
		muzzleLocation.transform.rotation = go.transform.rotation;
		muzzleLocation.transform.Translate (.1f, -.1f, 0);
		GameObject bullet = Instantiate (originalbullet, muzzleLocation.transform.position, muzzleLocation.transform.rotation) as GameObject;
		bullet.tag = "playerattack";
		bullet.rigidbody.AddForce (bullet.transform.forward * speed);
		yield return new WaitForSeconds (5.0f);
		Destroy (bullet);
		}
	IEnumerator shipshoot(){
		int speed = 1000;
		GameObject go = GameObject.FindWithTag ("RAILGUN");
		muzzleLocation.transform.position = go.transform.position;
		muzzleLocation.transform.rotation = gameObject.transform.rotation;
		//muzzleLocation.transform.Translate (.1f, -.1f, 0);
		GameObject bullet = Instantiate (originalbullet, muzzleLocation.transform.position, muzzleLocation.transform.rotation) as GameObject;
		bullet.tag = "playerattack";
		bullet.rigidbody.AddForce (bullet.transform.forward * speed);
		yield return new WaitForSeconds (5.0f);
		Destroy (bullet);
	}
}