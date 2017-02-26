using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Distract : Action
{
    public GameObject distraction;
    public override void Execute(ICollection<StatePatternEnemy> collection)
    {
        foreach (StatePatternEnemy stuned in collection)
        {
            stuned.distraction = distraction.transform;
            stuned.patrolState.Distract();
        }
    }
}

