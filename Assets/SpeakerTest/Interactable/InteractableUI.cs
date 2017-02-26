using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableUI : MonoBehaviour {

    GameObject UI;
    public float deadZone;
    // Use this for initialization
    void Start () {
        UI = GetComponentInChildren<Canvas>(true).gameObject;
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnMouseDown()
    {
        UI.SetActive(true);
        BroadcastMessage("TriggerAoE");
    }

    private void HeyAoE()
    {
        BroadcastMessage("TriggerAoE");
    }

    private void OnMouseUp()
    {
        UI.GetComponent<ActionManager>().ExecuteAction();
        //UI.SetActive(false);
    }
}
