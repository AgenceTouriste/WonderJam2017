using UnityEngine;
using System.Collections;

public interface IEnemyState
{

    void UpdateState();

    void OnTriggerEnter(Collider other);

    void ToPatrolState();

    void ToAlertState();

    void ToChaseState();

    void ToOrderState();

    void ToOWaiterState();

    void ToDistractState();

    void ToDWaiterState();

    void ToBlamerState();

    void ToVictimeState();

    void ToLarsenState();
}
