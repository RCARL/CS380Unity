﻿using UnityEngine;
using System.Collections;


public class playerGUI : MonoBehaviour {


	
	void OnGUI () {

		GUI.Label(new Rect(10, 10, 100, 20), Player.playerSingleton.equipmentSelected.ToString());

	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
			Player.playerSingleton.equipmentSelected=0;
		
		if(Input.GetKeyDown(KeyCode.Alpha2))
			Player.playerSingleton.equipmentSelected=1;
		
		if(Input.GetKeyDown(KeyCode.Alpha3))
			Player.playerSingleton.equipmentSelected=2;
		
		if(Input.GetKeyDown(KeyCode.Alpha4))
			Player.playerSingleton.equipmentSelected=3;
		
		if(Input.GetKeyDown(KeyCode.Alpha5))
			Player.playerSingleton.equipmentSelected=4;

	}
}