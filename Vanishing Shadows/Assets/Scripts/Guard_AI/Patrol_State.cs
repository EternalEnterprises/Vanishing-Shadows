using UnityEngine;
using System.Collections;

public class Patrol_State : GuardAI_Interface {
    private readonly Guard_Controler guard;
    private int nextNavPoint;

    public Patrol_State(Guard_Controler guardControler) {
        guard = guardControler;
        nextNavPoint = 0;
    }

    //teling how to update the curent state
    public void UpdateState() {
        //set guards sight cone to white
        guard.SightCone.color = Color.white;
        //making sure the guard is walking 
        guard.navMeshAgent.speed = guard.walkingSpeed;
        //seting destonation to the next nav point in the patrole
        guard.navMeshAgent.destination = guard.navPointsPatrol[nextNavPoint].position;
        guard.navMeshAgent.Resume();
        //cheking to see if you have made it to the next patrole point yet
        if (guard.navMeshAgent.remainingDistance <= guard.navMeshAgent.stoppingDistance && !guard.navMeshAgent.pathPending) {
            //looping to the next patrole navPoint
            nextNavPoint = (nextNavPoint + 1) % guard.navPointsPatrol.Length;
        }
    }


    //triggers if the guard can see the player
    public void OnTriggerEnter(Collider other)
    {
            //go and investigate
            ToAlertState();
    }


    //continuing to fallow the pattrole pattern
    public void ToPatrolState() {
        Debug.Log(" Can't transition to Patrol_State from Patrol_State. ");
    }

    //player seen set NavePointIntruder to players curent vector
    public void ToAlertState() {
        guard.navMeshAgent.Stop();
        //show visual feed back that the guard has spoted you.

        guard.currentState = guard.alertState;
    }

    //can not transition to these states from Patrol
    public void ToSerchState() {
        Debug.Log(" Can't transition to Serch_State from Patrol_State. ");
    }


}
