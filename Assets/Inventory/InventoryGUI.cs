using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryGUI : MonoBehaviour {
	readonly float paddingLargeX = Screen.width / 8;
	readonly float paddingSmallX = Screen.width / 60;
	readonly float paddingSmallY = Screen.height / 30;
	readonly float paddingLargeY = Screen.height / 12;
	readonly float middleX = Screen.width / 2;
	readonly float middleY = Screen.height / 2;
	public static Inventory inventory = new Inventory();
	private bool openInventory = false;
	private int max;
	private string display;
	private string display2;
	private int cur;
	private Vector2 scrollViewVector = Vector2.zero;
	private Vector2 scrollViewVector2 = Vector2.zero;
	private int toolbarInt = 0;
	private int inventoryInt = 0;
	private float i = 0;
	private float j = 0;
	private Artificial artificialTemp;
	private string[] toolbarStrings = {"Furnace", "Radar", "Core", "Space Gun", "Phase Gun", "Missile Launcher", "Space Cannon", "Turret"};
	private float barLength;
	private float maxBarLength;
	public GUIStyle label;

	public static Artificial currentSelection;
	public static int currentSelectionAmount;

	void Start () {
		max = inventory.capacity;
		barLength = middleX;
		maxBarLength = middleX;
		//inventory.addArtificial (Artificial.furnace (), 1);
	}

	void OnGUI () {
		
		cur = inventory.current;

		GUI.skin.textField.wordWrap = true;
		openInventory = GUI.Toggle (new Rect (Screen.width - 80, Screen.height - 20, 80, 20), openInventory, "Inventory");

		if (openInventory) {
			//GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);
			openInventory = GUI.Toggle (new Rect (Screen.width - 80, Screen.height - 20, 80, 20), openInventory, "Inventory");

			//Capacity bar
			GUI.Box (new Rect (10, 18, barLength, 20), "");
			GUI.Box (new Rect (10, 18, maxBarLength, 20), cur + "/" + max);
	
			//Labels
			GUI.Label (new Rect (10, 0, 80, 20), "Capacity", label);
			GUI.Label (new Rect (10, (middleY / 4) - paddingSmallY, 80, 20), "Inventory", label);
			GUI.Label (new Rect (middleX + paddingSmallX, 0, 80, 20), "Crafting", label);
			GUI.Label (new Rect (middleX, middleY + Screen.height / 24, 80, 20), "Required: ", label);

			//GUI.Label (new Rect ((paddingLargeX * 3) + Screen.width / 16, 50, 80, 40), "Total Mass", label);
			//GUI.Label (new Rect ((paddingLargeX * 3) + Screen.width / 16, 70, 80, 40), "" + inventory.totalMass, label);


			// Begin the InventoryView
			scrollViewVector = GUI.BeginScrollView (new Rect (10, middleY / 4, Screen.width / 5, Screen.height - Screen.height / 6), scrollViewVector, new Rect (0, 0, Screen.width / 6, Screen.height - Screen.height / 5));
			string[] inventoryStrings = new string[inventory.artificials.count]; 
			Node<Artificial>[] inventoryItems = new Node<Artificial>[inventory.artificials.count];
			inventory.artificials.Nodes().CopyTo(inventoryItems,0);
			int numTemp = 0;


			foreach (Node<Artificial> art in inventory.artificials.Nodes()) {
				inventoryStrings [numTemp] = art.key.type + ": " + art.value.ToString ();
				numTemp++;
			}
			inventoryInt = GUI.SelectionGrid (new Rect (0, 0, Screen.width / 5, inventory.artificials.count * 25), inventoryInt, inventoryStrings, 1);
			if(inventoryInt >= inventory.artificials.count) {
				inventoryInt = 0;
			} 
			if(inventory.artificials.count > 0){
				currentSelection = inventoryItems[inventoryInt].key;
				currentSelectionAmount = inventoryItems[inventoryInt].value;
			}
			else {
				currentSelection = null;
				currentSelectionAmount = 0;
			}
			// End the InventoryView
			GUI.EndScrollView ();

			if(inventory.artificials.count > 0){
				display = "Type: " + currentSelection.type + @"
" + "Amount: " + currentSelectionAmount + @"
" + "Description: " + currentSelection.description;
			} else {
				display = "";
			}
					GUI.TextField(new Rect((Screen.width/4) - paddingSmallX, middleY / 4, Screen.width / 5, Screen.height / 4),display);
			
			// Begin the ScrollView
			scrollViewVector2 = GUI.BeginScrollView (new Rect (middleX + paddingSmallX, 20, Screen.width / 5, Screen.height / 2), scrollViewVector2, new Rect (0, 0, Screen.width / 6, 19));

			toolbarInt = GUI.SelectionGrid (new Rect (0, 0, Screen.width / 5, toolbarStrings.Length * 25), toolbarInt, toolbarStrings, 1);
		
			// End the ScrollView
			GUI.EndScrollView ();


			//Drawing crafting recipe based on what is selected in the scrollbar
			switch (toolbarInt) {
			case 0:
				artificialTemp = Artificial.furnace ();
				i = 0;
				j = paddingLargeY;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 1:
				artificialTemp = Artificial.radar ();
				i = 0;
				j = paddingLargeY;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 2:
				artificialTemp = Artificial.core ();
				i = 0;
				j = paddingLargeY;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 3:
				artificialTemp = Artificial.spacegun ();
				i = 0;
				j = paddingLargeY;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 4:
				artificialTemp = Artificial.phasegun ();
				i = 0;
				j = paddingLargeY;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 5:
				artificialTemp = Artificial.missilelauncher ();
				i = 0;
				j = paddingLargeY;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 6:
				artificialTemp = Artificial.spacecannon ();
				i = 0;
				j = paddingLargeY;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 7:
				artificialTemp = Artificial.turret ();
				i = 0;
				j = paddingLargeY;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			/*case 3:
				artificialTemp = Artificial.gun ();
				i = 0;
				j = 50;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 4:
				artificialTemp = Artificial.pickaxe ();
				i = 0;
				j = 50;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;
			case 5:
				artificialTemp = Artificial.sword ();
				i = 0;
				j = 50;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					GUI.Label (new Rect (middleX + i, middleY + j, 80, 40), de.Key.type, label);
					GUI.Label (new Rect (middleX + i, middleY + j + 20, 80, 40), de.Value.ToString (), label);
					i += paddingLargeX;
					if (i > paddingLargeX * 3) {
						i = 0;
						j += 50;
					}
				}
				break;*/
			default:
				break;
			}
			//Drawing the info box for the Crafting
			display2 = "Type: " + artificialTemp.type + @"
" + "Description: " + artificialTemp.description;
			GUI.TextField(new Rect((Screen.width/4) * 3, 20, Screen.width / 5, Screen.height / 4),display2);

			//Crafting button
			if (GUI.Button (new Rect (((Screen.width / 4) * 2), middleY - 20, (Screen.width / 2) - 10, 30), "Craft")) {
				bool canCraft = true;
				foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
					canCraft = inventory.artificials.check(de.Key, de.Value);
					if (!canCraft) {
						break;
					}
				}
				if (canCraft) {
					foreach (KeyValuePair<Artificial, int> de in artificialTemp.recipe) {
						inventory.removeArtificial (de.Key, de.Value);
					}
					inventory.addArtificial (artificialTemp, 1);
				}
			}
		
			//Tester buttons
			if (GUI.Button (new Rect (Screen.width / 2, ((Screen.height / 6) * 4), 100, 20), "Test")) {
				inventory.addArtificial (Resource.iron (), 200);
				inventory.addArtificial (Resource.copper (), 200);
				inventory.addArtificial (Resource.beryllium (), 200);
			}
			/*
			if (GUI.Button (new Rect ((Screen.width / 2) + 120, ((Screen.height / 6) * 4), 100, 20), "Remove Iron")) {
				inventory.removeArtificial (Resource.iron (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2, ((Screen.height / 6) * 4) + 20, 100, 20), "Add Beryllium")) {
				inventory.addArtificial (Resource.beryllium (), 1);
			}
			if (GUI.Button (new Rect ((Screen.width / 2) + 120, ((Screen.height / 6) * 4) + 20, 100, 20), "Remove Beryllium")) {
				inventory.removeArtificial (Resource.beryllium (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2, ((Screen.height / 6) * 4) + 40, 100, 20), "Add Copper")) {
				inventory.addArtificial (Resource.copper (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 120, ((Screen.height / 6) * 4) + 40, 100, 20), "Remove Copper")) {
				inventory.removeArtificial (Resource.copper (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2, ((Screen.height / 6) * 4) + 60, 100, 20), "Add Platinum")) {
				inventory.addArtificial (Resource.platinum (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 120, ((Screen.height / 6) * 4) + 60, 100, 20), "Remove Platinum")) {
				inventory.removeArtificial (Resource.platinum (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2, ((Screen.height / 6) * 4) + 80, 100, 20), "Add Titanium")) {
				inventory.addArtificial (Resource.titanium (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 120, ((Screen.height / 6) * 4) + 80, 100, 20), "Remove Titanium")) {
				inventory.removeArtificial (Resource.titanium (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2, ((Screen.height / 6) * 4) + 100, 100, 20), "Add Uranium")) {
				inventory.addArtificial (Resource.uranium (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 120, ((Screen.height / 6) * 4) + 100, 100, 20), "Remove Uranium")) {
				inventory.removeArtificial (Resource.uranium (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2, ((Screen.height / 6) * 4) + 120, 100, 20), "Add Plutonium")) {
				inventory.addArtificial (Resource.plutonium (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 120, ((Screen.height / 6) * 4) + 120, 100, 20), "Remove Plutonium")) {
				inventory.removeArtificial (Resource.plutonium (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2, ((Screen.height / 6) * 4) + 140, 100, 20), "Add Silver")) {
				inventory.addArtificial (Resource.silver (), 1);
			}
			if (GUI.Button (new Rect (Screen.width / 2 + 120, ((Screen.height / 6) * 4) + 140, 100, 20), "Remove Silver")) {
				inventory.removeArtificial (Resource.silver (), 1);
			}
			*/
		}//End of OpenInventory
	}//End of OnGUI
	public void Update() {
		adjust ();
		if (Input.GetKeyUp ("i")) {
			if(openInventory){
				openInventory = false;
			}
			else{
				openInventory = true;
			}
		}
	}
	//Adjusts the capacity bar
	public void adjust () {
		if (cur > max) {
			cur = max;
		}
		if (cur < 0) {
			cur = 0;
		}
		barLength = middleX * (cur / (float) max);
	}
}
