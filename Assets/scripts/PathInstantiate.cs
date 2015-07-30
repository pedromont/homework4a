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
			float randomR = Random.Range (0f, 1f);
			if (randomR < 0.25f) {
				transform.Rotate (0f, 90f, 0f);
			} 
			else if (randomR < 0.5f ) {
				transform.Rotate (0f, -90f, 0f);
			} 


			float randomG = Random.Range (0f, 1f);
			if (randomG < 0.5f) {
				//Transform newClone = (Transform)Instantiate (floorPrefab, transform.position, transform.rotation); 
				Instantiate (floorPrefab, transform.position, transform.rotation); 
				//global space: orientation of the world, West will always be West
				// local space: specific to an object, Left will mean "your left"

			} 

			//Transform newClone = (Transform)Instantiate (floorPrefab, transform.position, transform.rotation); 
			transform.Translate (0f, 0f, 5f); // move 5 units in local space
		} else {
			Destroy (this.gameObject);
		}
	}
}
