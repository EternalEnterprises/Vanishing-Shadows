using UnityEngine;
using System.Collections;

public class MenuSwap : MonoBehaviour {

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

	public void creditMenu(){
		credits.SetActive (true);
		mainmenu.SetActive (false);
	}

	public void levelMenu(){
		levelselect.SetActive (true);
		mainmenu.SetActive (false);
	}

}
