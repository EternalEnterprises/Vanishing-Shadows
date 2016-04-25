using UnityEngine;
using System.Collections;

public class Guard_Controler : MonoBehaviour
{
    //setting variobuls that will be used across the Guards AI States
    public GameObject SightConeObj;
    public GameObject EyesObj;
    public float suspucionCap = 10f;
    public float serchTimeCap = 5f;
    public float serchingTurnSpeed = 100f;
    public float walkingSpeed = 4f;
    public float runingSpeed = 8f;
    public float sightRange = 30f;
    public Transform[] navPointsPatrol;
    public Transform navPointIntruder;
    public Vector3[] offset = new Vector3[13];

    [HideInInspector]
    public GuardAI_Interface currentState;
    [HideInInspector]
    public Alert_State alertState;
    [HideInInspector]
    public Serch_State serchState;
    [HideInInspector]
    public Patrol_State patrolState;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    [HideInInspector]
    public Animator guardMovment;
    [HideInInspector]
    public Light SightCone;
    [HideInInspector]
    public Transform Eyes;
    [HideInInspector]
    public Vector3 sightLine;
    [HideInInspector]
    public float sightReduction = 1;
    //creating the states
    private void Awake()
    {
        alertState = new Alert_State(this);
        serchState = new Serch_State(this);
        patrolState = new Patrol_State(this);
        navMeshAgent = GetComponent<NavMeshAgent>();
        guardMovment = GetComponent<Animator>();
        SightCone = SightConeObj.GetComponentInChildren<Light>();
        Eyes = EyesObj.GetComponentInChildren<Transform>();

    }

    // Use this for initialization
    void Start()
    {
        currentState = patrolState;
    }

    // Update is called once per frame
    void Update()
    {
        //updates the curent state
        currentState.UpdateState();
    }

    //tiggers when the guards sight radios colides with somehting 
    private void OnTriggerStay(Collider other)
    {
        //cheks to see if the player is within the guards sight limits.
        if (other.CompareTag("Player"))
        {
            //raycasts to see if the guard can see the Player
            RaycastHit hit;
            //cycaling thru all 13 rays
            for (int i = 0; i < offset.Length; i++)
            {
                //print("Ray loop");
                //reducing sight range if ray is parrifary vison
                sightReduction = 1;
                switch (i)
                {
                    case 0:
                    case 12:
                        sightReduction = 4f;
                        break;
                    case 1:
                    case 11:
                        sightReduction = 3f;
                        break;
                    case 2:
                    case 10:
                        sightReduction = 1.60f;
                        break;
                    case 3:
                    case 9:
                        sightReduction = 1.30f;
                        break;
                    default:
                        sightReduction = 1f;
                        break;
                }
                sightLine = Quaternion.Euler(offset[i]) * Eyes.forward;
                Ray sightRay = new Ray(Eyes.position, sightLine);
                //Debug.DrawRay(Eyes.position, sightRay.direction * (sightRange / sightReduction), Color.red);
                if (Physics.Raycast(sightRay, out hit, sightRange / sightReduction) && hit.collider.CompareTag("Player"))
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
