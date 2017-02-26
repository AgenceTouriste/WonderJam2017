using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class LarsenState : IEnemyState

{
    private readonly StatePatternEnemy enemy;

    public LarsenState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Stuned();
    }

    public void OnTriggerEnter(Collider other)
    { }

    public void ToPatrolState()
    { }

    public void ToAlertState()
    {
        enemy.currentState = enemy.alertState;
    }
    public void ToChaseState()
    { }

    public void ToOrderState()
    {}

    public void ToOWaiterState()
    {}

    public void ToDistractState()
    {    }

    public void ToDWaiterState()
    { }

    public void ToBlamerState()
    { }

    public void ToVictimeState()
    { }

    public void ToLarsenState()
    { }

    public void Stuned()
    {
        enemy.GetComponent<NavMeshAgent>().Stop();
        enemy.flag.GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0, 0, 1);
        //enemy.GetComponent<MeshRenderer>().material.color = new Color(0.5f , 0 , 0 , 1);
        if (Time.time - enemy.curTime >= enemy.waitL)
        {
            enemy.GetComponent<FieldOfView>().viewRadius = enemy.angleofview;
            ToAlertState();
        }
    }
}