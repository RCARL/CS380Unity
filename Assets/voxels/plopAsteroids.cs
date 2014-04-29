using UnityEngine;
using System.Collections;

public class plopAsteroids : MonoBehaviour {
	GameObject g;
	public float xvalue;
	public float yvalue;
	public float zvalue;
	// Use this for initialization
	void Awake () {
		int i = 3;
		//for( int i = 3;i<6;i++){
			 g = new GameObject ("asteroid"+i*0.05f);
			g.AddComponent<Asteroids> ().thresh=i*0.05f;
		g.transform.position= new Vector3(xvalue,yvalue,zvalue);
		g.rigidbody.useGravity = true;
		Destroy (gameObject);
		//}

	}
}
