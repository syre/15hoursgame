using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (obj.transform.position.x, obj.transform.position.y, -10);

	}
}
