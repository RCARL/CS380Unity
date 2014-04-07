using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Artificial {
	public int mass;
	public int spaceTaken;
	public string type;
	public Dictionary<Resource, int> recipe = 
		new Dictionary<Resource, int> ();

	private Artificial (int mass, int spaceTaken, string type, Dictionary<Resource, int> recipe) {
		this.mass = mass;
		this.spaceTaken = spaceTaken;
		this.type = type;
		this.recipe = recipe;
	}

	public static Artificial engine () {
		Dictionary<Resource, int> temp = 
			new Dictionary<Resource, int> ();
		temp.Add (Resource.iron(1), 5);
		temp.Add (Resource.beryllium(1), 10);
		temp.Add (Resource.copper(1), 8);
		return new Artificial (100, 6, "Engine", temp);
	}

	public static Artificial communication () {
		Dictionary<Resource, int> temp = 
			new Dictionary<Resource, int> ();
		temp.Add (Resource.iron(1), 4);
		temp.Add (Resource.copper(1), 9);
		return new Artificial (50, 3, "Communication", temp);
	}

	public static Artificial reactor () {
		Dictionary<Resource, int> temp = 
			new Dictionary<Resource, int> ();
		temp.Add (Resource.iron(1), 10);
		temp.Add (Resource.beryllium(1), 2);
		temp.Add (Resource.copper(1), 10);
		return new Artificial (120, 8, "Reactor", temp);
	}

	public static Artificial gun () {
		Dictionary<Resource, int> temp = 
			new Dictionary<Resource, int> ();
		temp.Add (Resource.iron(1), 2);
		temp.Add (Resource.beryllium(1), 1);
		temp.Add (Resource.copper(1), 2);
		return new Artificial (4, 1, "Gun", temp);
	}
}
