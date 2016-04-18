using UnityEngine;
using System.Collections;

public class Serch_State : GuardAI_Interface
{

    private readonly Guard_Controler guard;
    private float serchTime;

    public Serch_State(Guard_Controler guardControler)
    {
        guard = guardControler;
        serchTime = 0f;
    }

    //looking around the emeadiot area for a speciphied number of frams
    public void UpdateState()
    {
        //set guards sight cone to yello
        guard.SightCone.color = Color.yellow;
        //turn around looking for the player untill time runs out
        guard.transform.Rotate(0, guard.serchingTurnSpeed * Time.deltaTime, 0);

        //incroment serch time
        serchTime += Time.deltaTime;

        //check to see if serchTime has run out
        if (serchTime >= guard.serchTimeCap)
        {
            //return to parole you can not find the Player
            ToPatrolState();
        }
    }

    //triggers if the player walks within the sight radios as denoted by the spheirColider
    public void OnTriggerEnter(Collider other)
    {
        // you have seen the Player change to allert state
        ToAlertState();
    }

    //if #of frames is exosted then return to patrole_State
    public void ToPatrolState()
    {
        //reseting TimeSerched for the next time serch state is called
        serchTime = 0f;
        guard.currentState = guard.patrolState;
    }

    //this guard has seen the player transition into alert_State and set NavePointIntruder to players curent location
    public void ToAlertState()
    {
        guard.navMeshAgent.Stop();
        //show visual feed back that the guard has spoted you.

        //reseting TimeSerched for the next time serch state is called
        serchTime = 0f;
        guard.navMeshAgent.Stop();
        guard.currentState = guard.alertState;
    }

    //can not transition to this state from here
    public void ToSerchState() {
        Debug.Log(" Guard can't transtion to Serch_State from Serch_State. ");
    }
}
