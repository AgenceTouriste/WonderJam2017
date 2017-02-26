using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDistract : MonoBehaviour {
    public Transform Interactive;
    public GameObject[] enemies;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*public void Distract()
    {
        GetComponent<DistractSelector>().enabled = true; 
    }*/
    public void Distract()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<StatePatternEnemy>().distraction = Interactive;
            enemy.GetComponent<StatePatternEnemy>().patrolState.Distract();
        }
    }
}
