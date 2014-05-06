using UnityEngine;
using System.Collections;

public class addAxe : MonoBehaviour
{

		// Use this for initialization
	GameObject axe ;
	void OnEnable () {
		axe= Instantiate (Resources.Load ("pick_axe"))as GameObject;
			axe.transform.parent=transform;
			axe.transform.localPosition = new Vector3 (0.23f, -0.89f, -0.3f);
			axe.transform.localEulerAngles = new Vector3 (332.74f, 180f, 0f);
			//axe.transform.localScale = new Vector3 (10, 10, 10);
		}
	bool animation_bool=false;
	
	void OnDisable()
	{
		Destroy (axe);
		}
	
	
	// Update is called once per frame
	
	void Update()
	{
		
		if(animation_bool == true)
		{
			axe.animation.Play("Take 001");
			animation_bool = false;

		}
		
		
		if(Input.GetKeyDown(KeyCode.Z))
		{
			animation_bool = true;
			chunk.editCube(Resource.nothing());
		}
		
		
		
	}
}

