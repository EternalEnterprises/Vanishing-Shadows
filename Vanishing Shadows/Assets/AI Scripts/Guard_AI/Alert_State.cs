using UnityEngine;
using System.Collections;

public class Alert_State : GuardAI_Interface
{

    //teling how to update the curent state
    void UpdateState()
    {
    }

    //returns true if the player is in front of the guard and inside of their sight radeose
    bool InSight()
    {

    }

    //Transition to Chase_State
    void ToChaseState()
    {

    }

    // Transition to Serch_State
    void ToSerchState()
    {

    }

    //transition to Patrol_State
    void ToPatrolState() {

    }

    //Continue to be allerted
    void ToAlertState() {

    }

    //Can not Transition to this from hear
    void ToKillState() { }
}
