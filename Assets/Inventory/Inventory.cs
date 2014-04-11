using UnityEngine;
using System.Collections;

public class Inventory {
	public int[] numIron;
	public int[] numPlatinum;
	public int[] numTitanium;

	public int[] numBeryllium;
	public int[] numUranium;
	public int[] numPlutonium;

	public int[] numCopper;
	public int[] numSilver;
	public ArrayList artificial;

	public int capacity;
	public int current;
	public int totalMass;

	public Inventory () {
		numIron = new int[4];
		numPlatinum = new int[4];
		numTitanium = new int[4];
		
		numBeryllium = new int[4];
		numUranium = new int[4];
		numPlutonium = new int[4];

		numCopper = new int[4];
		numSilver = new int[4];

		artificial = new ArrayList ();

		current = 0;
		capacity = 100;
	}

	public bool addResource (Resource r, int num) {
		if (current < capacity) {
			switch (r.type) {
			case "Iron":
				numIron[r.tier-1]+= num;
				current += num;
				totalMass += r.mass * num;
				return true;
			case "Platinum":
				numPlatinum[r.tier-1]+= num;
				current += num;
				totalMass += r.mass * num;
				return true;
			case "Titanium":
				numTitanium[r.tier-1]+= num;
				current += num;
				totalMass += r.mass * num;
				return true;
			case "Beryllium":
				numBeryllium[r.tier-1]+= num;
				current += num;
				totalMass += r.mass * num;
				return true;
			case "Uranium":
				numUranium[r.tier-1]+=num;
				current += num;
				totalMass += r.mass * num;
				return true;
			case "Plutonium":
				numPlutonium[r.tier-1]+=num;
				current += num;
				totalMass += r.mass * num;
				return true;
			case "Copper":
				numCopper[r.tier-1]+=num;
				current += num;
				totalMass += r.mass * num;
				return true;
			case "Silver":
				numSilver[r.tier-1]+=num;
				current += num;
				totalMass += r.mass * num;
				return true;
			default:
				return false;
			}

		} 
		else {
			return false;
		}
	}
	public bool removeResource (Resource r, int num) {
		switch (r.type) {
		case "Iron":
			if (numIron[r.tier-1] >= num){
				numIron[r.tier-1] -= num;
				current -= num;
				totalMass -= r.mass * num;
				return true;
			}
			else {
				return false;
			}
		case "Platinum":
			if (numPlatinum[r.tier-1] >= num){
				numPlatinum[r.tier-1] -= num;
				current -= num;
				totalMass -= r.mass * num;
				return true;
			}
			else {
				return false;
			}
		case "Titanium":
			if (numTitanium[r.tier-1] >= num){
				numTitanium[r.tier-1] -= num;
				current -= num;
				totalMass -= r.mass * num;
				return true;
			}
			else {
				return false;
			}
		case "Beryllium":
			if (numBeryllium[r.tier-1] >= num){
				numBeryllium[r.tier-1] -= num;
				current -= num;
				totalMass -= r.mass * num;
				return true;
			}
			else {
				return false;
			}
		case "Uranium":
			if (numUranium[r.tier-1] >= num){
				numUranium[r.tier-1] -= num;
				current -= num;
				totalMass -= r.mass * num;
				return true;
			}
			else {
				return false;
			}
		case "Plutonium":
			if (numPlutonium[r.tier-1] >= num){
				numPlutonium[r.tier-1] -= num;
				current -= num;
				totalMass -= r.mass * num;
				return true;
			}
			else {
				return false;
			}
		case "Copper":
			if (numCopper[r.tier-1] >= num){
				numCopper[r.tier-1] -= num;
				current -= num;
				totalMass -= r.mass * num;
				return true;
			}
			else {
				return false;
			}
		case "Silver":
			if (numSilver[r.tier-1] >= num){
				numSilver[r.tier-1] -= num;
				current -= num;
				totalMass -= r.mass * num;
				return true;
			}
			else {
				return false;
			}
		default:
			return false;
		}
	}
	public bool addArtificial (Artificial artificial) {
		if (current + artificial.spaceTaken < capacity) {
			this.artificial.Add (artificial);
			current += artificial.spaceTaken;
			totalMass += artificial.mass;
			return true;
		}
		else {
			return false;
		}
	}
	public bool removeArtificial (Artificial artificial) {
		int find = this.artificial.BinarySearch (artificial);
		if (find != -1) {
			this.artificial.RemoveAt (find);
			current -= artificial.spaceTaken;
			totalMass -= artificial.mass;
			return true;
		} 
		else {
			return false;
		}
	}

}
