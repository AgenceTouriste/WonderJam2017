using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class DWaiterState : IEnemyState

{
    private readonly StatePatternEnemy enemy;

    public DWaiterState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Look();
        WaitD();
    }

    public void OnTriggerEnter(Collider other)
    { }

    public void ToPatrolState()
    {
        //Debug.Log("Can't transition to this state");
        enemy.currentState = enemy.patrolState;
    }

    public void ToAlertState()
    { }
    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }

    public void ToOrderState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToOWaiterState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToDistractState()
    {
        enemy.currentState = enemy.distractState;
    }

    public void ToDWaiterState()
    {}

    public void ToBlamerState()
    { }

    public void ToVictimeState()
    { }

    public void ToLarsenState()
    { }

    private void Look()
    {
        List<Transform> visibleobjects = enemy.GetComponent<FieldOfView>().visibleTargets;
        foreach (Transform obj in visibleobjects)
        {
            if (obj.CompareTag("Player"))
            {
                enemy.chaseTarget = obj;
                ToChaseState();
            }
        }
    }

    public void WaitD()
    {
        enemy.GetComponent<MeshRenderer>().material.color = Color.grey;
        if (Time.time - enemy.curTime >= enemy.waitD)
        {
            ToPatrolState();
        }
    }
}
