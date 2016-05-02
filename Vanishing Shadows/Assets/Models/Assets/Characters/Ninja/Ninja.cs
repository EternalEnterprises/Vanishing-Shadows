using UnityEngine;
using System.Collections;

public class Ninja : MonoBehaviour {

	public Animator anim;
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


	}
}
