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

					chunk.editCube(InventoryGUI.currentSelection);

					//chunk.editCube(0x80,InventoryGUI.currentSelection.);
					


				//	print("Hit something");
			}
		}
	}
}
