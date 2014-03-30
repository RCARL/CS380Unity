using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Container : MonoBehaviour {

	public Dictionary <string,chunk> chunks= new Dictionary<string,chunk> ();
	int chunkSize =5;
	public Texture chunkTexture;
	public void lostOne()
	{
		if(transform.childCount<=1)
			Destroy(gameObject);
	}

	public chunk createChunk(int x, int y, int z,byte[,,] blocks)
	{
		chunk p;
		if (!chunks.TryGetValue (x + " " + y + " " + z, out p))
			p = createChunk (x, y, z).GetComponent ("chunk") as chunk;

		p.initBlocks (blocks);
		p.updateMesh = true;
		return p;
	}
	public chunk createChunk(int x, int y, int z,int[] i,byte b)
	{
		chunk p;
		if (!chunks.TryGetValue (x + " " + y + " " + z, out p))
			p = createChunk (x, y, z);
		p.initBlocks ();
		p.changeLocalBlock (i [0], i [1], i [2], b);
		p.updateMesh = true;
		return p;
	}
	public void createChunk(int x, int y, int z, byte b)
    {
        chunk p;
        if (!chunks.TryGetValue((x / chunkSize) + " " + (y / chunkSize) + " " + (z / chunkSize), out p))
        {
            p = createChunk(x / chunkSize, y / chunkSize, z / chunkSize);
            p.initBlocks();
        }
        p.changeLocalBlock(x / chunkSize, y / chunkSize, z / chunkSize, b);
        p.updateMesh = true;
    }
	private chunk createChunk(int x,int y, int z)
	{
		GameObject ans = new GameObject (x + " " + y + " " + z);
		//ans.AddComponent<MeshRenderer>();


		ans.transform.parent=gameObject.transform;
		chunk p =ans.AddComponent<chunk> ();

		ans.renderer.material.mainTexture = chunkTexture;		
		chunks.Add (x + " " + y + " " + z, p);
		return p;
	}
	private void divideContainer(HashSet<string> hash)
	{
		print ("divide "+hash.Count());
		IEnumerable<string> query;
		GameObject ans = new GameObject ("new container");
		Container cont= ans.AddComponent<Container>();

		//IEnumerable<string> partials=new HashSet<string> ();

		foreach(string s in chunks.Keys)
		{

			query = hash.Where(f => f.StartsWith(s));
			if(chunks[s].cubeCount==query.Count()){
				chunks[s].transform.parent=ans.transform;
				cont.chunks.Add(ans.gameObject.name,chunks[s]);
				chunks.Remove( ans.gameObject.name);
				hash= new HashSet<string>( hash.Except(query ));
			}



		}

		while(hash.Count()>0){

			string pString= string.Join(" ", hash.ElementAtOrDefault(0).Split(' '),0,3);
			query=	hash.Where(f=>f.StartsWith(pString));
			hash=new HashSet<string>( hash.Except(query));
			GameObject ch=chunks[pString].copyCube(query);

			ch.renderer.material.mainTexture=chunkTexture;
			cont.chunks.Add(ch.name,ch.GetComponent<chunk>());
			//cont.chunks.Add(pString,ch.GetComponent("chunk") as chunk);
			ch.gameObject.transform.parent=cont.transform;
		}

//		foreach(string p in hash)
//		{
//			partials.Add(String.Join(" ",p.Split(' '),0,3));
//		}


	}
	void OnEnable () {
		chunkTexture=Resources.LoadAssetAtPath<Texture>("Assets/voxels/tilesheet.png") ;
		Rigidbody rig= gameObject.AddComponent<Rigidbody> ();
		rig.useGravity=false;
		rig.mass=1000;
	}
	PriorityQueue<float,int[]> frontier;
	HashSet<string> contiguous;
	public void checkIntegrity(int xb ,int yb, int yz, int x, int y, int z)
	{
		int[] i;
		List<int[]> newFrontier;
		contiguous = new HashSet<string>();
		frontier = new PriorityQueue<float,int[]>();
		List<int[]>parents = getParents(new int[]{xb,yb,yz, x,y,z});
		List<int[]>.Enumerator e = parents.GetEnumerator();
		e.MoveNext();
		frontier.Enqueue(1f,e.Current);
		while(e.MoveNext())
		{
			while(!contiguous.Contains(iaToString(e.Current))){
				if(frontier.IsEmpty)
				{
					print("discontinuous "+contiguous.Count());
					//e.MoveNext();
					frontier.Enqueue(1f,e.Current);
					//highLightContig(contiguous,4);
					divideContainer(contiguous);
					contiguous.Clear();
					break;
				}
				i=frontier.Dequeue();
				contiguous.Add(iaToString(i));
				newFrontier=getParents(i);
				foreach(int[] j in newFrontier)
					if(!contiguous.Contains(iaToString(j)))
						frontier.Enqueue(heur(j,e.Current),j);
			}
		}
		//highLightContig(contiguous,5);
	}
	private string iaToString(int[]a)
	{
		return a[0]+" "+a[1]+" "+a[2]+" "+a[3]+" "+a[4]+" "+a[5];
	}
	private void highLightContig(IEnumerable<string> ha,byte b)
	{
		string []i;
		foreach(string j in ha)
		{
			i=j.Split(' ');
			chunks[i[0]+" "+i[1]+" "+i[2]].changeLocalBlock(int.Parse(i[3]),int.Parse(i[4]),int.Parse(i[5]),b);
		}
	}
	private float heur(int[] pos,int[] goal)
	{
		float d=Mathf.Abs((pos[0]-goal[0])*chunkSize)+Mathf.Abs(pos[3]-goal[3]);
		d+=Mathf.Abs((pos[1]-goal[1])*chunkSize)+Mathf.Abs(pos[4]-goal[4]);
		d+=Mathf.Abs((pos[2]-goal[2])*chunkSize)+Mathf.Abs(pos[5]-goal[5]);
		return d;
	}
	private List<int[]> getParents(int[] pos)
	{
//		int[] xinc=new int[]{0,0,0,1,0,0};
//		int[] yinc=new int[]{0,0,0,0,1,0};
//		int[] zinc=new int[]{0,0,0,0,0,1};
//		int[] cxinc=new int[]{1,0,0,-chunksize,0,0];
		//print ("p "+iaToString(pos));
		List<int[]> parents = new List<int[]>();
		#region x
		try { 
		if (pos[3] > 0)
		{
			if (chunks[pos[0]+ " " + pos[1] + " " + pos[2]].getBlocks[pos[3] -1, pos[4], pos[5]]!=0)
				parents.Add(new int[] { pos[0] , pos[1], pos[2], pos[3] -1, pos[4], pos[5] });
		}
		else
			if (chunks[(pos[0] -1) + " " + pos[1] + " " + pos[2]].getBlocks[pos[3] +  chunkSize-1, pos[4], pos[5]]!=0)
				parents.Add(new int[] { pos[0] -1, pos[1], pos[2], pos[3] + chunkSize-1, pos[4], pos[5] });
		}
		catch (KeyNotFoundException) { }
		catch (NullReferenceException) { }

		try { 
		if(pos[3]<chunkSize-1){
			if (chunks[(pos[0])+" "+pos[1]+" "+pos[2]].getBlocks[pos[3]+1, pos[4], pos[5]] != 0)
				parents.Add(new int[] { pos[0], pos[1], pos[2], pos[3] +1, pos[4], pos[5] });	
		}
		else		
			if (chunks[(pos[0] + 1) + " " + pos[1] + " " + pos[2]].getBlocks[pos[3] -  chunkSize+1, pos[4], pos[5]] != 0)
				parents.Add(new int[] { pos[0] + 1, pos[1], pos[2], pos[3] - chunkSize+1, pos[4], pos[5] });
		}
		catch (KeyNotFoundException) { }
		catch (NullReferenceException) { }
		#endregion
		#region y
		try{
		if (pos[4]>0) 
		{
			if (chunks[ pos[0]  + " " + pos[1] + " " + pos[2]].getBlocks[pos[3], pos[4]-1, pos[5]] != 0)
				parents.Add(new int[] { pos[0] , pos[1], pos[2], pos[3] , pos[4]-1, pos[5] });
		}
		else
			if (chunks[ pos[0]  + " " + (pos[1]-1) + " " + pos[2]].getBlocks[pos[3], pos[4]+chunkSize-1, pos[5]] != 0)
				parents.Add(new int[] { pos[0] , pos[1]-1, pos[2], pos[3] , pos[4]+chunkSize-1, pos[5] });
		}
		catch (KeyNotFoundException) { }
		catch (NullReferenceException) { }
		try{
		if (pos[4] < chunkSize-1){
			if (chunks[ pos[0]  + " " + pos[1] + " " + pos[2]].getBlocks[pos[3], pos[4]+1, pos[5]] != 0)
				parents.Add(new int[] { pos[0] , pos[1], pos[2], pos[3] , pos[4]+1, pos[5] });
		}
		else
		
			if (chunks[ pos[0]  + " " + (pos[1]+1) + " " + pos[2]].getBlocks[pos[3], pos[4]-chunkSize+1, pos[5]] != 0)
				parents.Add(new int[] { pos[0] , pos[1]+1, pos[2], pos[3] , pos[4]-chunkSize+1, pos[5] });
		}
		catch (KeyNotFoundException) { }
		catch (NullReferenceException) { }
		#endregion
		#region z
		try
		{
		if (pos[5] > 0){
			if (chunks[pos[0] + " " + pos[1] + " " + pos[2]].getBlocks[pos[3], pos[4], pos[5]-1] != 0)
				parents.Add(new int[] { pos[0], pos[1], pos[2], pos[3], pos[4], pos[5] -1 });
			}
		else
		
			if (chunks[pos[0] + " " + pos[1] + " " + (pos[2] - 1)].getBlocks[pos[3], pos[4], pos[5] + chunkSize-1] != 0)
				parents.Add(new int[] { pos[0], pos[1], pos[2] - 1, pos[3], pos[4], pos[5] + chunkSize-1 });
		}
		catch (KeyNotFoundException) { }
		catch (NullReferenceException) { }
		try { 
		if (pos[5] < chunkSize-1)
		{
			if (chunks[pos[0] + " " + pos[1] + " " + pos[2]].getBlocks[pos[3], pos[4], pos[5] +1] != 0)
				parents.Add(new int[] { pos[0], pos[1], pos[2], pos[3], pos[4] , pos[5] +1});
		}
		else
		
			if (chunks[pos[0] + " " + pos[1] + " " + (pos[2]+1)].getBlocks[pos[3], pos[4], pos[5] - chunkSize+1] != 0)
				parents.Add(new int[] { pos[0], pos[1], pos[2] + 1, pos[3], pos[4] , pos[5] - chunkSize+1});
		}
		catch (KeyNotFoundException) { }
		catch (NullReferenceException) { }
		#endregion
		return parents;
	}
}
