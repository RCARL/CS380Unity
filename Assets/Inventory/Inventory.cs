﻿using UnityEngine;
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

		current = 0;
		capacity = 100;
	}

	public bool addResource (Resource r, int num) {
		if (current < capacity) {
			switch (r.type) {
			case "Iron":
				numIron[r.tier-1]+= num;
				current++;
				totalMass += r.mass;
				return true;
			case "Platinum":
				numPlatinum[r.tier-1]+= num;
				current++;
				totalMass += r.mass;
				return true;
			case "Titanium":
				numTitanium[r.tier-1]+= num;
				current++;
				totalMass += r.mass;
				return true;
			case "Beryllium":
				numBeryllium[r.tier-1]+= num;
				current++;
				totalMass += r.mass;
				return true;
			case "Uranium":
				numUranium[r.tier-1]+=num;
				current++;
				totalMass += r.mass;
				return true;
			case "Plutonium":
				numPlutonium[r.tier-1]+=num;
				current++;
				totalMass += r.mass;
				return true;
			case "Copper":
				numCopper[r.tier-1]+=num;
				current++;
				totalMass += r.mass;
				return true;
			case "Silver":
				numSilver[r.tier-1]+=num;
				current++;
				totalMass += r.mass;
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
				current--;
				totalMass -= r.mass;
				return true;
			}
			else {
				return false;
			}
		case "Platinum":
			if (numPlatinum[r.tier-1] >= num){
				numPlatinum[r.tier-1] -= num;
				current--;
				totalMass -= r.mass;
				return true;
			}
			else {
				return false;
			}
		case "Titanium":
			if (numTitanium[r.tier-1] >= num){
				numTitanium[r.tier-1] -= num;
				current--;
				totalMass -= r.mass;
				return true;
			}
			else {
				return false;
			}
		case "Beryllium":
			if (numBeryllium[r.tier-1] >= num){
				numBeryllium[r.tier-1] -= num;
				current--;
				totalMass -= r.mass;
				return true;
			}
			else {
				return false;
			}
		case "Uranium":
			if (numUranium[r.tier-1] >= num){
				numUranium[r.tier-1] -= num;
				current--;
				totalMass -= r.mass;
				return true;
			}
			else {
				return false;
			}
		case "Plutonium":
			if (numPlutonium[r.tier] >= num){
				numPlutonium[r.tier] -= num;
				current--;
				totalMass -= r.mass;
				return true;
			}
			else {
				return false;
			}
		case "Copper":
			if (numCopper[r.tier] >= num){
				numCopper[r.tier] -= num;
				current--;
				totalMass -= r.mass;
				return true;
			}
			else {
				return false;
			}
		case "Silver":
			if (numSilver[r.tier] >= num){
				numSilver[r.tier] -= num;
				current--;
				totalMass -= r.mass;
				return true;
			}
			else {
				return false;
			}
		default:
			return false;
		}
	}
}