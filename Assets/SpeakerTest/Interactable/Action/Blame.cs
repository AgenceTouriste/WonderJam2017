using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class Blame : Action
{
    public bool ready;
    public GameObject bizut;
    public BlameSelector blameSelector;
    public Canvas overlay;

    private void Start()
    {
        ready = false;
    }
    private void Update()
    {
        if(ready)
        {
            if(Input.GetKeyDown("space"))
            {
                blameSelector.gameObject.SetActive(false);
                overlay.gameObject.SetActive(false);
                gameObject.GetComponentInParent<Canvas>().enabled = true;
                ready = false;
                actionManager.ResetAction();
                actionManager.SendMessage("SpecialBlameExecutor");
            }
        }
    }
    public override void Execute(ICollection<StatePatternEnemy> collection)
    {
        bizut.GetComponent<StatePatternEnemy>().patrolState.Victimize();
        foreach (StatePatternEnemy stuned in collection)
        {
            if (stuned != bizut)
            {
                stuned.bullied = bizut.transform;
                stuned.patrolState.Blame();
            }
        }
        bizut = null;
    }

    public void OnBizutFound(GameObject input)
    {
        {
            bizut = input;
            actionManager.SendMessage("SpecialBlameExecutor");
            overlay.gameObject.SetActive(false);
            gameObject.GetComponentsInParent<Canvas>(true)[0].enabled = true;
            ready = false;
        }
    }

    public void ActivateBlameSelector()
    {
        ready = true;
        overlay.gameObject.SetActive(true);
        blameSelector.gameObject.SetActive(true);
        gameObject.GetComponentsInParent<Canvas>(true)[0].enabled = false;
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
    }
}

