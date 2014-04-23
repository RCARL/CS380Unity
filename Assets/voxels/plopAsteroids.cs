using UnityEngine;
using System.Collections;

public class plopAsteroids : MonoBehaviour {
	GameObject g;
	// Use this for initialization
	void Awake () {
		int i = 3;
		//for( int i = 3;i<6;i++){
			 g = new GameObject ("asteroid"+i*0.05f);
			g.AddComponent<Asteroids> ().thresh=i*0.05f;
			g.transform.position= new Vector3((i-3)*20,0,0);
		//}

	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			print (
				g.GetComponent<Container>().chunks.Count);
		}
	}

}
