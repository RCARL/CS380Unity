#pragma strict

var destinations : Transform[];
var currentNPC : CharacterController;
var curWP : int = 0;
var turnspeed = 6;
var delay : float = 1.0;
var movespeed : float = 4.0;
var loopthroughWPs : boolean = true;

private var curTime: float;
function Start () {
	currentNPC= GetComponent(CharacterController);
}

function Update () {
	if(curWP<destinations.Length){
		nextWP();
	}
	else{
		if(loopthroughWPs){
			curWP=0;
		}
	}
}
function nextWP(){
	var destination : Vector3 = destinations[curWP].position;
	destination.y = transform.position.y; //keeps height the same
	var direction : Vector3 = destination - transform.position;
	
	if(direction.magnitude < 0.5){ //magic number to determine closeness to waypoint
		if (curTime == 0){
			curTime=Time.time;//makes the npc stop here, 'paused'
		}
		if ((Time.time- curTime) >= delay){
			curWP++;
			curTime=0;
		}
	}
	else {
		var rotation = Quaternion.LookRotation(destination - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnspeed);
		currentNPC.Move(direction.normalized * movespeed * Time.deltaTime);
	}
}