#pragma strict

var character : CharacterController;
var waypoint : Transform[] = new Transform[3]; //array of locations to move through
var movespeed : float = 10; //movement speed
var currentWaypoint : int = 0;
var loopthrough : boolean = true; //go through the array repeatedly
var playerlocation : Transform;
 
function Start ()
{
    character = GetComponent(CharacterController);
    var start : GameObject = new GameObject();
    start.transform.position=transform.position;
    waypoint[0]=start.transform;
    var first : GameObject = new GameObject();
    first.transform.position=transform.position;
    first.transform.Translate(10,0,0,null);
    waypoint[1]=first.transform;
    var second : GameObject = new GameObject();
    second.transform.position=first.transform.position;
    second.transform.Translate(0,0,10,null);
    waypoint[2]=second.transform;
}
 
function Update () 
{
    if(currentWaypoint < waypoint.length)
    {
        var target : Vector3 = waypoint[currentWaypoint].position;
        target.y = transform.position.y; // keep waypoint at character's height
        var moveDirection : Vector3 = target - transform.position;
        if(moveDirection.magnitude < 1)
        {
            transform.position = target; // force character to waypoint position
            currentWaypoint++;
        }
        else
        {
            transform.LookAt(target);
            character.Move(moveDirection.normalized * movespeed * Time.deltaTime);
        }
    }
    else
    {
        if(loopthrough)
        {
            currentWaypoint=0;
        }
    }
}