using UnityEngine;
using System.Collections;

public class Inventory {
	public SplayTree<Artificial> artificials;

	public int capacity;
	public int current;

	public Inventory () {
		artificials = new SplayTree<Artificial> ();

		current = 0;
		capacity = 1000;
	}
	
	public bool addArtificial (Artificial artificial, int num=1) {
		if (current + (artificial.spaceTaken * num) <= capacity) {
			artificials.add (artificial, num);
			current += (artificial.spaceTaken * num);;
			return true;
		}
		else {
			return false;
		}
	}
	public bool removeArtificial (Artificial artificial, int num=1) {
		bool temp = artificials.remove(artificial, num);
		if (temp) {
			current -= (artificial.spaceTaken * num);
		}
		return temp;
	}

}
