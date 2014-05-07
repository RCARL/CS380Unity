using UnityEngine;
using System.Collections;

public class Inventory {
	public static SplayTree<Artificial> artificials;

	public static int capacity;
	public static int current;

	public Inventory () {
		//artificials = new SplayTree<Artificial> ();
		current = 0;
		capacity = 1000;
	}
	
	public static bool addArtificial (Artificial artificial, int num=1) {
		if (current + (artificial.spaceTaken * num) <= capacity) {
			artificials.add (artificial, num);
			current += (artificial.spaceTaken * num);;
			return true;
		}
		else {
			return false;
		}
	}
	public static bool removeArtificial (Artificial artificial, int num=1) {
		bool temp = artificials.remove(artificial, num);
		if (temp) {
			current -= (artificial.spaceTaken * num);
		}
		return temp;
	}

}
