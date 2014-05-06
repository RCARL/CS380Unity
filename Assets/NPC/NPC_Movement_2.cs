using UnityEngine;
using System.Collections;

public class NPC_Movement_2 : Living {
	Transform[] waypoint= new Transform[3];        // The amount of Waypoint you want
	float patrolSpeed= 3.0f;       // The walking speed between Waypoints
	bool loop = true;       // Do you want to keep repeating the Waypoints
	float dampingLook = 6.0f;          // How slowly to turn
	float pauseDuration = 1.0f;   // How long to pause at a Waypoint
	bool isAggro = false; 
	private float atkTime;
	private float curTime;
	private int currentWaypoint=0;
	private CharacterController character;
	private bool attackcooldown = false;

	GameObject player;
	PlayerCombat playercombatobject;
	void Start(){
		health = 50;
		if((character=gameObject.GetComponent<CharacterController>()) == null)
			character = gameObject.AddComponent<CharacterController>();
		//character = gameObject.GetComponent<CharacterController>(); //uses character movement methods
    
    	GameObject start = new GameObject();
    	start.transform.position=transform.position;
    	waypoint[0]=start.transform; //the first waypoint is where the npc spawns
    
    	GameObject first = new GameObject();
    	first.transform.position=transform.position;
    	first.transform.Translate(10,0,0,null); //the second waypoint is 10 units to the right
    	waypoint[1]=first.transform;
    
    	GameObject second = new GameObject();
    	second.transform.position=first.transform.position;
    	second.transform.Translate(0,0,10,null); //the third waypoint is 10 units down from the second wp
    	waypoint[2]=second.transform;
    	//Note: those values are currently arbitrary and can be changed, this is just a sample
    	//basic movement pattern that can be repeated on a flat plane
	}
 
	void Update(){
 		player = GameObject.FindWithTag("Player");
		playercombatobject = player.GetComponent<PlayerCombat> ();
 		if(Vector3.Distance(transform.position, player.transform.position) <=10)
 			chase(player);
    	else if(currentWaypoint < waypoint.Length){ //check to be within the array
       		patrol();
       	}else{    
    		if(loop){ //restarts array location for continuous patrolling
       			currentWaypoint=0;
        	} 
    	}
	}
 
	void patrol(){
 
        Vector3 target = waypoint[currentWaypoint].position;
        //target.y = transform.position.y; // Keep waypoint at character's height
        Vector3 moveDirection = target - transform.position;
 
    	if(moveDirection.magnitude < 0.5){
       		if (curTime == 0)
         		curTime = Time.time; // Pause over the Waypoint
       		if ((Time.time - curTime) >= pauseDuration){
         	currentWaypoint++;
         	curTime = 0;
       		}
    	}else{        
       		var rotation = Quaternion.LookRotation(target - transform.position);
       		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
       		character.Move(moveDirection.normalized * patrolSpeed * Time.deltaTime);
    	}  
	}
	void chase(GameObject prey){

		/*foreach (GameObject g in NPC_Tracker.NPCs) {
			if(Vector3.Distance(gameObject.transform.position, g.transform.position) <= .5f) {

			}
				//I forget where I was going with this right now, but I'll just fix it for the git for now
		}*/
		Vector3 target = prey.transform.position;
		//target.y = transform.position.y;
		Vector3 moveDirection = target - transform.position;
		//print (moveDirection.magnitude);
	
		if(moveDirection.magnitude < 1.5f){
			if(!attackcooldown)
				StartCoroutine("attack");
		}
		else {
			var rotation = Quaternion.LookRotation(target - transform.position);
       		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
       		character.Move(moveDirection.normalized * patrolSpeed * Time.deltaTime);
    	}  
	}
	IEnumerator attack(){
		print ("attacking");
		playercombatobject.hitbyenemy();
		attackcooldown = true;
		yield return new WaitForSeconds (1.0f);
		print ("after attacking");
		attackcooldown = false;
	}
}