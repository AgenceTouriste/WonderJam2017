using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

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

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            ToAlertState();
    }*/

    public void ToPatrolState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToAlertState()
    {}

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }

    public void ToOrderState()
    {
        Debug.Log("le bouton");
        enemy.currentState = enemy.orderState;
    }

    public void ToOWaiterState()
    {
        Debug.Log("Can't transition to this state");
    }

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

    void Patrol()
    {
        enemy.GetComponent<MeshRenderer>().material.color = Color.green;
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
                Vector3 to = new Vector3(0, enemy.direction , 0);
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
        ToOrderState();
    }
}