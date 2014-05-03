using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private float MoveSpeed = 100000.0f;
	Vector3 movement;
	public float xMin, xMax, yMin, yMax, zMin, zMax;
	//private float RotateSpeed = 100;
	// Use this for initialization
	void Start () {
		//rigidbody.useGravity = false;
	}
	
	void Update () {    
		float MoveHorizontal = Input.GetAxis("Horizontal");
		float MoveVertical = Input.GetAxis ("Vertical");
		float MoveUp = Input.GetAxis ("Fire2");
		float MoveDown = Input.GetAxis ("Fire3");
		if (Input.GetKeyDown (KeyCode.Space)) {
			rigidbody.velocity = rigidbody.velocity / 1.5f;
		}else {
			movement = new Vector3 (MoveHorizontal * (MoveSpeed * Time.deltaTime),0.0f, MoveVertical * (MoveSpeed * Time.deltaTime));
			rigidbody.AddForce (movement);
		}
		rigidbody.position = new Vector3(
			Mathf.Clamp(rigidbody.position.x,xMin, xMax),
		    Mathf.Clamp(rigidbody.position.y,yMin, yMax),
		    Mathf.Clamp(rigidbody.position.z,zMin, zMax)
			);

	}
}
