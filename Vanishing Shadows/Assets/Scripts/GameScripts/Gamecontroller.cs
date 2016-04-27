using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Gamecontroller : MonoBehaviour {
	public GameObject pauseMenu;
	public GameObject deathMenu;
	// Use this for initialization


	void Start () {
		Time.timeScale = 1;
	}

	void Update () {

		//checks if player opens pause menu.
		if(Input.GetKeyDown("escape")){
			// determines if pause menu is currently open.
			if(Time.timeScale == 1){
				// opens pause menu
				pauseMenu.SetActive(true);
				Time.timeScale = 0;
			}else{
				// closes pause menu
				if (!deathMenu.activeSelf) {
					pauseMenu.SetActive (false);
					Time.timeScale = 1;
				}
			}
		}


		//checks for player death
		if (PlayerPrefs.GetInt ("death") == 1) {
			PlayerPrefs.SetInt ("death", 0);
			Time.timeScale = 0;
			deathMenu.SetActive (true);
		}


	}


}
