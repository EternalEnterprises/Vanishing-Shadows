using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartOnClick : MonoBehaviour {

	public void restart(){
		PlayerPrefs.SetInt ("checkpoint", 0);
		PlayerPrefs.SetInt ("loot", 0);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
