using UnityEngine;
using System.Collections;

public class Ninja : MonoBehaviour {

	public Animator anim;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("a")) 

		{
			anim.Play("crouched_sneaking_right", -1, 0f);

			print("Pressed input");
		}

		if(Input.GetKeyDown("c")) 

		{
			anim.Play("Male_Crouch_Pose", -1, 0f);

			print("Pressed input");
		}

		if (Input.GetKeyDown ("j")) 
		{
			anim.Play("jumping", -1, 0.25f);
		}

	}
}
