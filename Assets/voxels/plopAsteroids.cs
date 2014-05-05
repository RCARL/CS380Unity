using UnityEngine;
using System.Collections;

public class plopAsteroids : MonoBehaviour {
	GameObject g;
	public int NumberofAsteroids;
	public bool gravity=true;
	public int xmin;
	public int xmax;
	public int ymin;
	public int ymax;
	public int zmin;
	public int zmax;
	int apart = 0;
	private System.Random rand = new System.Random();
	// Use this for initialization
	void Awake () {
		for( int i = NumberofAsteroids;i<(NumberofAsteroids*2);i++){
			 g = new GameObject ("asteroid"+i*0.05f);
			g.AddComponent<Asteroids> ().thresh=i*0.05f;
			g.transform.position= new Vector3(rand.Next(xmin,xmax),rand.Next(ymin,ymax),rand.Next(zmin,zmax));
			g.rigidbody.useGravity = gravity;
			SpaceBoundary r = g.AddComponent<SpaceBoundary>();
			r.xmin = xmin ;
			r.xmax = xmax;
			r.ymin = ymin;
			r.ymax = ymax;
			r.zmin = zmin;
			r.zmax = zmax;
			apart+=25;
			Destroy (gameObject);
		}

	}
}
