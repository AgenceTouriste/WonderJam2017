using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Larsen : Action
{
    public GameObject toDestroy;
    public override void Execute(ICollection<StatePatternEnemy> collection)
    {
        foreach (StatePatternEnemy stuned in collection)
        {
            stuned.patrolState.Larsen();
        }
        GameObject.Find("SoundSystem").GetComponent<SoundSystem>().PlayLarsen();
        toDestroy.GetComponentInChildren<Canvas>().enabled = false;
        toDestroy.GetComponentInChildren<MeshRenderer>().enabled = false;
    }

    
}

