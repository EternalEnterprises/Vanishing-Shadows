using UnityEngine;
using System.Collections;

public class Guard_Controler : MonoBehaviour {
    //setting variobuls that will be used across the Guards AI States
    public float suspucionCap = 10f;
    public float serchTimeCap = 5f;
    public float serchingTurnSpeed = 100f;
    public float walkingSpeed = 4f;
    public float runingSpeed = 8f;
    public float sightRange = 20f;
    public Transform [] navPointsPatrol;
    public Transform navPointIntruder;
    public Transform Eyes;
    public Light SightCone;
    public Vector3 offset = new Vector3(0, .5f, 0);

    [HideInInspector] public GuardAI_Interface currentState;
    [HideInInspector] public Alert_State alertState;
    [HideInInspector] public Serch_State serchState;
    [HideInInspector] public Patrol_State patrolState;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Animator guardMovment;

    //creating the states
    private void Awake() {
        alertState = new Alert_State(this);
        serchState = new Serch_State(this);
        patrolState = new Patrol_State(this);
        navMeshAgent = GetComponent<NavMeshAgent> ();
        guardMovment = GetComponent<Animator> ();
    }

    // Use this for initialization
    void Start () {
        currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update () {
        //updates the curent state
        currentState.UpdateState();
	}

    //tiggers when the guards sight radios colides with somehting 
    private void OnTriggerEnter(Collider other) {
        //cheks to see if the player is within the guards sight limits.
        if (other.CompareTag("Player")) {
            //raycasts to see if the guard can see the Player
            RaycastHit hit;
            //cheking to see if the ray cast hits the Player.
            if (Physics.Raycast(Eyes.transform.position, Eyes.transform.forward, out hit, sightRange) && hit.collider.CompareTag("Player"))
            {
               //set the intruder nav point to the players curent vector
                navPointIntruder.position = other.transform.position;
                currentState.OnTriggerEnter(other);

            }
        }
    }
}
