using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Artificial : IComparable {
	public int mass;
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

	protected Artificial (int mass, int spaceTaken, string type, Dictionary<Artificial, int> recipe, string description, string model=null) {
		this.mass = mass;
		this.spaceTaken = spaceTaken;
		this.type = type;
		this.recipe = recipe;
		this.description = description;
		this.model = model;
	}

	public static Artificial furnace () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 5);
		temp.Add (Resource.beryllium(), 10);
		temp.Add (Resource.copper(), 8);
		return new Artificial (100, 6, "Furnace", temp, "Processes Ores","Assets/Models/basic_furnace.dae");

	}

	public static Artificial radar () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 4);
		temp.Add (Resource.copper(), 9);
		return new Artificial (50, 3, "Radar", temp, "Allows you to detect things using radar technology",
		                       "Assets/Models/Radar.dae");
	}

	public static Artificial core () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 10);
		temp.Add (Resource.beryllium(), 2);
		temp.Add (Resource.copper(), 10);
		return new Artificial (120, 8, "Core", temp, "Power source that turns a fuel into electricity"
		                       ,"Assets/Models/core2.dae") ;
	}

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
