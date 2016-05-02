using UnityEngine;
using System.Collections;
// all transition methodes between states in the guard AI
public interface GuardAI_Interface {

    //teling how to update the curent state
    void UpdateState();
    //returns true if the guard can see the player
    void visible();
    //returns true if the player is withen range of the guard to apprehend
    void OnTriggerEnter(Collider other);

    // Transition to Serch_State
    void ToSerchState();
    //transition to Patrol_State
    void ToPatrolState();
    //transition to Alert_State
    void ToAlertState();
}
