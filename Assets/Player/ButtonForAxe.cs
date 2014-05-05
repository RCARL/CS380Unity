using UnityEngine;
using System.Collections;

public class ButtonForAxe : MonoBehaviour {

	public bool animation_bool;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	
	void Update()
	{
		
		if(animation_bool == true)
		{
			animation.Play("Take 001");
			
		}
		animation_bool = false;
		
		
		if(Input.GetKeyDown("z"))
		{
			animation_bool = true;
			
		}
		
		
		
	}
}
