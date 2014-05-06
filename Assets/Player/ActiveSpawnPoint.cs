using UnityEngine;
using System.Collections;

public class ActiveSpawnPoint : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		if (ChangeS.map == "Forest")
						transform.position = new Vector3 (-0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
