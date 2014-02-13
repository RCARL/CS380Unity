using UnityEngine;
using System.Collections;

public class FPS_WASD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public float moveSpeed=1;

	void Update ()
	{
		if(Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.S))
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.A))
			transform.Translate(Vector3.left* moveSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.D))
			transform.Translate(Vector3.right* moveSpeed * Time.deltaTime);
		if(Input.GetKey(KeyCode.LeftShift))
			transform.Translate(Vector3.up*moveSpeed*Time.deltaTime);
		if(Input.GetKey(KeyCode.LeftControl))
			transform.Translate(Vector3.down*moveSpeed*Time.deltaTime);

	}

	

}
