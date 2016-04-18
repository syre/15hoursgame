using UnityEngine;
using System.Collections;

public class SharkAI : MonoBehaviour {

	private float reset_time = 5f;
	private float going_time = 0f;
	private int direction = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		going_time += Time.deltaTime;
		if (going_time > reset_time) {
			going_time = 0f;
			direction = -direction;
		}
		gameObject.transform.position = new Vector2(transform.position.x + Time.deltaTime * direction, transform.position.y);
		
	}
}
