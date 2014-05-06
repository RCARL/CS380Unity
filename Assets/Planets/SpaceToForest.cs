using UnityEngine;
using System.Collections;

public class SpaceToForest : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Application.LoadLevel("Forest");
	}
}
