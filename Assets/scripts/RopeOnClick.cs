using UnityEngine;
using System.Collections;

public class RopeOnClick : MonoBehaviour {
	private DistanceJoint2D joint;
	public float ropeDistance = 10f;

	// Use this for initialization
	void Start () {
		joint = gameObject.GetComponent<DistanceJoint2D> ();
		joint.enabled = false;
	}
	void attachRope()
	{
		Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		joint.enabled = true;
		var ninjaPos = gameObject.GetComponent<Rigidbody2D> ();
		var castResult = Physics2D.Raycast(ninjaPos.position, mouseWorldPosition, ropeDistance);
		if (castResult.collider.tag == "ropeable")
		{
			Debug.DrawRay (ninjaPos.position, Vector3.zero);
			joint.connectedAnchor = castResult.collider.attachedRigidbody.position;
			joint.connectedBody = ninjaPos;
		}
	}
	void Update()
	{
		if (Input.GetMouseButtonDown (0))
			attachRope();
		else if (Input.GetMouseButtonUp(0))
			detachRope();
	}
	
	void detachRope()
	{
		joint.enabled = false;
	}
}
