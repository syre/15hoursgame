using UnityEngine;
using System.Collections;

public class AndersArmAI : MonoBehaviour {
	public float minSpeed = 1f;
	public float maxSpeed = 10f;
	public float mindegrees = 10f;
	public float maxdegrees = 90f;
	public float minTimeBetweenSwing = 0f;
	public float maxTimeBetweenSwing = 1f;
	private float speed = 0f;
	private bool dir = false; // false is right;
	private float degrees = 0f;
	private bool isGoing = false;
	private float timeBetweenSwing;
	private float timeTillNextSwing = 0;
	private bool isGoingBack = false;

	// Use this for initialization
	void Start () {
		timeTillNextSwing = Random.Range (minTimeBetweenSwing, maxTimeBetweenSwing);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGoing && timeTillNextSwing <= 0) {
			speed = Random.Range (minSpeed, maxSpeed);
			int tempdir = Random.Range (0, 2);
			if (tempdir == 0) {
				dir = false;
			} else {
				dir = true;
			}
			degrees = Random.Range (mindegrees, maxdegrees);
			isGoing = true;
		} else if (isGoing) {
			if (!isGoingBack) {
				if (dir) {
					this.gameObject.transform.Rotate (Vector3.forward * speed * Time.deltaTime);
					if (this.gameObject.transform.eulerAngles.z > degrees) {
						isGoingBack = true;
						Debug.Log ("is going back = true");
					}
				} else {
					this.gameObject.transform.Rotate (Vector3.forward * -speed * Time.deltaTime);
					if ((this.gameObject.transform.eulerAngles.z < (360f - degrees)) && this.gameObject.transform.eulerAngles.z > 10f) {
						isGoingBack = true;
						Debug.Log ("is going back = true");
					}
				}
			} else if (isGoingBack) {
				if (dir) {
					this.gameObject.transform.Rotate (Vector3.back * speed * Time.deltaTime);
					if (this.gameObject.transform.eulerAngles.z > 300) {
						isGoingBack = false;
						isGoing = false;
						timeTillNextSwing = Random.Range (minTimeBetweenSwing, maxTimeBetweenSwing);
						this.gameObject.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
					}
				} else {
					this.gameObject.transform.Rotate (Vector3.back * -speed * Time.deltaTime);
					if (this.gameObject.transform.eulerAngles.z < 100) {
						isGoingBack = false;
						isGoing = false;
						timeTillNextSwing = Random.Range (minTimeBetweenSwing, maxTimeBetweenSwing);
						this.gameObject.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
					}
				}
			}
		} else {
			timeTillNextSwing -= Time.deltaTime;
		}
	}
}
