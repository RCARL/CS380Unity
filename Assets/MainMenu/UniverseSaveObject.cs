using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;
using System.Collections;


public class UniverseSaveObject : MonoBehaviour {


	public static void SaveUniverse(){
		var bformat = new BinaryFormatter(); //binaryformatter used to serialize data
		var mstr = new MemoryStream();
		GameObject[] allObjects;
		allObjects= new GameObject[1000]; //default size of 1000 game objects, can be altered with a non 'magic number'

		//Returns a gameobject array of all active gameobjects in the scene
		//will include the blank gameobject the script is attached to
		//allObjects=FindObjectsOfType(typeof(GameObject)) as GameObject[];
		SplayTree<Artificial> inventorysave = Inventory.artificials;

		/*Type types = new Type[allObjects.Length];
		for (int x=0; x<types.Length; x++) {
			types [x] = allObjects.GetType ();
		}*/
		bformat.Serialize (mstr, inventorysave); //serializes the array into a memory buffer
		//Buffer then stored within playerprefs as a string conversion
		PlayerPrefs.SetString ("inventory", Convert.ToBase64String (mstr.GetBuffer()));
		//b.Serialize(m, o);
		//PlayerPrefs.SetString(key, Convert.ToBase64String(mstr.GetBuffer));

}
	public static void LoadUniverse() {

		var curObj = PlayerPrefs.GetString("inventory");
		/*GameObject[] destination;
		if (!string.IsNullOrEmpty (curObj)) {
						var bformat = new BinaryFormatter ();
						var mstr = new MemoryStream (Convert.FromBase64String (curObj));
						destination = bformat.Deserialize (mstr) as GameObject[];
		} else {
			Console.Write ("String does not hold non null or non empty value\n");
			return;
		}
		for( int x=0;x<destination.Length;x++){
			Instantiate(destination[x], destination[x].transform.position, destination[x].transform.rotation);
		}*/
		var bformat = new BinaryFormatter ();
		var mstr = new MemoryStream (Convert.FromBase64String (curObj));
		Inventory.artificials = bformat.Deserialize (mstr) as SplayTree<Artificial>;

	}
}