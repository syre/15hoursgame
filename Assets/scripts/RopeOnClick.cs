using UnityEngine;
using System.Collections;

public class RopeOnClick : MonoBehaviour {
	
	public FixedJoint2D jointTarget;
	public float ropeDistance = 10f;
	public GameObject castpoint;

	// Use this for initialization
	void Start () {
		detachRope ();
	}
	void attachRope()
	{
		Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		jointTarget.enabled = true;
		var ninjaPos = gameObject.GetComponent<Rigidbody2D> ();
		var castResult = Physics2D.Raycast(castpoint.transform.position, mouseWorldPosition-ninjaPos.position, ropeDistance);
		if (castResult.collider != null && castResult.collider.gameObject != null) {
			if (castResult.collider.gameObject.tag == "ropeable")
			{
				Vector2 oldpos = jointTarget.connectedAnchor;
				jointTarget.gameObject.SetActive (true);
				this.transform.GetComponent<HingeJoint2D> ().enabled = true;
				jointTarget.connectedAnchor = castResult.point;
			}
		}

	}
	void Update()
	{
		if (Input.GetMouseButtonDown (0))
			attachRope();
		else if (Input.GetMouseButtonUp(2))
			detachRope();
	}
	
	void detachRope()
	{
		jointTarget.enabled = false;
		this.transform.GetComponent<HingeJoint2D> ().enabled = false;
		jointTarget.gameObject.SetActive (false);
	}
}
