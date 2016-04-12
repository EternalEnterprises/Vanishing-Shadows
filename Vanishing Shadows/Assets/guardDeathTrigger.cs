using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class guardDeathTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other){
		PlayerPrefs.SetInt ("death", 1);
	}
}
