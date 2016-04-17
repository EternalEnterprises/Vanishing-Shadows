using UnityEngine;
using System.Collections;

public class Chase_State : GuardAI_Interface
{


    //teling how to update the curent state
    void UpdateState()
    {
        
    }

    //determanse if guard remains in Chase_State
    bool InSight()
    {

    }

    //Continuing to chase the player
    void ToChaseState() {

    }

    //If player is no longer in sight transition to Alert_State but leave NavPointIntruder where it is
    void ToAlertState()
    {

    }

    //if you colide with the player transition to Kill_State
    void ToKillState()
    {

    }

    //can not transition to this state from here
    void ToPatrolState() {}
    void ToSerchState() {}
}
