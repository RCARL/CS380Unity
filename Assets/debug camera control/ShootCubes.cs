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
		if(Player.playerSingleton.selectMode)
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
				MeshCollider first;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray,out hit,100)){

					first= hit.collider.GetComponent<MeshCollider>();
					first.convex=false;
					if (Physics.Raycast(ray,out hit,100))
					{

						first.convex=true;
						hit.collider.GetComponent<MeshCollider>().convex=true;

						hit.collider.GetComponent<chunk>().ReplaceBlockCursor(hit,Player.playerSingleton.blockTypeSelected);
					}
				}

				//	print("Hit something");
			}
		}
	}
}
