using UnityEngine;
using System.Collections;
using System.Threading;
using System.Text;
using System.Globalization;

public class ShipFunction : MonoBehaviour {
	Ship user;
	public bool hasOxygen = true;
	public bool hasShields = true;
	public bool clickedReformat = false;
	static float timeLeftForOxygen = 30.0f;
	static float timeLeftForReformat = 25.0f;
	static float timeLeftForShields = 180.0f;


	void breachSecurity(Ship target){
		double tmp = 0.0;
	
		int tmp2 = target.getShields ();
		if ((target.GetSecurity() >= 50) && (hasShields)){
		tmp = target.GetSecurity ();
		tmp *= .85;  
		target.newSecurity(tmp);
			if (tmp2 > 0){
			/*
			 * ******
			Depending on the battle mechanisms, we need to see how often the other ship shoot at this ship, 
			maybe keep it simple and let a shield break depending on how many times it got shot (100 times for one shield?)
			
			*/
			}//end tmp2
			else{ hasShields = false; Debug.Log ("You have no shields, please create some with resources immediately (increase in health loss.");}
		} else{  Debug.Log("Targets's security level is below 50, robot's can be controlled");       }
	}


	void hackSpeed(Ship target)
	{
		double tmp = 0.0;
		if (target.getSpeed() > 0){
			tmp = target.getSpeed();
			tmp *=.85;
			target.newSpeed(tmp);
		}else { Debug.Log ("Cannot decrease below 0");} 
	} 


/*
Seperate timers for shields,  security, reformat, oxygen

Create a check method, if no oxygen >=30 seconds, player loses
Set bounds on reformat, you can only reformat every 25 seconds 
For the shields, it should fall under breachSecurity, decrease the number of shields ( 2 minutes each shield?)
So do this in a while loop, ex: while hasoxygen = false, start a basic timer for the oxygen, if = 30, player losers
Shields are the main soruce protecting their ship, so it should take longer to break a shield, maybe 3 minutes a shield because there are 10 of them.

*/



	void suppressOxygen(Ship target){
		double tmp = 0.0;
		if (target.GetOxygen() > 0) {
			hasOxygen = true;
			tmp = target.GetOxygen();
			tmp *=.85;
			target.newOxygen(tmp);
		}else { Debug.Log ("Target has no oxygen, they have 30 seconds to live.");
			hasOxygen = false;
			//start timer
		}

	}
	void activateReformat(){ clickedReformat = true;}
	void reformatSystem(Ship me){
		double tmp1 = me.GetSecurity();
		double tmp2 = me.GetOxygen();
		me.newSecurity(tmp1+=15.0);
		me.newOxygen(tmp2+=30.0);
		hasOxygen = true;
	}

	void OnMouseUp()
	{
		Debug.Log("the enemies ship will turn white once it has been clicked-released");
		renderer.material.color = Color.white;
	}
	void OnMouseDown()
	{
		Debug.Log("This is for targeting, the enemies ship will turn red once it has been clicked");
		renderer.material.color = Color.red;
	}//end method OnMouseDown

	void Start () {

	}
	
	void Update () {
		if (!hasOxygen){
			timeLeftForOxygen -= Time.deltaTime;
		}//end bool
		if (timeLeftForOxygen <= 0) {
			Debug.Log("Game over");
		}
		if (clickedReformat){
			timeLeftForReformat -= Time.deltaTime;
		}
		if (timeLeftForReformat == 0) {
			reformatSystem(user);
			clickedReformat = false;
			//set back to false so user can activate again
		}
	}


}
/*

*/
