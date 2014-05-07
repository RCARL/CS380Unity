using UnityEngine;
using System.Collections;
public enum state { shoot, mine, die, addVoxels, gui };
public class governor : MonoBehaviour
{

   public bool move;
   
    state _currentState = state.gui;
   public  state prevState;
    bool changed=false;
    public state currentState
    {
        get { return _currentState; }
        set
        {
            prevState = _currentState;
            _currentState = value;
        changed = true;
        }
    }
	// Use this for initialization
	void Start () {
     //   gameObject.AddComponent<addAxe>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentState = state.shoot;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentState = state.mine;
		if(Input.GetKeyDown(KeyCode.Alpha3)
		   currentState = state.addVoxels;
        
		   if (changed)
        {
            switch(prevState)
            {
                case state.shoot:
                    break;
                case state.mine:
                    gameObject.GetComponent<addAxe>().enabled = false;
                    break;
                case state.die:
                    break;
                case state.addVoxels:
                    gameObject.GetComponent<MouseLook>().enabled = false;
                    break;
                case state.gui:
                    gameObject.GetComponent<MouseLook>().enabled = true;
                    break;
            }
            switch (currentState)
            {
                case state.shoot:
                    break;
                case state.mine:
                    gameObject.GetComponent<addAxe>().enabled = true;
                    break;
                case state.die:
                    break;
                case state.addVoxels:
                    gameObject.GetComponent<MouseLook>().enabled = true;
                    break;
                case state.gui:
                    gameObject.GetComponent<MouseLook>().enabled = false;
                    break;
            }
            changed = false;
        }
	}
}
