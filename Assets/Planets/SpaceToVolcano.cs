using UnityEngine;
using System.Collections;

public class SpaceToVolcano : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Application.LoadLevel("Volcano");
	}
}
