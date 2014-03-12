using UnityEngine;
using System.Collections;

public class Player {

	public static Player playerSingleton=new Player();
	/// <summary>
	/// switches between look mode and cursor mode
	/// </summary>
	public bool selectMode=false;
	/// <summary>
	/// indicates what block type from inventory is selected
	/// </summary>
	public byte blockTypeSelected=0;
	/// <summary>
	/// indicates what weapon or equipment type is currently active
	/// </summary>
	public int equipmentSelected{
		get{
			return (int)blockTypeSelected;
		}
		set{
			blockTypeSelected= (byte)value;
		}
	}

}
