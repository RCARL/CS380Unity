using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public class Capsule : MonoBehaviour {


	public CharacterController cc;
	protected Vector3 gravity = Vector3.zero;
	protected Vector3 move = Vector3.zero;
	public float moveSpeed = 5f;
	public float turnSpeed = 30f;
	public float jumpSpeed = 9f;
	public bool jump;
	/*

	work on a trigger mesh for an area with no gravity

	wait for voxels to test on

	
	*/



	// Use this for initialization
	public virtual void Start () {
		cc = GetComponent<CharacterController> ();

		if (!cc) 
		{
			Debug.LogError("error!");
			enabled = false;
		}
	}
	
	// Update is called once per frame
	public virtual void Update () {
		//this will move the character
		move *= moveSpeed;

		if (!cc.isGrounded) {
						gravity += Physics.gravity * Time.deltaTime;

				} else {
					gravity = Vector3.zero;
					if (jump){
				gravity.y = jumpSpeed;
				jump = false;
					}
				}
		move += gravity;
		cc.Move (move * Time.deltaTime);
	}
}
