using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBlame : MonoBehaviour
{

    public GameObject victim;
    public GameObject bully;

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void Blame()
    {
        if (victim.GetComponent<StatePatternEnemy>().currentState != null)
        {
            if (victim.GetComponent<StatePatternEnemy>().currentState == victim.GetComponent<StatePatternEnemy>().patrolState)
            {
                bully.GetComponent<StatePatternEnemy>().bullied = victim.transform;
                victim.GetComponent<StatePatternEnemy>().patrolState.Victimize();
                bully.GetComponent<StatePatternEnemy>().patrolState.Blame();
            }
        }

    }
}
