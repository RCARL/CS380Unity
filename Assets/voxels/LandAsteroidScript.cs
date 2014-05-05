using UnityEngine;
using System.Collections;

public class LandAsteroidScript : MonoBehaviour {
	GameObject g;
	public int NumberofAsteroids;
	public bool gravity=true;
	public float xvalue;
	public float yvalue;
	public float zvalue;

	int apart = 0;
	private System.Random rand = new System.Random();
	// Use this for initialization
	void Awake () {
		for( int i = NumberofAsteroids;i<(NumberofAsteroids*2);i++){
			g = new GameObject ("asteroid"+i*0.05f);
			g.AddComponent<Asteroids> ().thresh=i*0.05f;
			g.transform.position= new Vector3(xvalue, yvalue, zvalue);
			g.rigidbody.useGravity = gravity;
			g.rigidbody.angularDrag = 5.0f;
			g.rigidbody.drag = 10.0f;
			Destroy (gameObject);
		}
		
	}
}

