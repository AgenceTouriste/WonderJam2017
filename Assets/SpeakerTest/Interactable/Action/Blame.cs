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
        if (this.gameObject.activeSelf)
        {
            bizut = input;
            actionManager.SendMessage("SpecialBlameExecutor");
        }
    }

    public void ActivateBlameSelector()
    {
        blameSelector.gameObject.SetActive(true);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
    }
}

