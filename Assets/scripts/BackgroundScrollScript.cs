using UnityEngine;
using System.Collections;

public class BackgroundScrollScript : MonoBehaviour {
	public float x;

	// Use this for initialization
	void Start () {
		x = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", new Vector2 (gameObject.GetComponentInParent<CameraScript>().obj.transform.position.x*0.01f, 0));

	}
}
