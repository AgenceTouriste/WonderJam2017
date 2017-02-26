using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using System.Collections.Generic;

public class VictimeState : IEnemyState

{
    private readonly StatePatternEnemy enemy;

    public VictimeState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Look();
        WaitB();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            enemy.GetComponent<NavMeshAgent>().Stop();
    }

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
    { }

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
                enemy.GetComponent<BoxCollider>().isTrigger = false;
                enemy.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
                ToChaseState();
            }
        }
    }

    public void WaitB()
    {
        enemy.GetComponent<MeshRenderer>().material.color = Color.white;
        
        if (Time.time - enemy.curTime >= enemy.waitB)
        {
            enemy.GetComponent<BoxCollider>().isTrigger = false;
            enemy.GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
            ToPatrolState();
        }
    }
}
