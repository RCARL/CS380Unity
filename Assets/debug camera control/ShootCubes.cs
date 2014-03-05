using UnityEngine;
using System.Collections;

public class ShootCubes : MonoBehaviour {
	public Rigidbody projectile;
	public int speed=20;
	public int destruct=3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(MouseLook.cursor)
		{
			if ( Input.GetKey (KeyCode.Mouse0)) {
				
				Rigidbody clone;
				 clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
				clone.velocity = transform.TransformDirection( new Vector3 (0, 0, speed));
				
				Destroy (clone.gameObject, destruct);
			}
		}	
		else{
			if(	Input.GetKeyDown(KeyCode.Mouse0))
			{	
				RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray,out hit,100)){
					prim p= hit.collider.GetComponent("prim")as prim;
					p.ReplaceBlockCursor(hit,0);
				}
				//	print("Hit something");
			}
		}
	}
}
