using UnityEngine;
using System.Collections;

public class Guard_Controler : MonoBehaviour {
    //setting variobuls that will be used across the Guards AI States
    public GameObject SightConeObj;
    public GameObject EyesObj;
    public float suspucionCap = 10f;
    public float serchTimeCap = 5f;
    public float serchingTurnSpeed = 100f;
    public float walkingSpeed = 4f;
    public float runingSpeed = 8f;
    public float sightRange = 30f;
    public Transform [] navPointsPatrol;
    public Transform navPointIntruder;
    public Vector3[] offset = new Vector3[5];

    [HideInInspector] public GuardAI_Interface currentState;
    [HideInInspector] public Alert_State alertState;
    [HideInInspector] public Serch_State serchState;
    [HideInInspector] public Patrol_State patrolState;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Animator guardMovment;
    [HideInInspector] public Light SightCone;
    [HideInInspector] public Transform Eyes;

    //creating the states
    private void Awake() {
        alertState = new Alert_State(this);
        serchState = new Serch_State(this);
        patrolState = new Patrol_State(this);
        navMeshAgent = GetComponent<NavMeshAgent> ();
        guardMovment = GetComponent<Animator> ();
        SightCone = SightConeObj.GetComponentInChildren<Light>();
        Eyes = EyesObj.GetComponentInChildren<Transform>();

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
    private void OnTriggerStay(Collider other) {
        //cheks to see if the player is within the guards sight limits.
        if (other.CompareTag("Player")) {
            //raycasts to see if the guard can see the Player
            RaycastHit hit;
            //cycaling thru all 5 rays
            for (int i = 0; i < offset.Length; i++) {
                //print("Ray loop");
                Ray sightRay = new Ray(Eyes.position, Eyes.forward - offset[i]);
                //Debug.DrawRay(Eyes.position, sightRay.direction*sightRange, Color.red);
                if (Physics.Raycast(sightRay, out hit, sightRange) && hit.collider.CompareTag("Player"))
                {
                    //set the intruder nav point to the players curent vector
                    print("sean player");
                    navPointIntruder.position = other.transform.position;
                    currentState.OnTriggerStay(other);
                }
            }
        }
    }
}
