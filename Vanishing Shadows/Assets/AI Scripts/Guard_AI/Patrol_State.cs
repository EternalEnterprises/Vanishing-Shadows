using UnityEngine;
using System.Collections;

public class Patrol_State : GuardAI_Interface {


    //teling how to update the curent state
    void UpdateState() {
        //check to see if this guard is on the NavPoint at front of que
        //if () {
            //remove the NavPaint at begining of que and add it to the end

        //}
        //cheking if player is within sight
        if (InSight()) {
            ToAlertState();
        }
        ToPatrolState();
    }

    //if seen transition into allert state
    bool InSight(){
    
    }

    //continuing to fallow the pattrole pattern
    void ToPatrolState() {

    }

    //player seen set NavePointIntruder to players curent vector
    void ToAlertState() {

    }

    //can not transition to these states from Patrol
    void ToChaseState() { }
    void ToSerchState() { }
    void ToKillState() { }

}
