using UnityEngine;
using System.Collections;

public class plopAsteroids : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		int i = 3;
		//for( int i = 3;i<6;i++){
			GameObject g = new GameObject ("asteroid"+i*0.05f);
			g.AddComponent<Asteroids> ().thresh=i*0.05f;
			g.transform.position= new Vector3((i-3)*20,0,0);
		//}

	}

}
