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
    [HideInInspector]
    public bool playerDeath = false;

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
        playerDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDeath)
        {
            //updates the curent state
            visible();
            currentState.UpdateState();
        }
        else {

        }
    }

    //tiggers when the guards sight radios colides with somehting 
    private void OnTriggerEnter(Collider other)
    {
        //cheks to see if the player is within the guards sight limits.
        if (other.CompareTag("Player"))
        {
            playerDeath = true;
            transform.rotation.Set(transform.rotation.x, other.transform.rotation.y - transform.rotation.y, transform.rotation.z, transform.rotation.w);
            guardMovment.SetBool("IsWalking", false);
            guardMovment.SetBool("IsRunning", false);
            guardMovment.SetBool("isIdle", false);
            guardMovment.SetBool("isAttacking", true);

            StartCoroutine(attack_Delay());
        }
    }

    //cuses a delay befor the guard kills you to let part of the swing animation play
    IEnumerator attack_Delay()
    {
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("death", 1);
    }

    //returns true if the guard can see the player
    private void visible()
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
            Debug.DrawRay(Eyes.position, sightRay.direction * (sightRange / sightReduction), Color.red);
            if (Physics.Raycast(sightRay, out hit, sightRange / sightReduction) && hit.collider.CompareTag("Player"))
            {
                //set the intruder nav point to the players curent vector
                //print("sean player");
                navPointIntruder.position = hit.transform.position;
                currentState.visible();
            }
        }
    }
}
