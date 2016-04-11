using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class checkpointScript : MonoBehaviour {
	public int level;
<<<<<<< HEAD

	void OnTriggerEnter(Collider other){
		PlayerPrefs.SetInt (level.ToString(), 1);
		SceneManager.LoadScene (0);
=======
	public int levelCount = 3;

	void OnTriggerEnter(Collider other){
		PlayerPrefs.SetInt (level.ToString(), 1);
		if (level < levelCount) {
			SceneManager.LoadScene (level + 1);
		} else {
			SceneManager.LoadScene (0);
		}
>>>>>>> refs/remotes/origin/mechanics
	}
}
