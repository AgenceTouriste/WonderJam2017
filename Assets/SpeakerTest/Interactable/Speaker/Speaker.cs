using System;
using UnityEngine;

class Speaker : Interactable
{
    public SphereCollider areaOfEffect;

    public override void Start()
    {
        base.Start();
    }
    
    void OnTriggerEnter(Collider other)
    {
        RegisterAgent(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        UnregisterAgent(other.gameObject);
    }
}