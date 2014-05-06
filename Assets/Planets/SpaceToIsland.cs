using UnityEngine;
using System.Collections;

public class SpaceToIsland : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Application.LoadLevel("Island");
	}
}
