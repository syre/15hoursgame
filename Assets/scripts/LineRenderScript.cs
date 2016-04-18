using UnityEngine;
using System.Collections;

public class LineRenderScript : MonoBehaviour {

	public LineRenderer line;
	public GameObject manpoint;
	public GameObject hook;
	// Use this for initialization
	void Start () {
		line.SetVertexCount (2);
	}
	
	// Update is called once per frame
	void Update () {
		line.SetPosition (0, manpoint.transform.position);
		line.SetPosition (1, hook.transform.position);
	}
}
