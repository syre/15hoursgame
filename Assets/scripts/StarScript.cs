using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarScript : MonoBehaviour {

	public static bool canstillWin;
	public Text textToShow;
	public Button buttonToShow;

	// Use this for initialization
	void Start () {
		textToShow.enabled = false;
		buttonToShow.gameObject.SetActive (false);
		canstillWin = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (canstillWin) {
			if (other.tag == "player") {
				textToShow.enabled = true;
				buttonToShow.gameObject.SetActive (true);
			}
		}
	}

	public void toLevelTwo(){
		SceneManager.LoadScene ("Level02");
	}

	public void toMainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
}
