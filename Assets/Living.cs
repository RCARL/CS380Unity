using System;
using UnityEngine;
public class Living : MonoBehaviour {
	public int health;

	public virtual void hitbyenemy(){
		print ("wrong class");
		//overridden by subclasses
	}
}