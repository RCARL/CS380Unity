using UnityEngine;
using System.Collections;

public class NewContainer : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Container cont= gameObject.AddComponent<Container> ();

		cont.createChunk(0,0,0,new int[]{1,1,1},4);


		Destroy(gameObject.GetComponent("NewContainer"));
	}


}
