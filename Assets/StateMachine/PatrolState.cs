using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System;

public class PatrolState : IEnemyState

{
    private readonly StatePatternEnemy enemy;
    private int nextWayPoint;

    public PatrolState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Look();
        Patrol();
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
    {
        enemy.GetComponent<Animator>().SetBool("isMoving", true);
        enemy.GetComponent<Animator>().SetBool("isRunning", false);
        enemy.currentState = enemy.orderState;
    }

    public void ToOWaiterState()
    { }

    public void ToDistractState()
    {
        enemy.GetComponent<Animator>().SetBool("isMoving", true);
        enemy.GetComponent<Animator>().SetBool("isRunning", false);
        enemy.currentState = enemy.distractState;
    }

    public void ToDWaiterState()
    { }

    public void ToBlamerState()
    {
        enemy.GetComponent<Animator>().SetBool("isMoving", false);
        enemy.GetComponent<Animator>().SetBool("isRunning", true);
        enemy.currentState = enemy.blamerState;
    }

    public void ToVictimeState()
    {
        enemy.GetComponent<Animator>().SetBool("isMoving", true);
        enemy.GetComponent<Animator>().SetBool("isRunning", false);
        enemy.currentState = enemy.victimeState;
    }

    public void ToLarsenState()
    {
        enemy.GetComponent<Animator>().SetBool("isMoving", false);
        enemy.GetComponent<Animator>().SetBool("isRunning", false);
        enemy.currentState = enemy.larsenState;
    }


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

    void Patrol()
    {
        enemy.FOVFlag.GetComponent<MeshRenderer>().material.color = enemy.FOVWhite;
        if (enemy.wayPoints.Length > 1)
        {
            enemy.GetComponent<NavMeshAgent>().destination = enemy.wayPoints[nextWayPoint].position;
            enemy.GetComponent<NavMeshAgent>().Resume();

            if (enemy.GetComponent<NavMeshAgent>().remainingDistance <= enemy.GetComponent<NavMeshAgent>().stoppingDistance && !enemy.GetComponent<NavMeshAgent>().pathPending)
            {
                nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
            }
        }
        else
        {
            enemy.GetComponent<NavMeshAgent>().destination = enemy.wayPoints[0].position;
            enemy.GetComponent<NavMeshAgent>().Resume();

            if (enemy.GetComponent<NavMeshAgent>().remainingDistance <= enemy.GetComponent<NavMeshAgent>().stoppingDistance && !enemy.GetComponent<NavMeshAgent>().pathPending)
            {
                Vector3 to = new Vector3(0, enemy.direction, 0);
                if (Vector3.Distance(enemy.transform.eulerAngles, to) > 0.01f)
                {
                    enemy.transform.eulerAngles = Vector3.Lerp(enemy.transform.rotation.eulerAngles, to, Time.deltaTime);
                }
                else
                {
                    enemy.transform.eulerAngles = to;
                }
            }
        }
    }

    public void Order()
    {
        if ((enemy.GetComponent<StatePatternEnemy>().currentState == enemy.GetComponent<StatePatternEnemy>().patrolState)
            )
        {
            ToOrderState();
        }
    }

    public void Distract()
    {
        if ((enemy.GetComponent<StatePatternEnemy>().currentState == enemy.GetComponent<StatePatternEnemy>().patrolState)
            )
        {
            ToDistractState();
        }
    }

    public void Blame()
    {
        if ((enemy.GetComponent<StatePatternEnemy>().currentState == enemy.GetComponent<StatePatternEnemy>().patrolState)
            )
        {
            enemy.curTime = Time.time;
            ToBlamerState();
        }
    }

    public void Victimize()
    {
        if ((enemy.GetComponent<StatePatternEnemy>().currentState == enemy.GetComponent<StatePatternEnemy>().patrolState)
            )
        {
            enemy.curTime = Time.time;
            enemy.GetComponent<CapsuleCollider>().isTrigger = true;
            enemy.GetComponent<CapsuleCollider>().radius = 2.24f;
            ToVictimeState();
        }
    }

    public void Larsen()
    {
        enemy.angleofview = enemy.GetComponent<FieldOfView>().viewRadius;
        enemy.GetComponent<FieldOfView>().viewRadius = 0;
        enemy.curTime = Time.time;
        ToLarsenState();
    }

}