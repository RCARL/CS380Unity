using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	//Create ores out of plain cubes
	      
	public GameObject iron;
	public GameObject copper;
	public GameObject beryllium;
	public GameObject silver;
	public GameObject titanium;
	public GameObject platinum;
	public GameObject uranium;
	public GameObject plutonium;



	public float experience = 0.0f;
	/*
	 *   1. Instansiate all ores to game objects 
	 *   2. Create a primitive cube out of all objects 
	 *   3. Set a expiericelevel guard for each ore
	 *   4. If user clicks copper add expierice points by 10
	 *   5. Iron is required by at least 1000 expierince points
	 *   6. Bery - 2000 points etc etc
	 *   7. If ore is mined then respawn them
     *   
	 */  

	//Just change the parameters to where ever you want to spawn the ores
	void Start () {
		for (int a= 0; a< 6; a++) {
						for (int b= 0; b<6; b++) {


								iron = GameObject.CreatePrimitive (PrimitiveType.Cube);
								copper = GameObject.CreatePrimitive (PrimitiveType.Cube);
								beryllium = GameObject.CreatePrimitive (PrimitiveType.Cube);
								silver = GameObject.CreatePrimitive (PrimitiveType.Cube);
								titanium = GameObject.CreatePrimitive (PrimitiveType.Cube);
								platinum = GameObject.CreatePrimitive (PrimitiveType.Cube);
								uranium = GameObject.CreatePrimitive (PrimitiveType.Cube);
								plutonium = GameObject.CreatePrimitive (PrimitiveType.Cube);
				 

								copper.AddComponent<Rigidbody> ();
								iron.AddComponent<Rigidbody> ();
								beryllium.AddComponent<Rigidbody> ();
								silver.AddComponent<Rigidbody> ();
								titanium.AddComponent<Rigidbody> ();
								platinum.AddComponent<Rigidbody> ();
								uranium.AddComponent<Rigidbody> ();
								plutonium.AddComponent<Rigidbody> ();



								copper.transform.position = new Vector3 (a, b, 0);
								iron.transform.position = new Vector3 (a, b, 0);
								beryllium.transform.position = new Vector3 (a, b, 0);
								silver.transform.position = new Vector3 (a, b, 0);
								titanium.transform.position = new Vector3 (a, b, 0);
								platinum.transform.position = new Vector3 (a, b, 0);
								uranium.transform.position = new Vector3 (a, b, 0);
								plutonium.transform.position = new Vector3 (a, b, 0);
						}
				}
		colorOres();
	}

	void colorOres(){
				if (GameObject.FindWithTag ("copper")) {
						renderer.material.SetColor ("copper", Color.red);
				} else
		if (GameObject.FindWithTag ("iron")) {
						renderer.material.SetColor ("iron", Color.grey);
				} else
		if (GameObject.FindWithTag ("beryllium")) {
						renderer.material.SetColor ("beryllium", Color.green);
				} else
		if (GameObject.FindWithTag ("silver")) {
						renderer.material.SetColor ("silver", Color.magenta);
				} else
		if (GameObject.FindWithTag ("titanium")) {
						renderer.material.SetColor ("titanium", Color.white);
				} else
		if (GameObject.FindWithTag ("platinum")) {
						renderer.material.SetColor ("platinum", Color.gray);
				} else
		if (GameObject.FindWithTag ("uranium")) {
						renderer.material.SetColor ("uranium", Color.yellow);
				} else
		if (GameObject.FindWithTag ("plutonium")) {
						renderer.material.SetColor ("plutonium", Color.cyan);
				}

			
		}

	/*
	 * Put this script on all ore objects, if the raycast detects we have a boolean to check
	 * for expierience, if it is true, the object is destroyed within a certain time frame
	 * the rarer the ore the longer it takes to mine
	 * 
	 * After the ores are mined they automatically respawn
	 */
	void Update () {
	  
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = new Ray();
			ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit)){
				if (GameObject.FindWithTag("copper")){
					Destroy(copper,5);
					experience+=5;
					//respawn after mined
					copper.transform.position = new Vector3(5, 0.5F, 6);

				} else
				if (GameObject.FindWithTag("iron") && experience >= 1000){
					Destroy(iron, 8);
					experience+=10;
					 
					iron.transform.position = new Vector3(5, 0.5F, 6);

				} else
				if (GameObject.FindWithTag("beryllium") && experience >= 2000){
					Destroy(beryllium, 9);
					experience+=30;

					beryllium.transform.position = new Vector3(5, 0.5F, 6);
				} else
				if (GameObject.FindWithTag("silver") && experience >= 3000){
					Destroy(beryllium, 10);
					experience+=59;

					silver.transform.position = new Vector3(5, 0.5F, 6);
				}else
				if (GameObject.FindWithTag("titanium") && experience >= 4000){
					Destroy(beryllium, 12);
					experience+=90;

					titanium.transform.position = new Vector3(5, 0.5F, 6);
				}else
				if (GameObject.FindWithTag("platinum") && experience >= 7000){
					Destroy(beryllium, 15);
					experience+=150;

					platinum.transform.position = new Vector3(5, 0.5F, 6);
				} else
				if (GameObject.FindWithTag("uranium") && experience >= 9000){
					Destroy(uranium, 21);
					experience+=200;

					uranium.transform.position = new Vector3(5, 0.5F, 6);
				}else 
				if (GameObject.FindWithTag("plutonium") && experience >= 11000){
					Destroy(plutonium, 33);
					experience += 400;

					plutonium.transform.position = new Vector3(5, 0.5F, 6);
				}



				Debug.Log("Insufficient experience points.");
		    }
	   }
	
   }
}
