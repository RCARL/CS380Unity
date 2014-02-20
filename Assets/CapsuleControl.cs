using UnityEngine;
using System.Collections;

public class CapsuleControl : Capsule {
	public float camera = 0f;

	public float cameraMaxPitch = 45f;
	// Use this for initialization
	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {
		transform.Rotate (0f, Input.GetAxis ("Mouse X") * turnSpeed *Time.deltaTime, 0f);
	
		camera -= Input.GetAxis ("Mouse Y");
		camera = Mathf.Clamp (camera, -cameraMaxPitch, cameraMaxPitch);
		Camera.main.transform.forward = transform.forward;
		Camera.main.transform.Rotate (camera, 0f, 0f);

		move = new Vector3(Input.GetAxis ("Horizontal"), 0f, Input.GetAxis("Vertical"));

		move.Normalize ();
		move = transform.TransformDirection (move);

		if (Input.GetKeyDown (KeyCode.Space) && cc.isGrounded) {
			jump = true;
				}

		base.Update ();
	}
}
