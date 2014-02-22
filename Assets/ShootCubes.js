#pragma strict

function Start () {

/*
Simple shooting on walls

1. Create an empty object (Call it bulletHolder)
2. Create a prefab  (Call it bullet and drag an object that you want it to be: cubes)
3. Attach a rigidbody to bullet to activate the script
4. Attach this shoot script to bulletHolder and drag the prefab to the projectile to the bullet holder
5. Make sure the bulletHolder and MainCamera are dragged under the player 

*/


}
var projectile : Rigidbody;
var speed = 20;
function Update () {

//Fire1 is just a tap on the mouse

if ( Input.GetButton ("Fire1")) {
var clone : Rigidbody;
clone = Instantiate(projectile, transform.position, transform.rotation);
clone.velocity = transform.TransformDirection( Vector3 (0, 0, speed));

Destroy (clone.gameObject, 3);



}

}
