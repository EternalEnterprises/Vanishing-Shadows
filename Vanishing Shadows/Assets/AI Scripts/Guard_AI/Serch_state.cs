using UnityEngine;
using System.Collections;

public class Serch_state : GuardAI_Interface
{


    //looking around the emeadiot area for a speciphied number of frams
    void UpdateState(int serchTime)
    {

        if (InSight()) {
            ToAlertState();
        }
        serchTime--;
        if (serchTime <= 0) {
            ToPatrolState();
        }
        ToSerchState();

    }

    //player is seen call ToAlertState
    bool InSight()
    {

    }

    //remaning in the search state untill time runs out
    void ToSerchState() {

    }
    
    //if #of frames is exosted then return to patrole_State
    void ToPatrolState()
    {

    }

    //this guard has seen the player transition into alert_State and set NavePointIntruder to players curent location
    void ToAlertState()
    {

    }
    //can not transition to these states from Serch
    void ToKillState() { }
    void ToChaseState() { }
}
