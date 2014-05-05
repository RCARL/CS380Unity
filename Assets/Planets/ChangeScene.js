#pragma strict

var myLevel : String;
 
function OnCollisionEnter(other : Collision){
    if(other.gameObject.name == "Asteroid1"){
        Application.LoadLevel("Volcano");
    }
 
    if(other.gameObject.tag == "SomeTag"){
        Application.LoadLevel("Level name");
    }
}