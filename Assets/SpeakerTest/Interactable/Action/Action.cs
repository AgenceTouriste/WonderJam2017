using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {


    public ActionManager actionManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseEnter()
    {
        actionManager.ChooseAction(this);
        //Change texture to selected
        //Set self as selected button
    }

    private void OnMouseExit()
    {
        actionManager.ResetAction();
        //Change texture to unselected
        //Reset selected button
    }
}
