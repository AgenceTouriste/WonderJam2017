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
        if (found)
        {
            enemy.chaseTarget = target;
            enemy.GetComponent<CapsuleCollider>().isTrigger = false;
            enemy.GetComponent<CapsuleCollider>().radius = 1.12f;
            ToChaseState();
        }
    }
    public void WaitB()
    {
        if (Time.time - enemy.curTime >= enemy.waitB)
        {
            enemy.GetComponent<CapsuleCollider>().isTrigger = false;
            enemy.GetComponent<CapsuleCollider>().radius = 1.12f;
            ToPatrolState();
        }
    }
}
