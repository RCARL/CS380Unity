using System.Collections;
using UnityEngine;
using Noise;
using System.Collections.Generic;

public class Asteroids : MonoBehaviour {
	
	public int X = 5;
	public int Y = 5;
	public int Z = 5;
	int cSize = 5;
	public float thresh=0.2f;
	NoiseGen NoiseGenerator;

	private System.Random rand = new System.Random();

		
	void Awake () {
		Container asteroidGroup=gameObject.AddComponent<Container> ();
		for (int x = -X; x<X; x++) 
			for (int y = -Y; y<Y; y++) 
				for (int z = -Z; z<Z; z++) {
					int randomValue = rand.Next(1,20);
					float limit = PerlinNoise (x, y, z, randomValue)* ((Mathf.Sqrt(x*x)/(X*X))+(Mathf.Sqrt(y*y)/(Y*Y))+(Mathf.Sqrt(z*z)/(Z*Z)));
					//Debug.Log (limit);
					if (limit <= thresh)
						asteroidGroup.createChunk(x,y,z,1);
				}
		foreach(chunk c in asteroidGroup.chunks.Values)
			c.makeContig();
			
		//asteroidGroup.checkIntegrity();
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
