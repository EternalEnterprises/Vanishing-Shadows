using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public GameObject mainmenu;
	public GameObject credits;
	public GameObject levelselect;
	// returns to the main menu on click
	public void backOnClick(){

		//renables necessary canvases

		mainmenu.SetActive (true);
		credits.SetActive (false);
		levelselect.SetActive (false);

	}
}
