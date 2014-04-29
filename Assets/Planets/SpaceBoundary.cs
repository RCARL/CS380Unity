using UnityEngine;
using System.Collections;

public class SpaceBoundary : MonoBehaviour {
	void Update(){
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x,-9000, 7250),
			Mathf.Clamp(transform.position.y,0,500),
			Mathf.Clamp(transform.position.z,-2400, 1000)
			);
	}
}

