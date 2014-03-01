//Stephen DuMont
//This script will generate a series of prim objects as a part of a whole. 
using UnityEngine;
using System.Collections;

public class world : MonoBehaviour {

	public GameObject[,,] chunks;
	int chunkSize =5;
	public GameObject chunk;
	private byte[,,] blocks=new byte[15,15,5];
	void BuildMesh(){

		for (int x=0; x<15; x++){
			for (int y=0; y<15; y++){
				for (int z=0; z<5; z++){
					if(y==0)
						blocks[x,y,z]=2;
					else
						blocks[x,y,z]=0;
				}
			}
		}
		blocks[0,0,0]=1;//the filled in blocks
		blocks[0,0,1]=1;
		blocks[1,1,1]=1;
		blocks[2,3,4]=1;
		blocks[3,3,3]=1;
		
	}
	void Start () {

		chunks= new GameObject[2,2,2];
			for (int x=0; x<chunks.GetLength(0); x++) 
				for (int y=0; y<chunks.GetLength(1); y++) 
					for (int z=0; z<chunks.GetLength(2); z++) {
						chunks [x, y, z] = Instantiate (chunk,
		                          new Vector3 (x * chunkSize - 0.5f, y * chunkSize + 0.5f, z * chunkSize - 0.5f),
		                          new Quaternion (0, 0, 0, 0)) as GameObject;
						chunks [x, y, z].transform.parent=gameObject.transform;
				//blocks[x,y,z]
							}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
