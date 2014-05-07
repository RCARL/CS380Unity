using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Noise;

public class IslandCreator : MonoBehaviour {
	
	NoiseGen noise = new NoiseGen();
	public float tileSize;

	// Use this for initialization
	void Start () {
		Terrain ter = this.GetComponent<Terrain> ();
		float positionx = 0;
		float positiony = -9.9f;
		float positionz = 0;
		transform.position = new Vector3 (positionx, positiony, positionz);
		GenerateHeights (ter, tileSize);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void GenerateHeights(Terrain terrain, float tileSize)
	{
		float[,] heights = new float[terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight];
		for (int i = 0; i < terrain.terrainData.heightmapWidth; i++) {
			for (int k = 0; k < terrain.terrainData.heightmapHeight; k++) {
				float a = noise.GetNoise ((i / (float)terrain.terrainData.heightmapWidth) * tileSize, (k / (float)terrain.terrainData.heightmapHeight) * tileSize, 1);
				if(i<40||i>500||k<40||k>500)
					heights[i,k] = 0;
				else
					heights[i,k] = a;

				//Debug.Log(a);
				//float a = Mathf.PerlinNoise(((float)i / (float)terrain.terrainData.heightmapWidth) * tileSize, ((float)k / (float)terrain.terrainData.heightmapHeight)*tileSize)/10.0f;
			}
		}
		
		terrain.terrainData.SetHeights(0, 0, heights);
	}
}


