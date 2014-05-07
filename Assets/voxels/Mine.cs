//Stephen DuMont
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	enum state{main, options, load, quit, story};
	state currentState=state.main;
	
	void OnGUI () {
		GUI.skin.box.wordWrap = true;
		//new Rect(left,top,width,height)
		if (currentState == state.main) {
			if (GUI.Button (new Rect (Screen.width * 0.2f, Screen.height * 0.1f, Screen.width * 0.6f, Screen.height * 0.15f), "New Game")) {
				Inventory.artificials = new SplayTree<Artificial> ();
				Application.LoadLevel ("Forest");
			}
			if (GUI.Button (new Rect (Screen.width * 0.2f, Screen.height * 0.3f, Screen.width * 0.6f, Screen.height * 0.15f), "Load Game")) {
				UniverseSaveObject.LoadUniverse ();
				Application.LoadLevel ("Forest");
			}
			if (GUI.Button (new Rect (Screen.width * 0.2f, Screen.height * 0.5f, Screen.width * 0.6f, Screen.height * 0.15f), "Story")) {
				currentState = state.story;
			}
			if (GUI.Button (new Rect (Screen.width * 0.2f, Screen.height * 0.7f, Screen.width * 0.6f, Screen.height * 0.15f), "Quit"))
				currentState = state.quit;
		}
		if (currentState == state.quit) {
			if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.35f,Screen.width*0.2f,Screen.height*0.3f),"No"))
				currentState=state.main;
			
			if(GUI.Button(new Rect(Screen.width*0.6f,Screen.height*0.35f,Screen.width*0.2f,Screen.height*0.3f),"Yes"))
				Application.Quit();
		}
		if (currentState == state.story) {
				GUI.Box(new Rect((Screen.width / 2) - (Screen.width/8), (Screen.height / 2) - (Screen.height / 8), Screen.width / 4, Screen.height / 4), "On a long space venture, you have lost your way! Your warp drive has quit and you've been thrown out of hyperspace surrounded by alien viruses. Gather resources to rebuild your warp drive and return to your home planet!");
		}
		
		//GUI.Button(new Rect(10,10,100,100),"New Game");
	}
}
