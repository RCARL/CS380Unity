using UnityEngine;
using System.Collections;

public class FPS_WASD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public float moveSpeed=500;
    public float turnSpeed = 10;
	void Update ()
	{
		if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.eulerAngles += (Vector3.down * turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.eulerAngles -= (Vector3.down * turnSpeed * Time.deltaTime);
	/*	if(Input.GetKey(KeyCode.LeftShift))
			transform.Translate(Vector3.up*moveSpeed*Time.deltaTime);
		if(Input.GetKey(KeyCode.LeftControl))
			transform.Translate(Vector3.down*moveSpeed*Time.deltaTime);
        */
	}

	

}
