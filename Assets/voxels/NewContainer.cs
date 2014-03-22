﻿using UnityEngine;
using System.Collections;

public class NewContainer : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Container cont= gameObject.AddComponent ("Container") as Container;
		Rigidbody rig= gameObject.AddComponent ("Rigidbody") as Rigidbody;
		rig.useGravity=false;
		cont.chunkTexture=Resources.LoadAssetAtPath("Assets/voxels/tilesheet.png",typeof(Texture)) as Texture;
		cont.createChunk(0,0,0,new int[]{1,1,1},1);
		rig.mass=1000;
		Destroy(gameObject.GetComponent("NewContainer"));
	}


}
