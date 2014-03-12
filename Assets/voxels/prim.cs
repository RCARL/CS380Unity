//Stephen DuMont
//generates voxels edit the buildMesh() method to get a different mesh
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class prim : MonoBehaviour {
	// This first list contains every vertex of the mesh that we are going to render
	public List<Vector3> newVertices = new List<Vector3>();
	public byte[,,] blocks;
	// The triangles tell Unity how to build each section of the mesh joining
	// the vertices
	public List<int> newTriangles = new List<int>();
	
	// The UV list is unimportant right now but it tells Unity how the texture is
	// aligned on each polygon
	public List<Vector2> newUV = new List<Vector2>();
	private float tUnit = 0.25f;
	private Mesh mesh;
	private MeshCollider col;
	private int squareCount;
	public bool updateMesh=false;
	public int chunkSize=5;


	void UpdateMesh () {
		mesh.Clear ();
		mesh.vertices = newVertices.ToArray();
		mesh.triangles = newTriangles.ToArray();
		mesh.uv = newUV.ToArray();
		mesh.Optimize ();
		mesh.RecalculateNormals ();

		squareCount=0;
		newVertices.Clear();
		newTriangles.Clear();
		newUV.Clear();
		
		col.sharedMesh=null;
		col.sharedMesh=mesh;
	}
	#region CubeFace
	void CubeTop(int x, int y,int z){
		if(y!=(chunkSize-1))
			if (blocks [x, y + 1, z] != 0)//Block above is not air
				return;


		newVertices.Add(new Vector3 ((float)x,  (float)y,  (float)z + 1));
		newVertices.Add(new Vector3 ((float)x + 1, (float)y,  (float)z + 1));
		newVertices.Add(new Vector3 (x + 1, y,  z ));
		newVertices.Add(new Vector3 (x,  y,  z ));
		
		newTriangles.Add(squareCount*4);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+3);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+2);
		newTriangles.Add((squareCount*4)+3);

		Vector2 texture=  new Vector2(blocks[x,y,z]%4,blocks[x,y,z]/4);

		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	void CubeNorth(int x, int y,int z){
		if(z!=(chunkSize-1))
			if(blocks[x,y,z+1]!=0)//Block north is not air
				return;
		newVertices.Add(new Vector3 ((float)x + 1, (float)y-1, (float)z + 1));
		newVertices.Add(new Vector3 ((float)x + 1, (float)y, (float)z + 1));
		newVertices.Add(new Vector3 ((float)x, (float)y, (float)z + 1));
		newVertices.Add(new Vector3 ((float)x, (float)y-1, (float)z + 1));
		
		newTriangles.Add(squareCount*4);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+3);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+2);
		newTriangles.Add((squareCount*4)+3);

		Vector2 texture=  new Vector2(blocks[x,y,z]%4,blocks[x,y,z]/4);

		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	void CubeEast(int x, int y,int z){
		

		if(x!=(chunkSize-1))
			if (blocks [x + 1, y, z] != 0)//Block east is not air
					return;

		newVertices.Add(new Vector3 ((float)x + 1, (float)y - 1, (float)z));
		newVertices.Add(new Vector3 ((float)x + 1, (float)y, (float)z));
		newVertices.Add(new Vector3 ((float)x + 1, (float)y, (float)z + 1));
		newVertices.Add(new Vector3 ((float)x + 1, (float)y - 1, (float)z + 1));
		
		newTriangles.Add(squareCount*4);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+3);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+2);
		newTriangles.Add((squareCount*4)+3);
		
		Vector2 texture=  new Vector2(blocks[x,y,z]%4,blocks[x,y,z]/4);
		

		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	void CubeSouth(int x, int y,int z){
		if(z!=0)
			if (blocks [x, y, z - 1] != 0)//Block south is not air
				return;


		newVertices.Add(new Vector3 ((float)x, (float)y - 1, (float)z));
		newVertices.Add(new Vector3 ((float)x, (float)y, (float)z));
		newVertices.Add(new Vector3 ((float)x + 1, (float)y, (float)z));
		newVertices.Add(new Vector3 ((float)x + 1, (float)y - 1, (float)z));
		
		newTriangles.Add(squareCount*4);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+3);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+2);
		newTriangles.Add((squareCount*4)+3);
		
		Vector2 texture=  new Vector2(blocks[x,y,z]%4,blocks[x,y,z]/4);
		

		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	void CubeWest(int x, int y,int z){
		if(x!=0)
			if (blocks [x - 1, y, z] != 0)//Block west is not air
					return;


		newVertices.Add(new Vector3 ((float)x, (float)y- 1,(float) z + 1));
		newVertices.Add(new Vector3 ((float)x, (float)y,(float) z + 1));
		newVertices.Add(new Vector3 ((float)x,(float) y, (float)z));
		newVertices.Add(new Vector3 ((float)x, (float)y - 1, (float)z));
		
		newTriangles.Add(squareCount*4);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+3);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+2);
		newTriangles.Add((squareCount*4)+3);
		
		Vector2 texture=  new Vector2(blocks[x,y,z]%4,blocks[x,y,z]/4);
		

		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	void CubeBot(int x, int y,int z){
		if(y!=0)
			if (blocks [x, y - 1, z] != 0)//Block below is not air
					return;


		newVertices.Add(new Vector3 ((float)x,  (float)y-1, (float) z ));
		newVertices.Add(new Vector3 ((float)x + 1, (float)y-1, (float) z ));
		newVertices.Add(new Vector3 ((float)x + 1, (float)y-1, (float) z + 1));
		newVertices.Add(new Vector3 ((float)x,  (float)y-1,  (float)z + 1));
		
		newTriangles.Add(squareCount*4);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+3);
		newTriangles.Add((squareCount*4)+1);
		newTriangles.Add((squareCount*4)+2);
		newTriangles.Add((squareCount*4)+3);
		
		Vector2 texture=  new Vector2(blocks[x,y,z]%4,blocks[x,y,z]/4);
		

		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	#endregion


	void GenerateMesh(){
		
		for (int x=0; x<chunkSize; x++){
			for (int y=0; y<chunkSize; y++){
				for (int z=0; z<chunkSize; z++){
					//This code will run for every block in the chunk
					
					if(blocks[x,y,z]!=0){//If the block is solid
						CubeTop(x,y,z);
						CubeBot(x,y,z);
						CubeEast(x,y,z);
						CubeWest(x,y,z);
						CubeNorth(x,y,z);
						CubeSouth(x,y,z);

					}
				}
			}
		}
	}
	public void initBlocks()
	{
		if (blocks != null)
						return;
		blocks=new byte[chunkSize,chunkSize,chunkSize];
		for (int i=0; i<chunkSize; i++)
						for (int j=0; j<chunkSize; j++)
								for (int k=0; k<chunkSize; k++)
										blocks [i, j, k] = 0;

	}
	void Start () {
		initBlocks ();
		mesh=GetComponent<MeshFilter> ().mesh;
		col = GetComponent<MeshCollider> ();
		col.sharedMesh=null;
		//BuildMesh();
		GenerateMesh();
		UpdateMesh();
	}
	/// <summary>
	///determine if block is added to another chunk
	/// </summary>
	/// <returns>The value.</returns>
	/// <param name="i">The index.</param>
	int checkVal(int i)
	{
		if (i < 0)
			return -1;
		if (i > chunkSize)
			return 1;
		return 0;
	}
	/// <summary>
	/// Rounds the and removes or adds block.
	/// </summary>
	/// <param name="pos">position in localspace of block - normal value adjustment.</param>
	/// <param name="block">block type.</param>
	void RoundAndRmBlock(Vector3 pos,byte block)
	{
		print (pos.ToString ());
		int x, y, z,i;
		x = Mathf.FloorToInt(pos.x) ;
		y = Mathf.FloorToInt(pos.y+1) ;
		z = Mathf.FloorToInt(pos.z) ;
		i = checkVal (x);
		if (i != 0) {
			string[] c = gameObject.name.Split (' ');
			int[] chunkSpot = new int[]{int.Parse(c [0]),int.Parse (c [1]),int.Parse (c [2])};

			(transform.parent.GetComponent ("world") as world)
				.createChunk (chunkSpot [0] + i, chunkSpot [1], chunkSpot [2], new int[]{x-(i*chunkSize) ,y,z},block);
				return;
				}
		i = checkVal (y);
		if (i != 0){
			string[] c = gameObject.name.Split (' ');
			int[] chunkSpot = new int[]{int.Parse(c [0]),int.Parse (c [1]),int.Parse (c [2])};

			(transform.parent.GetComponent ("world") as world)
				.createChunk (chunkSpot [0] , chunkSpot [1]+ i, chunkSpot [2], new int[]{x,y-(i*chunkSize),z},block);
			return;
		}
		i = checkVal (z);
		if (i != 0){
			string[] c = gameObject.name.Split (' ');
			int[] chunkSpot = new int[]{int.Parse(c [0]),int.Parse (c [1]),int.Parse (c [2])};

			(transform.parent.GetComponent ("world") as world)
				.createChunk (chunkSpot [0] , chunkSpot [1], chunkSpot [2]+ i, new int[]{x,y,z-(i*chunkSize)},block);
			return;
		}

		print (x+" "+ y+" "+ z);
		blocks [x, y, z] =block;
		updateMesh = true;
	}
/// <summary>
/// method called when this gameobject is hit by ray
	/// </summary>
/// <param name="hit">raycast hit with position info.</param>
/// <param name="block">blocktype to be added
	/// .</param>
	public void ReplaceBlockCursor(RaycastHit hit,byte block)
	{	
		Vector3 fdNormal;
		if(block==0)//moves hit based on normal value from polygon
			fdNormal = new Vector3 (-0.5f*hit.normal.x, -0.5f*hit.normal.y, -0.5f*hit.normal.z);
		else
			fdNormal = new Vector3 (0.5f*hit.normal.x, 0.5f*hit.normal.y, 0.5f*hit.normal.z);
		//send in vector3 adjusted to localspace and from above normal value
		RoundAndRmBlock(gameObject.transform.InverseTransformPoint( hit.point+fdNormal),block);

	}
	void UpdateLast()
	{
		if (updateMesh) {
			GenerateMesh();
			UpdateMesh ();
			updateMesh=false;
		}
	}
	// Update is called once per frame
	void Update () {

		UpdateLast ();
	}
}
