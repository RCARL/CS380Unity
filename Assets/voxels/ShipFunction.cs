using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ShipFunctions : MonoBehaviour{
public float laserSpeed = 10f;
public GameObject laserBeam;
List<GameObject> lasers;
public int distanceOfLaser= 20;
public bool hasOxygen = true;
private var beginTime : float = 0;
var endTime : float = 30;

	 	
	 	
	 /*
	 How can the player recover:
	 
	 -Oxygen?
	 -Speed?
	 -Security, i.e control of robots?
	 
	 */
	 
	 void HackSpeed(Ship target)
	 {
	 	if (target.Speed > 0){
	 	target.Speed *= target.Speed *.85;
	 	}else { Debug.Log ("Cannot decrease below 0");}
	 } 
	 
	 void BreachSecurity(Ship target)
	 {
	 	if (target.SecurityLevel >= 50){
	 	target.SecurityLevel *= target.SecurityLevel *.85;
	 	}else { Debug.Log("Targets's security level is below 50, robot's can be controlled");}
	 }
	 
	 void SuppressOxygen(Ship target)
	 {
	 
	 	if (target.OxygenLevel > 0){
		 target.OxygenLevel *= target.OxygenLevel *.85;
	 	}else { Debug.Log ("Target has no oxygen, they have 20 seconds to live.");
	
	 	
	 	}
	 	}	
	 	
	 }
		void OnMouseDown()
		{
		Debug.Log("This is for targeting, the enemies ship will turn red once it has been clicked");
		renderer.material.color = Color.red;
		}//end method OnMouseDown
		
		
		void OnMouseUp()
		{
		Debug.Log("the enemies ship will turn white once it has been clicked-released");
		renderer.material.color = Color.white;
		}
		
			void Start(){
				lasers = new List<GameObject>();
				for (int i = 0; i <  distanceOfLaser; i++)
				{
				lasers[i].GetComponent<BulletScript>().laserSpeed = laserSpeed;
				lasers[i].SetActive(false);
				//deactivates laser when it starts
				}
				
					if (!hasOxygen){
					beginTime = endTime;
					}
			}
			
		void Shoot(){
		GameObject g = lasers.Find(go => go.activeInHierarchy == false);
			if (g != null)
			{
			g.transform.position = transform.position + offset;
			g.SetActive(true);
			}
		 }//end shoot
		 
		 void Update()
		 {
		 if (Input.GetKeyDown("space")){
		 Shoot();
		 }
		 	if (!hasOxygen){
		 	beginTime -= time.deltaTime;
		 	}//end bool
		 	}
				 if (beginTime < 0) {//no time left
				 Debug.Log("Enemy has run out of oxygen and has not handled the situation within 30 seconds.");
				 }
		 
		 
		 }//end Update

}//end class ShipFunctions



using UnityEngine;
using System.Collections;
public class Ship : Monobehavior {

public CharacterController ship;

public float Speed = 10f;

public float OxygenLevel = 100;

//50 - Low level
//85 - Medium level
//100 - Highest level/default
public float SecurityLevel = 100;

public virtual void Start(){
ship = GetComponent<CharacterController>();
	
		
}//end Start

} //end class ship
