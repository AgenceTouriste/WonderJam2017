using System;
using UnityEngine;

class Screen : Interactable
{

    public override void Start()
    {
        base.Start();
    }

    public new void RegisterAgent(GameObject agent)
    {
        base.RegisterAgent(agent);
    }

    public new void UnregisterAgent(GameObject agent)
    {
        base.UnregisterAgent(agent);
    }
}