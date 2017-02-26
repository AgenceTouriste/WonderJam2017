using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLarsen : MonoBehaviour
{

    public GameObject[] larsened;

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void Larsen()
    {
        foreach (GameObject stuned in larsened)
        {
            stuned.GetComponent<StatePatternEnemy>().patrolState.Larsen();
        }
    }
}