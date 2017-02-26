using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Order : Action
{
    public override void Execute(ICollection<StatePatternEnemy> collection)
    {
        foreach (StatePatternEnemy stuned in collection)
        {
            stuned.patrolState.Order();
        }
        GameObject.Find("SoundSystem").GetComponent<SoundSystem>().PlayOrder();
    }
}

