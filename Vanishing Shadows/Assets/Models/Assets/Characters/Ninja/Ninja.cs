using UnityEngine;
using System.Collections;

public class Ninja : MonoBehaviour {
    [HideInInspector]
	public Animator anim;
    [HideInInspector]
    public bool sneaking = true;
	// Use this for initialization
	public float turnSmoothing = 15f;
	public float speedDampTime = 0.1f; 
	void Start () {

		anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");


		//Vector3 targetDirection = new Vector3(h, 0f, v);

		// Create a rotation based on this new vector assuming that up is the global y axis.
		//Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		//Quaternion newRotation = Quaternion.Lerp(Rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);

		// Change the players rotation to this new rotation.
		//Rigidbody.MoveRotation(newRotation);

	}

	// Update is called once per frame
	void Update () {
        //playing the appropreate animaiton depending on what is pressed
        if (!sneaking)
        {
            if (Input.GetKey("w"))
            {
                anim.SetBool("walking", true);
            }
            else {
                anim.SetBool("walking", false);
            }
            if (Input.GetKey("a"))
            {
                anim.SetBool("turn_Left", true);
            }
            else
            {
                anim.SetBool("turn_Left", false);
            }
            if (Input.GetKey("d"))
            {
                anim.SetBool("turn_Right", true);
            }
            else
            {
                anim.SetBool("turn_Right", false);
            }
            if (Input.GetKeyDown("space"))
            {
                anim.SetBool("sneaking", true);
                sneaking = true;
            }
        }
        else {
            if (Input.GetKey("w"))
            {
                anim.SetBool("walking", true);
            }
            else
            {
                anim.SetBool("walking", false);
            }
            if (Input.GetKey("a"))
            {
                anim.SetBool("turn_Left", true);
            }
            else
            {
                anim.SetBool("turn_Left", false);
            }
            if (Input.GetKey("d"))
            {
                anim.SetBool("turn_Right", true);
            }
            else
            {
                anim.SetBool("turn_Right", false);
            }
            if (Input.GetKeyDown("space"))
            {
                //anim.SetBool("sneaking", false);
                //sneaking = false;
            }
        }
	}
}
