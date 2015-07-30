using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	public Vector3 destination;
	public float speed = 100f;
	bool grounded = false;

	// Use this for initialization
	void Start () {
		//first wait 1 second then call this function every 4 seconds
		InvokeRepeating ("PickRandomDestination", 1f, 4f);
	}

	void PickRandomDestination(){
		destination = new Vector3 (Random.Range (-10f, 10f), 0f, Random.Range (-10f, 10f));
	}
	
	void Update(){
		//"Grounded" check let's raycast downwards to see if there is a floor collider beneath us
		Ray ray = new Ray (transform.position, new Vector3 (0, -1, 0));
		if (Physics.Raycast (ray, 1.1f)) {
			grounded = true;
		} else{
			grounded = false;
		}
		Debug.Log (grounded);
	
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (transform.position, destination);
		Gizmos.DrawWireSphere (destination, 0.5f);
	}

	// FixedUpdate is called once per physics frame
	void FixedUpdate () {
		//Go from point A (current) to point B (destination)
		Vector3 moveDirection = destination - transform.position;

		moveDirection = Vector3.Normalize (moveDirection); // standardize to length 1

		//Raycast downwards right in front of me
		Ray ray = new Ray ( transform.position + moveDirection, Vector3.down);
		bool GroundinFrontQ = Physics.Raycast (ray, 1.1f); 

		//stopping distance = if we are close to destination stop thrusting
		if (Vector3.Distance (transform.position, destination) > 3f && grounded) {
			GetComponent<Rigidbody> ().AddForce (moveDirection * speed);
		} //else { // reached destination
			//GetComponent<Rigidbody>().velocity=Vector3.zero; // or replace zero with gravity
			//destination = Vector3.zero; //clear destination
		//}
	}
}
