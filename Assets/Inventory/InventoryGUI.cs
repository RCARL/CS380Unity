﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryGUI : MonoBehaviour {
	readonly float padding = Screen.width / 8;
	readonly float middleX = Screen.width / 2;
	readonly float middleY = Screen.height / 2;
	public Inventory inventory = new Inventory();
	public bool openInventory = false;
	public int max;
	public int cur;
	public Texture background;
	private Vector2 scrollViewVector = Vector2.zero;
	private Vector2 scrollViewVector2 = Vector2.zero;
	private int toolbarInt = 0;
	private int inventoryInt = 0;
	float i = 0;
	float j = 0;
	private Artificial artificialTemp;
	private string[] toolbarStrings = {"Furnace", "Radar", "Core", "Gun", "Pickaxe", "Sword"};

	public float barLength;
	public float maxBarLength;

	public GUIStyle label;
	public GUIStyle box;

	void Start () {
		max = inventory.capacity;
		barLength = middleX;
		maxBarLength = middleX;
		inventory.addArtificial (Artificial.furnace ());
	}
	void Update () {
		cur = inventory.current;
		adjust (0);
	}
	void OnGUI () {
		openInventory = GUI.Toggle (new Rect (Screen.width - 80, Screen.height - 20, 80, 20), openInventory, "Inventory");

		if (openInventory) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);
			openInventory = GUI.Toggle (new Rect (Screen.width - 80, Screen.height - 20, 80, 20), openInventory, "Inventory");

			//Capacity bar
			GUI.Box (new Rect (10, 18, barLength, 20), "");
			GUI.Box (new Rect (10, 18, maxBarLength, 20), cur + "/" + max);



			//Labels
			GUI.Label (new Rect (10, 0, 80, 20), "Capacity", label);
			GUI.Label (new Rect (10, middleY - 20, 80, 20), "Inventory", label);
			GUI.Label (new Rect (middleX + 20, 0, 80, 20), "Crafting", label);
			GUI.Label (new Rect (middleX, middleY + 30, 80, 20), "Required: ", label);
			GUI.Label (new Rect (10, 50, 80, 40), "Iron", label);
			GUI.Label (new Rect (10, 70, 80, 40), "" + inventory.numIron [0], label);
			GUI.Label (new Rect (10, 100, 80, 40), "Platinum", label);
			GUI.Label (new Rect (10, 120, 80, 40), "" + inventory.numPlatinum [0], label);
			GUI.Label (new Rect (10, 150, 80, 40), "Titanium", label);
			GUI.Label (new Rect (10, 170, 80, 40), "" + inventory.numTitanium [0], label);
			GUI.Label (new Rect (padding, 50, 80, 40), "Beryllium", label);
			GUI.Label (new Rect (padding, 70, 80, 40), "" + inventory.numBeryllium [0], label);
			GUI.Label (new Rect (padding, 100, 80, 40), "Uranium", label);
			GUI.Label (new Rect (padding, 120, 80, 40), "" + inventory.numUranium [0], label);
			GUI.Label (new Rect (padding, 150, 80, 40), "Plutonium", label);
			GUI.Label (new Rect (padding, 170, 80, 40), "" + inventory.numPlutonium [0], label);
			GUI.Label (new Rect (padding * 2, 50, 80, 40), "Copper", label);
			GUI.Label (new Rect (padding * 2, 70, 80, 40), "" + inventory.numCopper [0], label);
			GUI.Label (new Rect (padding * 2, 100, 80, 40), "Silver", label);
			GUI.Label (new Rect (padding * 2, 120, 80, 40), "" + inventory.numSilver [0], label);
			GUI.Label (new Rect (padding * 3, 50, 80, 40), "Total Mass", label);
			GUI.Label (new Rect (padding * 3, 70, 80, 40), "" + inventory.totalMass, label);

			// Begin the InventoryView
			scrollViewVector = GUI.BeginScrollView (new Rect (10, middleY, Screen.width / 5, Screen.height / 2), scrollViewVector, new Rect (0, 0, Screen.width / 6, 1000));
			string[] inventoryStrings = new string[inventory.artificial.Count]; 
			int numTemp = 0;
			foreach (Artificial art in inventory.artificial) {
				inventoryStrings [numTemp] = art.type;
				numTemp++;
			}
			inventoryInt = GUI.SelectionGrid (new Rect (0, 0, Screen.width / 5, inventory.artificial.Count * 25), inventoryInt, inventoryStrings, 1);
			// End the InventoryView
			GUI.EndScrollView ();

			// Begin the ScrollView
			scrollViewVector2 = GUI.BeginScrollView (new Rect (middleX + 20, 20, Screen.width / 5, Screen.height / 2), scrollViewVector2, new Rect (0, 0, Screen.width / 6, 1000));

			toolbarInt = GUI.SelectionGrid (new Rect (0, 0, Screen.width / 5, toolbarStrings.Length * 25), toolbarInt, toolbarStrings, 1);
		
			// End the ScrollView
			GUI.EndScrollView ();

			//Drawing crafting recipe based on what is selected in the scrollbar
			switch (toolbarInt) {
			case 0:
				artificialTemp = Artificial.furnace ();
				i = 0;
				j = 50;
				foreach (KeyValuePair<Resource, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += padding;
					if (i > padding * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 1:
				artificialTemp = Artificial.radar ();
				i = 0;
				j = 50;
				foreach (KeyValuePair<Resource, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += padding;
					if (i > padding * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 2:
				artificialTemp = Artificial.core ();
				i = 0;
				j = 50;
				foreach (KeyValuePair<Resource, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += padding;
					if (i > padding * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 3:
				artificialTemp = Artificial.gun ();
				i = 0;
				j = 50;
				foreach (KeyValuePair<Resource, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += padding;
					if (i > padding * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 4:
				artificialTemp = Artificial.pickaxe ();
				i = 0;
				j = 50;
				foreach (KeyValuePair<Resource, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += padding;
					if (i > padding * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 5:
				artificialTemp = Artificial.sword ();
				i = 0;
				j = 50;
				foreach (KeyValuePair<Resource, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += padding;
					if (i > padding * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			default:
				break;
			}

			//Crafting button
			if (GUI.Button (new Rect (((Screen.width / 4) * 3) - 20, middleY, Screen.width / 4, 15), "Craft")) {
				bool canCraft = true;
				foreach (KeyValuePair<Resource, int> de in artificialTemp.recipe) {
					switch (de.Key.type) {
					case "Iron":
						if (inventory.numIron [0] < de.Value) {
							canCraft = false;
						}
						break;
					case "Platinum":
						if (inventory.numPlatinum [0] < de.Value) {
							canCraft = false;
						}
						break;
					case "Titanium":
						if (inventory.numTitanium [0] < de.Value) {
							canCraft = false;
						}
						break;
					case "Beryllium":
						if (inventory.numBeryllium [0] < de.Value) {
							canCraft = false;
						}
						break;
					case "Uranium":
						if (inventory.numBeryllium [0] < de.Value) {
							canCraft = false;
						}
						break;
					case "Plutonium":
						if (inventory.numPlutonium [0] < de.Value) {
							canCraft = false;
						}
						break;
					case "Copper":
						if (inventory.numCopper [0] < de.Value) {
							canCraft = false;
						}
						break;
					case "Silver":
						if (inventory.numSilver [0] < de.Value) {
							canCraft = false;
						}
						break;
					default:
						break;
					}
					if (!canCraft) {
						break;
					}
				}
				if (canCraft) {
					foreach (KeyValuePair<Resource, int> de in artificialTemp.recipe) {
						inventory.removeResource (de.Key, de.Value);
					}
					inventory.addArtificial (artificialTemp);
				}
			}
		
			//Tester buttons
			if (GUI.Button (new Rect (Screen.width / 4, ((Screen.height / 4) * 3), 100, 20), "Add Iron")) {
				inventory.addResource (Resource.iron (1), 1);
			}
			if (GUI.Button (new Rect ((Screen.width / 4) + 120, ((Screen.height / 4) * 3), 100, 20), "Remove Iron")) {
				inventory.removeResource (Resource.iron (1), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 4, ((Screen.height / 4) * 3) + 30, 100, 20), "Add Beryllium")) {
				inventory.addResource (Resource.beryllium (1), 1);
			}
			if (GUI.Button (new Rect ((Screen.width / 4) + 120, ((Screen.height / 4) * 3) + 30, 100, 20), "Remove Beryllium")) {
				inventory.removeResource (Resource.beryllium (1), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 4, ((Screen.height / 4) * 3) + 60, 100, 20), "Add Copper")) {
				inventory.addResource (Resource.copper (1), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 4 + 120, ((Screen.height / 4) * 3) + 60, 100, 20), "Remove Copper")) {
				inventory.removeResource (Resource.copper (1), 1);
			}
		}//End of OpenInventory
	}//End of OnGUI
	//Adjusts the capacity bar
	public void adjust (int adj) {
		cur += adj;
		if (cur > max) {
			cur = max;
		}
		if (cur < 0) {
			cur = 0;
		}
		
		barLength = middleX * (cur / (float) max);
	}
}
