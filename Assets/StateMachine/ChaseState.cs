using UnityEngine;
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
        List<Transform> visibleobjects = enemy.GetComponent<FieldOfView>().visibleTargets;
        foreach (Transform obj in visibleobjects)
        {
            if (obj.CompareTag("Player"))
            {
                enemy.chaseTarget = obj;
            }
            else
            {
                ToAlertState();
            }
        }
    }

    private void Chase()
    {
        enemy.GetComponent<MeshRenderer>().material.color = Color.red;
        enemy.GetComponent<NavMeshAgent>().destination = enemy.chaseTarget.position;
        enemy.GetComponent<NavMeshAgent>().Resume();
    }
}