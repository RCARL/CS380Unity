using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class world : MonoBehaviour {

	public Dictionary <string,prim> chunks; 	
	int chunkSize =5;
	public GameObject chunk;
	public Texture primTexture;
	public void lostOne()
	{
		
		if(transform.childCount<=1)
			Destroy(gameObject);
	}
	public void createChunk(int x, int y, int z,byte[,,] blocks)
	{
		prim p;
		if (!chunks.TryGetValue (x + " " + y + " " + z, out p))
			p = createChunk (x, y, z).GetComponent ("prim") as prim;


		p.initBlocks (blocks);
		p.updateMesh = true;
	}
	public void createChunk(int x, int y, int z,int[] i,byte b)
	{
	
		prim p;
		if (!chunks.TryGetValue (x + " " + y + " " + z, out p))
			p = createChunk (x, y, z).GetComponent ("prim") as prim;


		p.initBlocks ();

		p.changeLocalBlock (i [0], i [1], i [2], b);
		p.updateMesh = true;
	}

	private GameObject createChunk(int x,int y, int z)
	{
		GameObject ans = new GameObject (x + " " + y + " " + z);
		ans.AddComponent ("MeshCollider");
		ans.AddComponent ("MeshRenderer");
		ans.AddComponent ("MeshFilter");
		ans.AddComponent ("prim");
		prim p = ans.GetComponent("prim") as prim;

		ans.transform.parent=gameObject.transform;
		ans.transform.localPosition = new Vector3 (x * chunkSize - 0.5f, y * chunkSize + 0.5f, z * chunkSize - 0.5f);
		ans.transform.localRotation = new Quaternion (0, 0, 0, 0);
		ans.renderer.material.mainTexture = primTexture;
		
		chunks.Add (x + " " + y + " " + z, p);
		return ans;

	}
	void Start () {
		chunks = new Dictionary<string,prim> ();
		createChunk (0, 0, 0,new int[]{1,1,1},1);


	}
	// Update is called once per frame
	void Update () {
	
	}
}
