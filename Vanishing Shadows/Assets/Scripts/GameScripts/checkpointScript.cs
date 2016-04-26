using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class checkpointScript : MonoBehaviour {
	public int level;
	public int levelCount = 3;

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerPrefs.SetInt(level.ToString(), 1);
            if (level < levelCount) {
                SceneManager.LoadScene(level + 1);
            } else {
                SceneManager.LoadScene(0);
            }
        }
    }
}
