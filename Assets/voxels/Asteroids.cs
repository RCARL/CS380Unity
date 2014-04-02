using System.Collections;
using UnityEngine;
using Noise;
using System.Collections.Generic;

public class Asteroids : MonoBehaviour {
	
	public int X = 5;
	public int Y = 5;
	public int Z = 5;
	int cSize = 5;
	NoiseGen NoiseGenerator;



		
	void Start () {
		Container asteroidGroup=gameObject.AddComponent<Container> ();
		for (int x = -X; x<X; x++) {
			for (int y = -Y; y<Y; y++) {
				for (int z = -Z; z<Z; z++) {
					int randomValue = Random.Range(1,20);
					float limit = PerlinNoise (x, y, z, randomValue);
					//Debug.Log (limit);
					if (limit <= 0.45)
						asteroidGroup.createChunk(x,y,z,1);
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




	// Update is called once per frame
	void Update () {
	
	}
}
