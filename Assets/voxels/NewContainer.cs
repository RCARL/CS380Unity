using UnityEngine;
using System.Collections;

public class NewContainer : MonoBehaviour {
    public byte flavor = 0x04;

	// Use this for initialization
	void Start () {

		Container cont= gameObject.AddComponent<Container> ();

		cont.createChunk(0,0,0,new int[]{1,1,1},flavor);


		Destroy(gameObject.GetComponent("NewContainer"));
	}


}
