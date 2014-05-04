using UnityEngine;
using System.Collections;

public class SpaceBoundary : MonoBehaviour {
	public float xmin;
	public float xmax;
	public float ymin;
	public float ymax;
	public float zmin;
	public float zmax;

	void Update(){
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x,xmin, xmax),
			Mathf.Clamp(transform.position.y,ymin, ymax),
			Mathf.Clamp(transform.position.z,zmin, zmax)
			);
	}
}

