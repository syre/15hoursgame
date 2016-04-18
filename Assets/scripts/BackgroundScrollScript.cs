using UnityEngine;
using System.Collections;

public class BackgroundScrollScript : MonoBehaviour {
	public float x;
	public GameObject obj;
	// Use this for initialization
	void Start () {
		x = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (obj.transform.position.x,this.transform.position.y, 1f);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", new Vector2 (obj.transform.position.x*0.01f, 0));

	}
}
