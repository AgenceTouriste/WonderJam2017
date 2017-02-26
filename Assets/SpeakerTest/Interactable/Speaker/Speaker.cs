using System;
using UnityEngine;

class Speaker : Interactable
{
    public override void Start()
    {
        base.Start();
    }   

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hi there", other.gameObject);
        if(other.CompareTag("Enemy"))
        RegisterAgent(other.GetComponent<StatePatternEnemy>());
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Ciao", other.gameObject);
        if (other.CompareTag("Enemy"))
            UnregisterAgent(other.GetComponent<StatePatternEnemy>());
    }
}