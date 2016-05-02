using UnityEngine;
using System.Collections;

public class Alert_State : GuardAI_Interface
{
    private readonly Guard_Controler guard;
    private float suspicion;

    public Alert_State(Guard_Controler guardControler)
    {
        guard = guardControler;
        suspicion = 0f;
    }

    //teling how to update the curent state
    public void UpdateState()
    {
        //set guards sight cone to red.
        if (suspicion < guard.suspucionCap)
        {
            guard.SightCone.color = Color.yellow;
            guard.guardMovment.SetBool("IsWalking", true);
            guard.guardMovment.SetBool("IsRunning", false);
            guard.guardMovment.SetBool("isIdle", false);
            guard.guardMovment.SetBool("isAttacking", false);
        }
        else {
            guard.SightCone.color = Color.red;
            guard.guardMovment.SetBool("IsWalking", false);
            guard.guardMovment.SetBool("IsRunning", true);
            guard.guardMovment.SetBool("isIdle", false);
            guard.guardMovment.SetBool("isAttacking", false);
        }
        //seting the guards navigation to where he saw you last
        guard.navMeshAgent.destination = guard.navPointIntruder.position;
        guard.navMeshAgent.Resume();
        //cheking to see if you have made it to the last place you saw the Player
        if (guard.navMeshAgent.remainingDistance <= guard.navMeshAgent.stoppingDistance && !guard.navMeshAgent.pathPending)
        {
            //you have lost the player transition into serch state
            ToSerchState();
        }

    }

    //triggers if the player walks within the sight radios as denoted by the spheirColider
   public void OnTriggerEnter(Collider other)
    {

    }

    // Transition to Serch_State
    public void ToSerchState()
    {
        guard.navMeshAgent.Stop();
        //reset guards suspition for next allert
        suspicion = 0f;
        //making shure the guard is walking
        guard.navMeshAgent.speed = guard.walkingSpeed;
        guard.currentState = guard.serchState;
    }

    //returns true if the guard can see the player
   public void visible()
    {
        suspicion++;
    }

    //Can not Transioin to these States from hear
    public void ToAlertState() {
        Debug.Log(" Guard can not transioin to Alert_State from Alert_State. ");
    }
    public void ToPatrolState(){
        Debug.Log(" Guard can not transioin to PatrolState from Alert_State. ");
    }
}
