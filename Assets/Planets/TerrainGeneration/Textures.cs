using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Noise;

public class Textures : MonoBehaviour {

	public string FirstTexture;
	public string SecondTexture;
	public int HeightSeperation;
	float[, ,] splatmapData;
	
	// Use this for initialization
	void Start () {
		Terrain ter = this.GetComponent<Terrain> ();
		SetTextureOnTerrain (ter);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SetTextureOnTerrain(Terrain terrain)
	{
		SplatPrototype[] va_sp = new SplatPrototype[2];
		
		va_sp[0] = new SplatPrototype();
		va_sp[0].texture = (Texture2D)Resources.Load("MyTextures/"+FirstTexture);
		va_sp[1] = new SplatPrototype();
		va_sp[1].texture = (Texture2D)Resources.Load("MyTextures/"+SecondTexture);
		terrain.terrainData.splatPrototypes = va_sp;
		int v_td_alphaMapResolution = terrain.terrainData.alphamapResolution;
		
		float[, ,] va_alphamaps = new float[v_td_alphaMapResolution, v_td_alphaMapResolution, va_sp.Length];
		va_alphamaps = terrain.terrainData.GetAlphamaps(0, 0, v_td_alphaMapResolution, v_td_alphaMapResolution);
		
		for (int ti = 0; ti < v_td_alphaMapResolution; ti++) {
			for (int tj = 0; tj < v_td_alphaMapResolution; tj++) {
				float y_01 = (float)tj/(float)terrain.terrainData.alphamapHeight;
				float x_01 = (float)ti/(float)terrain.terrainData.alphamapWidth;
				float height = terrain.terrainData.GetHeight(Mathf.RoundToInt(y_01 * terrain.terrainData.heightmapHeight),Mathf.RoundToInt(x_01 * terrain.terrainData.heightmapWidth) );
				for (int v_tex = 0; v_tex < va_sp.Length; v_tex++) {	
					if(height>HeightSeperation)
						va_alphamaps[ti,tj,v_tex] = Random.Range(0.0f, 1);
				}
			}
		}
		terrain.terrainData.SetAlphamaps(0, 0, va_alphamaps);
	}
}



