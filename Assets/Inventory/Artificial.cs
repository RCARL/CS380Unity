using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Artificial : IComparable {
	public int mass;
	public int spaceTaken;
	public string type;
	public Dictionary<Artificial, int> recipe = 
		new Dictionary<Artificial, int> ();

	public int CompareTo(object obj) {
		Artificial temp = (Artificial)obj;
		return String.Compare (this.type, temp.type);
	}

	protected Artificial (int mass, int spaceTaken, string type, Dictionary<Artificial, int> recipe) {
		this.mass = mass;
		this.spaceTaken = spaceTaken;
		this.type = type;
		this.recipe = recipe;
	}

	public static Artificial furnace () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 5);
		temp.Add (Resource.beryllium(), 10);
		temp.Add (Resource.copper(), 8);
		return new Artificial (100, 6, "Furnace", temp);
	}

	public static Artificial radar () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 4);
		temp.Add (Resource.copper(), 9);
		return new Artificial (50, 3, "Radar", temp);
	}

	public static Artificial core () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 10);
		temp.Add (Resource.beryllium(), 2);
		temp.Add (Resource.copper(), 10);
		return new Artificial (120, 8, "Core", temp);
	}

	public static Artificial gun () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 2);
		temp.Add (Resource.beryllium(), 1);
		temp.Add (Resource.copper(), 2);
		return new Artificial (4, 1, "Gun", temp);
	}

	public static Artificial pickaxe () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 4);
		return new Artificial (4, 1, "Pickaxe", temp);
	}

	public static Artificial sword () {
		Dictionary<Artificial, int> temp = 
			new Dictionary<Artificial, int> ();
		temp.Add (Resource.iron(), 5);
		return new Artificial (4, 1, "Sword", temp);
	}
}
