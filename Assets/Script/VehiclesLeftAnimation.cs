using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclesLeftAnimation : MonoBehaviour
{

    public int vehiclespeed;
    public int maxdistance;
    public Vector3 spawnPoint;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < maxdistance)
        {
            transform.position = spawnPoint;

        }
        else
        {
            transform.Translate(new Vector3(-vehiclespeed, 0, 0));
        }
    }
}
