using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void levelOne(){
		SceneManager.LoadScene ("Level01");
	}
}
