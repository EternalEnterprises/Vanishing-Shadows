using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {
	public int slider;
	void Update()
	{
		transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime * slider,0f,Input.GetAxis("Vertical")*Time.deltaTime * slider);

	}
}