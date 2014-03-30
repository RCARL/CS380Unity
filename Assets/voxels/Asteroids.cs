using System.Collections;
using UnityEngine;
using Noise;
using System.Collections.Generic;

public class Asteroids : MonoBehaviour {
	
	int X = 5;
	int Y = 5;
	int Z = 5;
	int cSize = 5;
	float[,,]noise;
	NoiseGen NoiseGenerator;
	public Texture PrimeTexture;
	Container asteroidGroup;
		
	void Start () {
		for (int x = 0; x<X; x++) {
			for (int y = 0; y<Y; y++) {
				for (int z = 0; z<Z; z++) {
					int randomValue = Random.Range(1,20);
					float limit = PerlinNoise (x, y, z, randomValue);
					Debug.Log (limit);
					if (limit <= 0.45)
						createBox(x,y,z);
				}
			}
		}
	}
	

	float PerlinNoise(int x,int y, int z, float scale){
		NoiseGenerator = new NoiseGen(cSize,5);
		float rValue;
		rValue=NoiseGenerator.GetNoise (((double)x)/scale, ((double)y)/scale, ((double)z)/scale);
		
		return rValue;
	}
	Container createBox(int x,int y, int z){
		GameObject ast = new GameObject (x + " " + y + " " + z);
		ast.AddComponent ("MeshCollider");
		ast.AddComponent ("MeshRenderer");
		ast.AddComponent ("MeshFilter");
		ast.AddComponent ("Container");
		Container p = ast.GetComponent("Container") as Container;
		p.chunkTexture = PrimeTexture;
		ast.transform.parent=gameObject.transform;
		ast.transform.localPosition = new Vector3 (x, y, z);
		ast.transform.localRotation = new Quaternion (0, 0, 0, 0);
		return p;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
