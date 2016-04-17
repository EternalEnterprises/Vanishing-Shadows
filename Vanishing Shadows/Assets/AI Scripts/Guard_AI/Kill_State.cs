using UnityEngine;
using System.Collections;

public class Kill_State : GuardAI_Interface
{

    //teling how to update the curent state
    void UpdateState() {

    }
    //can not go anywhere from here
    bool InSight() { }
    void ToChaseState() { }
    void ToPatrolState() { }
    void ToAlertState() { }
    void ToKillState() { }
}