using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class chunk : MonoBehaviour {
	/// <summary>
	/// anything anded with this will not allow voxels but will not be contiguous
	/// </summary>
	private const  byte cMask=0x7f;
	// This first list contains every vertex of the mesh that we are going to render
	public List<Vector3> newVertices = new List<Vector3>();
	private byte[,,] blocks;
	/// <summary>
	/// Gets the get Masked blocks.
	/// </summary>
	/// <value>The get M blocks.</value>
	/// 
	
	public byte[, ,] getBlocks
	{
		get { return blocks; }
	}
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
	public int _cubeCount=0;
	public int cubeCount{
		get{return _cubeCount;}
	}
	private int[] _chunkSpot;
	/// <summary>
	/// represents the xyz coordinates of this chunk object in the whole
	/// </summary>
	/// <value>The chunk spot.</value>
	public int[] chunkSpot{
		get{
			if(_chunkSpot==null){
				string[] c = gameObject.name.Split (' ');
				_chunkSpot = new int[]{int.Parse(c [0]),int.Parse (c [1]),int.Parse (c [2])};
			}
			return _chunkSpot;
		}
	}
	
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
	private List<string> getLocalParents(int[]spot)
	{
		
		List<string> ans= new List<string>();
		if(spot[0]!=0)
			if((blocks[spot[0]-1,spot[1],spot[2]]&cMask)!=0)
				ans.Add((spot[0]-1)+" "+spot[1]+" "+spot[2]);
		if(spot[0]!=(chunkSize-1))
			if((blocks[spot[0]+1,spot[1],spot[2]]&cMask)!=0)
				ans.Add((spot[0]+1)+" "+spot[1]+" "+spot[2]);
		
		
		if(spot[1]!=0)
			if((blocks[spot[0],spot[1]-1,spot[2]]&cMask)!=0)
				ans.Add(spot[0]+" "+(spot[1]-1)+" "+spot[2]);
		
		if(spot[1]!=(chunkSize-1))
			if((blocks[spot[0],spot[1]+1,spot[2]]&cMask)!=0)
				
				ans.Add(spot[0]+" "+(spot[1]+1)+" "+spot[2]);
		
		if(spot[2]!=0)
			if((blocks[spot[0],spot[1],spot[2]-1]&cMask)!=0)
				
				ans.Add(spot[0]+" "+spot[1]+" "+(spot[2]-1));
		
		if(spot[2]!=(chunkSize-1))
			if((blocks[spot[0],spot[1],spot[2]+1]&cMask)!=0)
				ans.Add(spot[0]+" "+spot[1]+" "+(spot[2]+1));
		return ans;
		
	}
	private int[] findLeast()
	{
		
		
		int []temp;
		
		
		temp=findLeast(0);//3
		if(temp[0]!=-1)
			return temp;
		temp=findLeast(0,1);//1
		if(temp[0]!=-1)
			return temp;
		temp=findLeast(1,0);//2
		if(temp[0]!=-1)
			return temp;
		
		temp=findLeast(0,2);//2
		if(temp[0]!=-1)
			return temp;
		
		
		
		temp=findLeast(0,3);//3
		if(temp[0]!=-1)
			return temp;
		temp=findLeast(0,1,2);//3
		if(temp[0]!=-1)
			return temp;
		temp=findLeast(0,4);//4
		if(temp[0]!=-1)
			return temp;
		temp=findLeast(2,0);//4
		if(temp[0]!=-1)
			return temp;
		temp=findLeast(1,2);//4
		if(temp[0]!=-1)
			return temp;
		temp=findLeast(3,1,0);//4
		if(temp[0]!=-1)
			return temp;
		
		return new int[]{ -1};
	}
	private int[] findLeast(int x)
	{
		int X=(chunkSpot[0]>>32)|1;
		int Y=(chunkSpot[1]>>32)|1;
		int Z=(chunkSpot[2]>>32)|1;
		int[] temp = orCord(new int[] { (x + 1) * X, (x + 1) * Y, (x + 1) * Z }).ToArray();
		//print ("ored "+gameObject.name+"  "+temp[0]+" " +temp[1]+" "+temp[2]);
		if((blocks[temp[0],temp[1],temp[2]]&cMask)!=0)
			return temp;
		return new int[]{-1};
	}
	/// <summary>
	/// Orients the corrdinate toward chunkspot[0,0,0]. does not work on a distance 4
	/// </summary>
	/// <returns>The cord.</returns>
	/// <param name="a">The alpha component.</param>
	private  IEnumerable<int> orCord(int[] a)
	{
		int j;
		for (int i = 0; i < 3; i++)
		{
			j = (a[i] + chunkSize) / chunkSize;
			yield return (a[i] + chunkSize) % (chunkSize)-j;
		}
	}
	private int[] findLeast(int x,int y)
	{
		int X=(chunkSpot[0]>>32)|1;
		int Y=(chunkSpot[1]>>32)|1;
		int Z=(chunkSpot[2]>>32)|1;
		int[] temp = orCord(new int[] { (x + 1) * X, (x + 1) * Y, (y + 1) * Z }).ToArray();
		
		if((blocks[temp[0],temp[1],temp[2]]&cMask)!=0)
			return temp;
		temp = orCord(new int[] { (x + 1) * X, (y + 1) * Y, (x + 1) * Z }).ToArray();
		if((blocks[temp[0],temp[1],temp[2]]&cMask)!=0)
			return temp;
		temp = orCord(new int[] { (y + 1) * X, (x + 1) * Y, (x + 1) * Z }).ToArray();
		
		
		if((blocks[temp[0],temp[1],temp[2]]&cMask)!=0)
			return temp;
		return new int[]{-1};
	}
	private int[] findLeast(int x,int y, int z)
	{
		int X=(chunkSpot[0]>>32)|1;
		int Y=(chunkSpot[1]>>32)|1;
		int Z=(chunkSpot[2]>>32)|1;
		int[]temp = orCord(new int[] { (x + 1) * X, (y + 1) * Y, (z + 1) * Z }).ToArray();
		
		if((blocks[temp[0],temp[1],temp[2]]&cMask)!=0)
			return temp;
		temp = orCord(new int[] { (y + 1) * X, (x + 1) * Y, (z + 1) * Z }).ToArray();
		
		if((blocks[temp[0],temp[1],temp[2]]&cMask)!=0)
			return temp;
		temp = orCord(new int[] { (y + 1) * X, (z + 1) * Y, (x + 1) * Z }).ToArray();
		
		if((blocks[temp[0],temp[1],temp[2]]&cMask)!=0)
			return temp;
		temp = orCord(new int[] { (z + 1) * X, (y + 1) * Y, (x + 1) * Z }).ToArray();
		
		if((blocks[temp[0],temp[1],temp[2]]&cMask)!=0)
			return temp;
		temp = orCord(new int[] { (z + 1) * X, (x + 1) * Y, (y + 1) * Z }).ToArray();
		
		if((blocks[temp[0],temp[1],temp[2]]&cMask)!=0)
			return temp;
		temp = orCord(new int[] { (x + 1) * X, (z + 1) * Y, (y + 1) * Z }).ToArray();
		
		if((blocks[temp[0],temp[1],temp[2]]&cMask)!=0)
			return temp;
		return new int[]{-1};
	}
	public void makeContig()
	{
		makeContig(findLeast());
	}
	public void makeContig(int[] st)
	{
		if(st[0]==-1)
			return;
		//print ("from "+gameObject.name+" least: "+st[0]+" "+st[1]+" "+st[2]);
		
		
		string i;
		List<string> newFrontier;
		HashSet<string> contiguous = new HashSet<string>();
		HashSet<string> frontier = new HashSet<string>();
		
		frontier.Add(itos( st));
		if(((st[0]!=-1)&&(blocks[st[0],st[1],st[2]]&cMask)!=0))
		while(frontier.Count!=0){
			i=frontier.FirstOrDefault();
			frontier.Remove(i);
			contiguous.Add(i);
			newFrontier=getLocalParents(stoi(i));
			foreach(string j in newFrontier)
				if(!contiguous.Contains( j))
					frontier.Add(j);
		}
		else{
			print (chunkSpot[0]+" "+chunkSpot[1]+" "+chunkSpot[2]+ "can't make contig");
			return;
		}
		trimCube(contiguous);
	}
	private string itos(int[]a)
	{
		return a[0]+" "+a[1]+" "+a[2];
	}
	private int[]stoi(string a)
	{
		string[] b=a.Split(' ');
		return new int[]{int.Parse(b[0]),int.Parse(b[1]),int.Parse(b[2])};
	}
	private void trimCube(HashSet<string> hash)
	{
		_cubeCount=0;
		for(int x=0;x<chunkSize;x++)
			for(int y=0;y<chunkSize;y++)
				for(int z=0;z<chunkSize;z++)
			{	
				if(!hash.Contains(x+" "+y+" "+z))
				{
					blocks[x,y,z]=0;
					
				}
				if(blocks[x,y,z]!=0)
					
					_cubeCount++;
				
				
				
			}
		
		
		
	}
	public GameObject copyCube(IEnumerable<string>  other)
	{
		GameObject g=new GameObject(gameObject.name);
		
		chunk p =g.AddComponent <chunk>();
		p.renderer.material.mainTexture= renderer.material.mainTexture;
		p.initBlocks();
		foreach(string istr in other){
			string[]i=istr.Split(' ');
			byte b=blocks[int.Parse(i[3]),int.Parse(i[4]),int.Parse(i[5])];
			p.changeLocalBlock(int.Parse(i[3]),int.Parse(i[4]),int.Parse(i[5]),b);
			blocks[int.Parse(i[3]),int.Parse(i[4]),int.Parse(i[5])]=0;
		}
		return g;
		
	}
	#region CubeFace
	void CubeTop(int x, int y,int z){
		if(y!=(chunkSize-1))
			if ((blocks [x, y + 1, z]&cMask )!= 0)//Block above is not air
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
		
		Vector2 texture=  new Vector2(blocks[x,y,z]&cMask%4,blocks[x,y,z]&cMask/4);
		
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	void CubeNorth(int x, int y,int z){
		if(z!=(chunkSize-1))
			if((blocks[x,y,z+1]&cMask)!=0)//Block north is not air
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
		
		Vector2 texture=  new Vector2(blocks[x,y,z]&cMask%4,blocks[x,y,z]&cMask/4);
		
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	void CubeEast(int x, int y,int z){
		
		
		if(x!=(chunkSize-1))
			if ((blocks [x + 1, y, z]&cMask) != 0)//Block east is not air
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
		
		Vector2 texture=  new Vector2(blocks[x,y,z]&cMask%4,blocks[x,y,z]&cMask/4);
		
		
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	void CubeSouth(int x, int y,int z){
		if(z!=0)
			if ((blocks [x, y, z - 1]&cMask) != 0)//Block south is not air
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
		
		Vector2 texture=  new Vector2(blocks[x,y,z]&cMask%4,blocks[x,y,z]&cMask/4);
		
		
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	void CubeWest(int x, int y,int z){
		if(x!=0)
			if ((blocks [x - 1, y, z]&cMask) != 0)//Block west is not air
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
		
		Vector2 texture=  new Vector2(blocks[x,y,z]&cMask%4,blocks[x,y,z]&cMask/4);
		
		
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y + tUnit));
		newUV.Add(new Vector2 (tUnit*texture.x+tUnit, tUnit*texture.y+tUnit));
		newUV.Add(new Vector2 (tUnit * texture.x + tUnit, tUnit * texture.y));
		newUV.Add(new Vector2 (tUnit * texture.x, tUnit * texture.y));
		
		squareCount++;
		
	}
	void CubeBot(int x, int y,int z){
		if(y!=0)
			if ((blocks [x, y - 1, z]&cMask) != 0)//Block below is not air
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
		
		Vector2 texture=  new Vector2(blocks[x,y,z]&cMask%4,blocks[x,y,z]&cMask/4);
		
		
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
					
					if((blocks[x,y,z]&cMask)!=0){//If the block is solid
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
	public void initBlocks(byte [,,]newChunk)
	{
		blocks=newChunk;
		_cubeCount=0;
		foreach(byte b in blocks)
		{
			if(b!=0)
				_cubeCount++;
		}
	}
	
	void Awake () {
		
		mesh= gameObject.AddComponent<MeshFilter>().mesh;
		col=gameObject.AddComponent<MeshCollider>();
		col.sharedMesh=null;
		gameObject.AddComponent<MeshRenderer>();
		col.convex = true;
		
		
	}
	void Start()
	{
		
		string[] splat=gameObject.name.Split(' ');
		transform.localPosition = new Vector3 (int.Parse(splat[0]) * chunkSize - 0.5f, int.Parse(splat[1]) * chunkSize + 0.5f, int.Parse(splat[2]) * chunkSize - 0.5f);
		transform.localRotation = new Quaternion (0, 0, 0, 0);
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
		if (i >= chunkSize)
			return 1;
		return 0;
	}
	/// <summary>
	/// Rounds and removes or adds block.
	/// </summary>
	/// <param name="pos">position in localspace of block - normal value adjustment.</param>
	/// <param name="block">block type.</param>
	int[] RoundAndRmBlock(Vector3 pos,byte block)
	{
		//print (pos.ToString ());
		int x, y, z,i;
		x = Mathf.FloorToInt(pos.x) ;
		y = Mathf.FloorToInt(pos.y+1) ;
		z = Mathf.FloorToInt(pos.z) ;
		i = checkVal (x);
		if (i != 0) {
			return (transform.parent.GetComponent ("Container") as Container)
				.createChunk (chunkSpot [0] + i, chunkSpot [1], chunkSpot [2], new int[]{x-(i*chunkSize) ,y,z},block);
			
		}
		i = checkVal (y);
		if (i != 0){
			return (transform.parent.GetComponent ("Container") as Container)
				.createChunk (chunkSpot [0] , chunkSpot [1]+ i, chunkSpot [2], new int[]{x,y-(i*chunkSize),z},block);
		}
		i = checkVal (z);
		if (i != 0){
			return (transform.parent.GetComponent ("Container") as Container)
				.createChunk (chunkSpot [0] , chunkSpot [1], chunkSpot [2]+ i, new int[]{x,y,z-(i*chunkSize)},block);
		}
		changeLocalBlock(x,y,z,block);
		return new int[]{x,y,z};
		
	}
	
	public IEnumerable<int[]> getSparse()
	{
		List<int[]> ans =new List<int[]>();
		for(int x=0;x<chunkSize;x++)
			for(int y=0;y<chunkSize;y++)
				for(int z=0;z<chunkSize;z++)
					if(blocks[x,y,z]!=0)
						ans.Add(new int[]{chunkSpot[0],chunkSpot[1],chunkSpot[2],x,y,z});
		return ans;
	}
	public  void changeLocalBlock(int x, int y, int z, byte block)
	{
		byte original = blocks [x, y, z];
		if ((cMask & original) != original ) {
			print ("can't build there");	
			return;
		}
		//print("change Local block" + x + " " + y + " " + z+" "+block);
		//	if(blocks[x,y,z]!=0)
		//		_cubeCount--;
		
		blocks [x, y, z] =block;
		updateMesh = true;
		if(block==0&&original!=0){
			_cubeCount--;
			transform.parent.GetComponent<Container> () .checkIntegrity(chunkSpot[0],chunkSpot[1],chunkSpot[2], x, y, z);
			if(_cubeCount==0){
				Destroy(gameObject);
				transform.parent.GetComponent<Container> ().lostOne(chunkSpot);
			}
		}
		else if(block!=0&&original==0)
			_cubeCount++;
		
	}
	/// <summary>
	/// method called when this gameobject is hit by ray
	/// </summary>
	/// <param name="hit">raycast hit with position info.</param>
	/// <param name="block">blocktype to be added
	/// .</param>
	public void ReplaceBlockCursor(RaycastHit hit,Artificial a)
	{	
		Vector3 fdNormal;
		if(a.symbol==0)//moves hit based on normal value from polygon
			fdNormal = new Vector3 (-0.5f*hit.normal.x, -0.5f*hit.normal.y, -0.5f*hit.normal.z);
		else
			fdNormal = new Vector3 (0.5f*hit.normal.x, 0.5f*hit.normal.y, 0.5f*hit.normal.z);
		//send in vector3 adjusted to localspace and from above normal value
		int[] pos= RoundAndRmBlock(gameObject.transform.InverseTransformPoint( hit.point+fdNormal),a.symbol);
		addModel (pos, a.model);
	}
	void UpdateLast()
	{
		if (updateMesh) {
			if(_cubeCount==0){
				Destroy(gameObject);
				transform.parent.GetComponent<Container> ().lostOne(chunkSpot);
			}
			GenerateMesh();
			UpdateMesh ();
			
			updateMesh=false;
		}
	}
	// Update is called once per frame
	void Update () {
		
		UpdateLast ();
	}
	public void addModel(int[] pos,string model)
	{
		if (pos.Length != 3) 
						transform.parent.GetComponent<Container> ().chunks [pos [0] + " " + pos [1] + " " + pos [2]]
			.addModel (new int[]{pos [3],pos [4],pos [5]},model);
		else {
			GameObject g= Resources.LoadAssetAtPath<GameObject>(model);	
			g.transform.parent=transform;
			g.transform.position=new Vector3(pos[0],pos[1],pos[2]);
		}

	}
	/// <summary>
	/// uses raycasting to shoot at a cube
	/// </summary>
	public static void editCube(Artificial a)
	{
		RaycastHit hit;
		MeshCollider first;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray,out hit,100)){
			
			first= hit.collider.GetComponent<MeshCollider>();
			first.convex=false;
			if (Physics.Raycast(ray,out hit,100))
			{
				
				first.convex=true;
				hit.collider.GetComponent<MeshCollider>().convex=true;
				
				hit.collider.GetComponent<chunk>().ReplaceBlockCursor(hit,a);
		

			}
		}
	}
}
