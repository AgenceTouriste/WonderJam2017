using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class BlamerState : IEnemyState

{
    private readonly StatePatternEnemy enemy;

    public BlamerState(StatePatternEnemy statePatternEnemy)
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
        enemy.GetComponent<Animator>().SetBool("isMoving", true);
        enemy.GetComponent<Animator>().SetBool("isRunning", false);
        enemy.currentState = enemy.patrolState;
    }

    public void ToAlertState()
    { }
    public void ToChaseState()
    {
        enemy.GetComponent<Animator>().SetBool("isMoving", false);
        enemy.GetComponent<Animator>().SetBool("isRunning", true);
        enemy.currentState = enemy.chaseState;
    }

    public void ToOrderState()
    { }

    public void ToOWaiterState()
    { }

    public void ToDistractState()
    { }

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
        if (Time.time - enemy.curTime >= enemy.waitB)
        {
            ToPatrolState();
        }
        else
        {
            if (Vector3.Distance(enemy.bullied.position, enemy.transform.position) > 2)
            {
                enemy.GetComponent<NavMeshAgent>().destination = enemy.bullied.position;
                enemy.GetComponent<NavMeshAgent>().Resume();
            }
        }
    }
}
