using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public int levelCount; // need to make this global

	// Use this for initialization
	void Start () {
		// checks to see if values have been set for levels
		if (PlayerPrefs.GetString ("load") != null) {
			// initializes array for checking levels as this is first time loading.
			PlayerPrefs.SetString ("load", "foobar");
			for (int i = 0; i < levelCount; i++) {
				string level = i.ToString();
				PlayerPrefs.SetInt (level, 0);
			}
		}
		// checks to see if first level has been completed
		if (PlayerPrefs.GetInt ("1") != 0) {
			//loads the continue prefab
			//GameObject instance = Instantiate(continue);
			//script in the continue button will have code to check for last level completed
		} else {
			// instanciate Start button.
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
