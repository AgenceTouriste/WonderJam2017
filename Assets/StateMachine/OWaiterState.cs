using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class OWaiterState : IEnemyState

{
    private readonly StatePatternEnemy enemy;

    public OWaiterState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Look();
        WaitO();
    }

    public void OnTriggerEnter(Collider other)
    { }

    public void ToPatrolState()
    {
        //Debug.Log("Can't transition to this state");
        enemy.currentState = enemy.patrolState;
    }

    public void ToAlertState()
    {}
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
    { }

    public void ToBlamerState()
    { }

    public void ToVictimeState()
    { }

    public void ToLarsenState()
    { }

    /*private void Look()
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
    }*/
    private void Look()
    {
        bool found = false;
        Transform target = null;
        List<Transform> visibleobjects = enemy.GetComponent<FieldOfView>().visibleTargets;
        foreach (Transform obj in visibleobjects)
        {
            if (obj.CompareTag("Player"))
            {
                target = obj;
                found = true;
            }
        }
        if (found) { enemy.chaseTarget = target; ToChaseState(); }
    }

    public void WaitO()
    {
        if (Time.time - enemy.curTime >= enemy.waitO)
        {
            ToPatrolState();
        }       
    }
}