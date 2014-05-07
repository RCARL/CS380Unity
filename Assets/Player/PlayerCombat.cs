using System.Collections;
using UnityEngine;

public class PlayerCombat : Living {
	readonly float middleX = Screen.width / 2;
	public GameObject originalbullet;
	public GameObject muzzleLocation;
	bool isdead = false;
	public bool hasGun;
	private int max;
	private float barLength;
	private float maxBarLength;
	private int maxHealth = 100;
	private int cur;
	void Start() {
		hasGun = false;
		max = maxHealth;
		barLength = middleX;
		maxBarLength = middleX;
		if (gameObject.tag == "Player") {
						health = 100;
		} 
		else {
						health = 500;
		}
		muzzleLocation = new GameObject ();
	}
	void Update(){
		adjust ();
		if (gameObject.tag == "Player") {
			if (Input.GetMouseButtonDown (0)) {
				if(hasGun){
					StartCoroutine("playershoot");
				}
			}
		} 
		else {
			if (Input.GetMouseButtonDown (0))
				StartCoroutine("shipshoot");
		}
	}
	public void adjust () {
		if (cur > max) {
			cur = max;
		}
		if (cur < 0) {
			cur = 0;
		}
		barLength = middleX * (cur / (float) max);
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
		cur = health;
		if (isdead) {
						gameObject.GetComponent<governor>().currentState = state.gui;
						GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));
						GUI.Box (new Rect (0, 0, 100, 100), "You Have Died.");
						if (GUI.Button (new Rect (10, 40, 80, 30), "Main Menu")){
								Application.LoadLevel ("MainMenu");
								Time.timeScale=1;
			}

						GUI.EndGroup ();
				} else {
					GUI.Box (new Rect (10, Screen.height - 40, barLength, 20), "");
					GUI.Box (new Rect (10, Screen.height - 40, maxBarLength, 20), cur + "/" + max);
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