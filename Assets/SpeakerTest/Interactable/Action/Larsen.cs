using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Larsen : Action
{
    public override void Execute(ICollection<StatePatternEnemy> collection)
    {
        foreach (StatePatternEnemy stuned in collection)
        {
            stuned.patrolState.Larsen();
        }
    }
}

