using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {
	public float xMin, xMax, zMin, zMax;
	void Update(){
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x,xMin, xMax),
			transform.position.y,
			Mathf.Clamp(transform.position.z,zMin, zMax)
			);
	}
}
