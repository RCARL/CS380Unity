using UnityEngine;
using System.Collections;

public class ActiveSpawnPoint : MonoBehaviour {
	// Use this for initialization
	void Start () {
		if (ChangeS.map == "Forest") {
						transform.position = new Vector3 (327.0f, 229.0f, 3091.0f);
				} else if (ChangeS.map == "Island") {
						transform.position = new Vector3 (-7088.0f, 229.0f, 3091.0f);
				} else if (ChangeS.map == "Volcano") {
						transform.position = new Vector3 (6704.0f, 229.0f, 1875.0f);
				}else
						transform.position = ChangeS.defaultRespawn;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
