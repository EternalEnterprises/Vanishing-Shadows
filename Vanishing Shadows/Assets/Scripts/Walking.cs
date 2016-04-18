using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {

	void Update()
	{
	transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime,0f,Input.GetAxis("Vertical")*Time.deltaTime);

	}
}