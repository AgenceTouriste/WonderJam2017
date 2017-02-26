using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class AlertState : IEnemyState

{
    private readonly StatePatternEnemy enemy;
    private float searchTimer;

    public AlertState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Look();
        Search();
    }

    public void OnTriggerEnter(Collider other)
    { }

    public void ToPatrolState()
    {
        enemy.currentState = enemy.patrolState;
        searchTimer = 0f;
    }

    public void ToAlertState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
        searchTimer = 0f;
    }

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
                ToChaseState();
            }
        }
    }

    private void Search()
    {
        enemy.GetComponent<MeshRenderer>().material.color = Color.yellow;
        enemy.GetComponent<NavMeshAgent>().Stop();
        enemy.transform.Rotate(0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
        searchTimer += Time.deltaTime;
        if (searchTimer >= enemy.searchingDuration)
        {
            ToPatrolState();
        }    
    }
}
