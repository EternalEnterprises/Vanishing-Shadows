using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public int levelCount; // need to make this global

	// Use this for initialization
	void Start () {
		
		// clears level data
		PlayerPrefs.SetInt("death", 0);
		PlayerPrefs.SetInt("checkpoint", 0);
		PlayerPrefs.SetInt("loot", 0);


		// checks to see if values have been set for levels
		if (PlayerPrefs.GetInt ("load") != levelCount) {
			// initializes array for checking levels as this is first time loading.
			PlayerPrefs.SetInt ("load", levelCount);
			for (int i = 0; i < levelCount; i++) {
				string level = i.ToString();
				PlayerPrefs.SetInt (level, 0);
			}
		}
	}
}
