using System;
using UnityEngine;

class Screen : Interactable
{

    public override void Start()
    {
        base.Start();
    }

    public new void RegisterAgent(StatePatternEnemy agent)
    {
        base.RegisterAgent(agent);
    }

    public new void UnregisterAgent(StatePatternEnemy agent)
    {
        base.UnregisterAgent(agent);
    }
}