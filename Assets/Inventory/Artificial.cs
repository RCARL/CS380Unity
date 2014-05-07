using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable()]
public class Artificial : IComparable, ISerializable {
	public int spaceTaken;
	public string type;
	public string description;
	
	public string model;
	public Dictionary<Artificial, int> recipe = 
		new Dictionary<Artificial, int> ();
	/// <summary>
	/// byte value used to call this
	/// </summary>
	public byte symbol=0x80;
	public int CompareTo(object obj) {
		Artificial temp = (Artificial)obj;
		return String.Compare (this.type, temp.type);
	}

	protected Artificial (int spaceTaken, string type, Dictionary<Artificial, int> recipe, string description, string model=null) {
		this.spaceTaken = spaceTaken;
		this.type = type;
		this.recipe = recipe;
		this.description = description;
		this.model = model;
	}
	public Artificial(SerializationInfo info, StreamingContext context) {
		// Reset the property value using the GetValue method.
		spaceTaken = (int) info.GetValue ("spaceTaken", typeof(int));
		type = (string) info.GetValue ("type", typeof(string));
		description = (string) info.GetValue ("description", typeof(string));
		model = (string) info.GetValue ("model", typeof(string));
		recipe = (Dictionary<Artificial, int>) info.GetValue ("recipe", typeof(Dictionary<Artificial, int>));
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context) {
		// Use the AddValue method to specify serialized values.
		info.AddValue ("spaceTaken", spaceTaken, typeof(int));
		info.AddValue ("type", type, typeof(string));
		info.AddValue ("description", description, typeof(string));
		info.AddValue ("model", model, typeof(string));
		info.AddValue ("recipe", recipe, typeof(Dictionary<Artificial, int>));
		info.AddValue ("symbol", symbol, typeof(byte));
	}


	public static Artificial furnace () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 5);
		temp.Add (Resource.beryllium(), 10);
		temp.Add (Resource.copper(), 8);
		return new Artificial (6, "Furnace", temp, "Processes Ores","Model-fbx/furnace");

	}

	public static Artificial radar () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 4);
		temp.Add (Resource.copper(), 9);
		return new Artificial (3, "Radar", temp, "Allows you to detect things using radar technology",
		                       "Model-fbx/radar");
	}

	public static Artificial core () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 10);
		temp.Add (Resource.beryllium(), 2);
		temp.Add (Resource.copper(), 10);
		return new Artificial (8, "Core", temp, 
			"Power source that turns a fuel into electricity"
			,"model-fbx/core2") ;
	}
	public static Artificial warpdrive () {
				Dictionary<Artificial, int> temp =
			new Dictionary<Artificial, int> ();
				temp.Add (Artificial.core (), 5);
				temp.Add (Artificial.radar (), 2);
				temp.Add (Artificial.furnace (), 4);
				temp.Add (Resource.iron (), 6);
				temp.Add (Resource.copper (), 3);
				return new Artificial (15, "Warp Drive", temp, "You'll finally get home once you finish this!");
		}

	/*public static Artificial spacegun () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 4);
		temp.Add (Resource.beryllium(), 2);
		temp.Add (Resource.copper(), 7);
		return new Artificial (4, "Space Gun", temp, 
		                       "Power source that turns a fuel into electricity"
		                       ,"Models/core2") ;
	}*/

	/*public static Artificial phasegun () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 5);
		temp.Add (Resource.beryllium(), 3);
		temp.Add (Resource.copper(), 10);
		return new Artificial (5, "Phase Gun", temp, 
		                       "Shoots a projectile"
		                       ,"Models/phase_gun2") ;
	}

	public static Artificial missilelauncher () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 10);
		temp.Add (Resource.beryllium(), 1);
		temp.Add (Resource.copper(),4);
		return new Artificial (7, "Missile Launcher", temp, 
		                       "Launches a missile at a target"
		                       ,"Models/missle_launcher") ;
	}

	public static Artificial spacecannon () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 11);
		temp.Add (Resource.beryllium(), 6);
		temp.Add (Resource.copper(), 11);
		return new Artificial (8, "Space Cannon", temp, 
		                       "Powerful cannon that decimates all in its path"
		                       ,"Models/spaceship_weapon") ;
	}

	public static Artificial turret () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 7);
		temp.Add (Resource.beryllium(), 2);
		temp.Add (Resource.copper(), 10);
		return new Artificial (5, "Turret", temp, 
		                       "Turret that shoots projectiles"
		                       ,"Models/core2") ;
	}*/

	/*public static Artificial gun () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 2);
		temp.Add (Resource.beryllium(), 1);
		temp.Add (Resource.copper(), 2);
		string stringTemp = "A gun used for ranged";
		return new Artificial (4, 1, "Gun", temp, stringTemp);
	}

	public static Artificial pickaxe () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 4);
		string stringTemp = "Pickaxe used for mining";
		return new Artificial (4, 1, "Pickaxe", temp, stringTemp);
	}

	public static Artificial sword () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 5);
		string stringTemp = "Sword used for melee combat";
		return new Artificial (4, 1, "Sword", temp, stringTemp);
	}*/
}
