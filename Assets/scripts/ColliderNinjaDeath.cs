using UnityEngine;
using System.Collections;

public class ColliderNinjaDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "player") {
			Destroy (coll.gameObject);
			GameObject.FindGameObjectWithTag ("deathhandler").GetComponent<DeathScript>().OnDeath();
		}
	}
}
