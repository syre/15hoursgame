using UnityEngine;
using System.Collections;

public class RopeOnClick : MonoBehaviour {
	
	public FixedJoint2D jointTarget;
	public float ropeDistance = 10f;
	public GameObject castpoint;
	//public GameObject part5;
	//public GameObject part6;
	//public GameObject part7;
	//public GameObject part8;
	public LineRenderer line;
	public GameObject connectPoint;
	public GameObject hook;
	private bool isFat = false;
	public Sprite thinGuy;
	public Sprite fatGuy;
	public DistanceJoint2D joint;

	// Use this for initialization
	void Start () {
		detachRope ();
		line.SetVertexCount (2);
		//part6.SetActive (false);
		//part7.SetActive (false);
		//part8.SetActive (false);
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
				line.enabled = true;
				jointTarget.gameObject.SetActive (true);
				this.transform.GetComponent<HingeJoint2D> ().enabled = true;
				jointTarget.connectedAnchor = castResult.point;
			}
		}


	}
	void Update()
	{
		line.SetPosition (0, connectPoint.transform.position);
		line.SetPosition (1, castpoint.transform.position);
		if (Input.GetMouseButtonDown (0))
			attachRope();
		else if (Input.GetMouseButtonUp(2))
			detachRope();
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isFat) {
				isFat = false;
				joint.distance = 3;
				this.transform.GetComponent<SpriteRenderer> ().sprite = thinGuy;
			} else {
				isFat = true;
				joint.distance = 6;
				this.transform.GetComponent<SpriteRenderer> ().sprite = fatGuy;
			}
		}
	}
	
	void detachRope()
	{
		line.enabled = false;
		jointTarget.enabled = false;
		this.transform.GetComponent<HingeJoint2D> ().enabled = false;
		jointTarget.gameObject.SetActive (false);
	}
}
