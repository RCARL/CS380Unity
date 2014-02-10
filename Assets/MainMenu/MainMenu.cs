//Stephen DuMont
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	enum state{main, options, load, quit};
	state currentState=state.main;
	
	void OnGUI () {

		//new Rect(left,top,width,height)
		if(currentState==state.main){
			if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.1f,Screen.width*0.6f,Screen.height*0.15f),"New Game"))
				print("new game");
			if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.3f,Screen.width*0.6f,Screen.height*0.15f),"Load Game"))
				print("Load Game");
			if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.5f,Screen.width*0.6f,Screen.height*0.15f),"Options"))
				currentState=state.options;

			if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.7f,Screen.width*0.6f,Screen.height*0.15f),"Quit"))
				currentState=state.quit;
		}
		if(currentState==state.options){
			if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.3f,Screen.width*0.6f,Screen.height*0.15f),"I am a fish"))
				print("User is a fish");
			if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.5f,Screen.width*0.6f,Screen.height*0.15f),"Back"))
				currentState=state.main;



		}
		if (currentState == state.quit) {
			if(GUI.Button(new Rect(Screen.width*0.2f,Screen.height*0.35f,Screen.width*0.2f,Screen.height*0.3f),"No"))
				currentState=state.main;
			
			if(GUI.Button(new Rect(Screen.width*0.6f,Screen.height*0.35f,Screen.width*0.2f,Screen.height*0.3f),"Yes"))
				Application.Quit();
		}

		//GUI.Button(new Rect(10,10,100,100),"New Game");

	}
}
