using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {
	
	
	
	public GameObject iron;
	public GameObject copper;
	public GameObject beryllium;
	public GameObject silver;
	public GameObject titanium;
	public GameObject platinum;
	public GameObject uranium;
	public GameObject plutonium;
	
	public float experience = 0.0f;
	
	void respawnCopper(GameObject o,int c,int d){
		o = GameObject.CreatePrimitive(PrimitiveType.Cube);
		o.AddComponent<Rigidbody> ();
		o.tag = "copper";
		
		for (int a= 0; a< c; a++) {
			for (int b= 0; b<d; b++) {
				
				o.transform.position = new Vector3 (a, b, 0);
				o.renderer.material.color = Color.red;
				
			}
			
		}
		
	}
	void respawnSilver(GameObject o,int c,int d){
		o = GameObject.CreatePrimitive(PrimitiveType.Cube);
		o.AddComponent<Rigidbody> ();
		o.tag = "silver";
		
		for (int a= 0; a< c; a++) {
			for (int b= 0; b<d; b++) {
				
				o.transform.position = new Vector3 (a, b, 0);
				o.renderer.material.color = Color.blue;
			}
		}
		
	}
	
	void respawnIron(GameObject o,int c,int d){
		o = GameObject.CreatePrimitive(PrimitiveType.Cube);
		o.AddComponent<Rigidbody> ();
		o.tag = "iron";
		
		for (int a= 0; a< c; a++) {
			for (int b= 0; b<d; b++) {
				
				o.transform.position = new Vector3 (a, b, 0);
				o.renderer.material.color = Color.gray;
			}
		}
	}
	void respawnBeryllium(GameObject o,int c,int d){
		o = GameObject.CreatePrimitive(PrimitiveType.Cube);
		o.AddComponent<Rigidbody> ();
		o.tag = "beryllium";
		
		for (int a= 0; a< c; a++) {
			for (int b= 0; b<d; b++) {
				
				o.transform.position = new Vector3 (a, b, 0);
				o.renderer.material.color = Color.cyan;
			}
		}
	}
	void respawnTitanium(GameObject o,int c,int d){
		o = GameObject.CreatePrimitive(PrimitiveType.Cube);
		o.AddComponent<Rigidbody> ();
		o.tag = "titanium";
		
		for (int a= 0; a< c; a++) {
			for (int b= 0; b<d; b++) {
				
				o.transform.position = new Vector3 (a, b, 0);
				o.renderer.material.color = Color.yellow;
			}
		}
	}
	void respawnPlatinum(GameObject o,int c,int d){
		o = GameObject.CreatePrimitive(PrimitiveType.Cube);
		o.AddComponent<Rigidbody> ();
		o.tag = "platinum";
		
		for (int a= 0; a< c; a++) {
			for (int b= 0; b<d; b++) {
				
				o.transform.position = new Vector3 (a, b, 0);
				o.renderer.material.color = Color.clear;
			}
		}
		o.tag = "platinum";
	}
	void respawnUranium(GameObject o,int c,int d){
		o = GameObject.CreatePrimitive(PrimitiveType.Cube);
		o.AddComponent<Rigidbody> ();
		o.tag = "uranium";
		
		for (int a= 0; a< c; a++) {
			for (int b= 0; b<d; b++) {
				
				o.transform.position = new Vector3 (a, b, 0);
				o.renderer.material.color = Color.black;
			}
		}
	}
	void respawnPlutonium(GameObject o,int c,int d){
		o = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//copper_clone = (GameObject)Instantiate(copper, transform.position, Quaternion.identity);
		
		o.AddComponent<Rigidbody> ();
		o.tag = "plutonium";
		
		for (int a= 0; a< c; a++) {
			for (int b= 0; b<d; b++) {
				
				o.transform.position = new Vector3 (a, b, 0);
				o.renderer.material.color = Color.magenta;
				
			}
		}
		
	}
	
	//Just change the parameters to where ever you want to spawn the ores
	void Start () {
		
		respawnCopper(copper, 2, 3);
		//		copper_clone = (GameObject)Instantiate(copper, transform.position, Quaternion.identity);
		
		respawnSilver (silver, 2, 5);
		//silver_clone = (GameObject)Instantiate(silver, transform.position, Quaternion.identity);
		
		respawnIron (iron, 6, 4);
		//iron_clone = (GameObject)Instantiate(silver, transform.position, Quaternion.identity);
		
		respawnBeryllium (beryllium, 2, 3);
		//beryllium_clone = (GameObject)Instantiate(silver, transform.position, Quaternion.identity);
		
		respawnTitanium (titanium, 3, 6);
		//titanium_clone = (GameObject)Instantiate(silver, transform.position, Quaternion.identity);
		
		respawnPlatinum (platinum, 2, 1);
		//platinum_clone = (GameObject)Instantiate(silver, transform.position, Quaternion.identity);
		
		respawnUranium (uranium, 5, 3);
		//uranium_clone = (GameObject)Instantiate(silver, transform.position, Quaternion.identity);
		
		respawnPlutonium (plutonium, 1, 4);
		//	plutonium_clone = (GameObject)Instantiate(silver, transform.position, Quaternion.identity);
		
	}
	
	
	
	/*
	 *
	 * 
	 * After the ores are mined just call respawn_ to bring them back
	 * All ores are pretagged by manager in unity
	 */
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("mouse clicked");
			RaycastHit hitinfo = new RaycastHit();
			bool isHit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitinfo);
			if (isHit)
			{
				Debug.Log("Hit " + hitinfo.transform.gameObject.name);
				
				
				// for some reason it works cube
				if ((hitinfo.transform.gameObject.tag == "silver") && experience >= 3000)
				{
					Destroy(hitinfo.transform.gameObject);
					Debug.Log("We destroyed a " + hitinfo.transform.gameObject.tag);
					experience+=59;
					
					respawnSilver(silver,2,5); 
					
				} else
					if ((hitinfo.transform.gameObject.tag == "iron") && experience >= 1000)
				{
					Destroy(hitinfo.transform.gameObject);
					Debug.Log("We destroyed a " + hitinfo.transform.gameObject.tag);
					experience+=10;
					
					respawnIron(iron,2,3);
					
				} else
					if (hitinfo.transform.gameObject.tag == "copper")
				{
					Destroy(hitinfo.transform.gameObject);
					Debug.Log("We destroyed a " + hitinfo.transform.gameObject.tag);
					experience+=5;
					
					respawnCopper(copper,2,3);
					
				} else
					
					if ((hitinfo.transform.gameObject.tag == "beryllium") && experience >= 2000)
				{
					Destroy(hitinfo.transform.gameObject);
					Debug.Log("We destroyed a " + hitinfo.transform.gameObject.tag);
					experience+=30;
					
					respawnBeryllium(beryllium,2,3);
					
				} 
				else
					if ((hitinfo.transform.gameObject.tag == "titanium") && experience >= 4000)
				{
					Destroy(hitinfo.transform.gameObject);
					Debug.Log("We destroyed a " + hitinfo.transform.gameObject.tag);
					experience+=90;
					
					respawnTitanium(titanium,2,3);
					
				} 
				else
					if ((hitinfo.transform.gameObject.tag == "platinum") && experience >= 7000)
				{
					Destroy(hitinfo.transform.gameObject);
					Debug.Log("We destroyed a " + hitinfo.transform.gameObject.tag);
					experience+=150;
					
					respawnPlatinum(platinum,2,3);
					
				} 
				else
					if ((hitinfo.transform.gameObject.tag == "uranium") && experience >= 9000)
				{
					Destroy(hitinfo.transform.gameObject);
					Debug.Log("We destroyed a " + hitinfo.transform.gameObject.tag);
					experience+=200;
					
					respawnUranium(uranium,2,3);
					
				} 
				else
					if ((hitinfo.transform.gameObject.tag == "plutonium") && experience >= 11000)
				{
					Destroy(hitinfo.transform.gameObject);
					Debug.Log("We destroyed a " + hitinfo.transform.gameObject.tag);
					experience += 400;
					
					respawnPlutonium(plutonium,2,3);
					
				} 
				
				
				
				
				
				
			} else {
				Debug.Log("Nothing hit");
			}
			Debug.Log("Mouse unclicked");
		}
		
	}
}
