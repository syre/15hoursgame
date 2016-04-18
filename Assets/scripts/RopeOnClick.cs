using UnityEngine;
using System.Collections;

public class RopeOnClick : MonoBehaviour {
	public HingeJoint2D joint;
	public float ropeDistance = 10f;

	// Use this for initialization
	void Start () {
		joint = gameObject.AddComponent<HingeJoint2D> ();
		joint.enabled = false;
	}
	void OnMouseDown()
	{
		Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		joint.enabled = true;
		var ninjaPos = gameObject.GetComponent<Rigidbody2D> ();
		var castResult = Physics2D.Raycast(ninjaPos.position, mouseWorldPosition, ropeDistance);
		if (castResult.collider.tag == "ropeable")
		{
			joint.connectedAnchor = castResult.collider.attachedRigidbody.position;
			joint.connectedBody = ninjaPos;
		}
	}
	void OnMouseUp()
	{
		joint.enabled = false;
	}
}
