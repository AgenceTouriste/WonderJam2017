using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class DistractState : IEnemyState

{
    private readonly StatePatternEnemy enemy;

    public DistractState(StatePatternEnemy statePatternEnemy)
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
    { }

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
    {
        enemy.GetComponent<Animator>().SetBool("isMoving", false);
        enemy.GetComponent<Animator>().SetBool("isRunning", false);
        enemy.currentState = enemy.dwaiterState;
    }

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
        enemy.GetComponent<NavMeshAgent>().destination = enemy.distraction.position;
        enemy.GetComponent<NavMeshAgent>().Resume();
        if (Vector3.Distance(enemy.distraction.position, enemy.transform.position) < 4)
        {
            enemy.curTime = Time.time;
            ToDWaiterState();
        }
    }
}
