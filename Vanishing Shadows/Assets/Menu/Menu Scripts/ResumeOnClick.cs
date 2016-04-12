using UnityEngine;
using System.Collections;

public class ResumeOnClick : MonoBehaviour {
	public GameObject pauseMenu;
	// Use this for initialization
	public void resume(){
		Time.timeScale = 1;
		pauseMenu.SetActive (false);
	}
}
