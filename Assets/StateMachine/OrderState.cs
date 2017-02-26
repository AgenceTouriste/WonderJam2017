using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class OrderState : IEnemyState

{
    private readonly StatePatternEnemy enemy;

    public OrderState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Look();
        OrderGoto();
    }

    public void OnTriggerEnter(Collider other)
    { }

    public void ToPatrolState()
    {
        Debug.Log("Can't transition to this state");
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
        enemy.currentState = enemy.owaiterState;
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

    void OrderGoto()
    {
        enemy.flag.GetComponent<MeshRenderer>().material.color = Color.cyan;
        //enemy.GetComponent<MeshRenderer>().material.color = Color.cyan;
        enemy.GetComponent<NavMeshAgent>().destination = enemy.camp.position;
        enemy.GetComponent<NavMeshAgent>().Resume();
        if (enemy.GetComponent<NavMeshAgent>().remainingDistance <= enemy.GetComponent<NavMeshAgent>().stoppingDistance && !enemy.GetComponent<NavMeshAgent>().pathPending)
            {
            enemy.curTime = Time.time;
            ToOWaiterState();
        }
    }
}