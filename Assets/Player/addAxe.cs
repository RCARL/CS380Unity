using UnityEngine;
using System.Collections;

public class addAxe : MonoBehaviour
{

		// Use this for initialization
	GameObject axe ;
	void OnEnable () {
			axe= Instantiate (Resources.Load ("pick_axe"))as GameObject;
			axe.transform.parent=transform;
			axe.transform.position = new Vector3 (5f, -20f, -5f);
			axe.transform.rotation = new Quaternion (0f, 180f, 0f, 0f);
			//axe.transform.localScale = new Vector3 (10, 10, 10);
		}
	public bool animation_bool=false;
	
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

		
		
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			animation_bool = true;
			chunk.editCube(Resource.nothing());
		}
		
		
		
	}
}

