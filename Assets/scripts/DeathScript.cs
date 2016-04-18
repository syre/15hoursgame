using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour {

	public Text diedText;
	public Button tryAgainButton;

	// Use this for initialization
	void Start () {
		diedText.enabled = false;
		tryAgainButton.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnDeath(){
		diedText.enabled = true;
		tryAgainButton.gameObject.SetActive (true);
	}

	public void PlayAgain(){
		Debug.Log(SceneManager.GetActiveScene ().name);
		SceneManager.LoadScene(SceneManager.GetActiveScene ().name);
	}




}
