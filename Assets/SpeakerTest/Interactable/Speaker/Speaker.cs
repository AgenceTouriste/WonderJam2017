using System;
using UnityEngine;

class Speaker : Interactable
{
    public Collider2D areaOfEffect;

    public override void Start()
    {
        base.Start();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        RegisterAgent(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        UnregisterAgent(other.gameObject);
    }
}