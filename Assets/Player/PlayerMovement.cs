using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	Vector3 movement;
	//private float RotateSpeed = 100;
	// Use this for initialization
	void Start () {
		rigidbody.useGravity = false;
	}
	
	void Update () {    
		float MoveHorizontal = Input.GetAxis("Horizontal");
		float MoveVertical = Input.GetAxis ("Vertical");
		float MoveUp = Input.GetAxis ("Fire2");
		float MoveDown = Input.GetAxis ("Fire3");
		if (Input.GetKeyDown (KeyCode.Space))
						rigidbody.velocity = rigidbody.velocity / 1.5f;

		else 
			movement = new Vector3 (MoveHorizontal * (speed * Time.deltaTime), (MoveUp-MoveDown)*(speed * Time.deltaTime), MoveVertical * (speed * Time.deltaTime));
			rigidbody.AddForce (movement);

	}
}
