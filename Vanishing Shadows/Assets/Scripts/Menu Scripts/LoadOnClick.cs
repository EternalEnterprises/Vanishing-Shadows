using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {
	
	public void loadScene(int level){
		SceneManager.LoadScene (level);
	}
}
