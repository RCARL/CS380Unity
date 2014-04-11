#pragma strict
 
var waypoint : Transform[]= new Transform[3];        // The amount of Waypoint you want
var patrolSpeed : float = 3.0;       // The walking speed between Waypoints
var loop : boolean = true;       // Do you want to keep repeating the Waypoints
var dampingLook = 6.0;          // How slowly to turn
var pauseDuration : float = 1.0;   // How long to pause at a Waypoint
 
private var curTime : float;
private var currentWaypoint : int = 0;
private var character : CharacterController;
 
function Start(){
	character = GetComponent(CharacterController); //uses character movement methods
    
    var start : GameObject = new GameObject();
    start.transform.position=transform.position;
    waypoint[0]=start.transform; //the first waypoint is where the npc spawns
    
    var first : GameObject = new GameObject();
    first.transform.position=transform.position;
    first.transform.Translate(10,0,0,null); //the second waypoint is 10 units to the right
    waypoint[1]=first.transform;
    
    var second : GameObject = new GameObject();
    second.transform.position=first.transform.position;
    second.transform.Translate(0,0,10,null); //the third waypoint is 10 units down from the second wp
    waypoint[2]=second.transform;
    //Note: those values are currently arbitrary and can be changed, this is just a sample
    //basic movement pattern that can be repeated on a flat plane
}
 
function Update(){
 
    if(currentWaypoint < waypoint.length){ //check to be within the array
       patrol();
       }else{    
    if(loop){ //restarts array location for continuous patrolling
       currentWaypoint=0;
        } 
    }
}
 
function patrol(){
 
        var target : Vector3 = waypoint[currentWaypoint].position;
        target.y = transform.position.y; // Keep waypoint at character's height
        var moveDirection : Vector3 = target - transform.position;
 
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