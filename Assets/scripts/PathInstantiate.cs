using UnityEngine;
using System.Collections;

public class PathInstantiate : MonoBehaviour {

	private int counter;
	public Transform floorPrefab;

	// Use this for initialization
	void Start () {
		counter = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (counter < 50) {
			counter++;
			float randomr = Random.Range (0f, 1f);
			if (randomr < 0.25f) {
				transform.Rotate (0, 90f, 0);
			} 
			if (randomr < 0.5f && randomr >=0.25f) {
				transform.Rotate (0, -90f, 0);
			} 
			Transform newClone = (Transform)Instantiate (floorPrefab, transform.position, transform.rotation); 
			transform.Translate (5f, 0f, 0f);
			counter++;
		} else {
			Destroy (this.gameObject);
		}
	}
}
