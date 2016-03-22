using UnityEngine;
using System.Collections;

public class LoadContinue : MonoBehaviour {
	public int levelCount;
	// loads the last level to be not completed
	public void Continue(){
		int level = 1;
		// loops through level list
		for (int i = 1; i < levelCount; i++) {
			// checks for the first insance a level has not been completed.
			if(PlayerPrefs.GetInt(i.ToString()) == 0){
				level = i;
				break;
			}
		}
		// loads the apropriate scene
		Application.LoadLevel(level);
	}
}
