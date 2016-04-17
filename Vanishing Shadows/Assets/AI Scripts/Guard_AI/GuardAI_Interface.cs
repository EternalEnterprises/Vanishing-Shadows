﻿using UnityEngine;
using System.Collections;
// all transition methodes between states in the guard AI
public interface GuardAI_Interface {

    //teling how to update the curent state
    void UpdateState();
    //returns true if the player is in front of the guard and inside of their sight radeose
    bool InSight();

    //Transition to Chase_State
    void ToChaseState();
    // Transition to Serch_State
    void ToSerchState();
    //transition to Patrol_State
    void ToPatrolState();
    //transition to Alert_State
    void ToAlertState();
    //change to Kill state and kill the player
    void ToKillState();

}
