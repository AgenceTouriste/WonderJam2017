﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class ChaseState : IEnemyState

{

    private readonly StatePatternEnemy enemy;

    public ChaseState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Look();
        Chase();
    }

    public void OnTriggerEnter(Collider other)
    { }

    public void ToPatrolState()
    {}

    public void ToAlertState()
    {
        enemy.currentState = enemy.alertState;
    }

    public void ToChaseState()
    {}

    public void ToOrderState()
    {
        Debug.Log("Can't transition from alert to order state");
    }

    public void ToOWaiterState()
    {
        Debug.Log("Can't transition to this state");
    }

    public void ToDistractState()
    {}

    public void ToDWaiterState()
    { }

    public void ToBlamerState()
    { }

    public void ToVictimeState()
    { }

    public void ToLarsenState()
    { }

    private void Look()
    {
        bool found=false;
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
        if (found) { enemy.chaseTarget = target; }
        else { ToAlertState(); }
    }

    private void Chase()
    {
        enemy.FOVFlag.GetComponent<MeshRenderer>().material.color = enemy.FOVRed;
        enemy.GetComponent<NavMeshAgent>().destination = enemy.chaseTarget.position;
        enemy.GetComponent<NavMeshAgent>().Resume();
    }
}