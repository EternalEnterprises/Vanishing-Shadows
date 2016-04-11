using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class checkpointScript : MonoBehaviour {
	public int level;

	void OnTriggerEnter(Collider other){
		PlayerPrefs.SetInt (level.ToString(), 1);
		SceneManager.LoadScene (0);
	}
}
