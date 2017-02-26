using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Action : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


    public ActionManager actionManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnMouseOver()
    {
        Debug.Log("TROLLLLLL");
    }

    public abstract void Execute(ICollection<StatePatternEnemy> collection);

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        actionManager.ResetAction();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        actionManager.ChooseAction(this); 
    }
}
