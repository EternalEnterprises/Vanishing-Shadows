using UnityEngine;
using System.Collections;

public class ContinueCheckLoad : MonoBehaviour {
	public int levelProgress;
	// Use this for initialization
	void Start () {
		// checks to see if the first level has been completed and disables itself based on that.
		if (PlayerPrefs.GetInt("1") != levelProgress) {
			gameObject.SetActive(false);
		}

	}

}
