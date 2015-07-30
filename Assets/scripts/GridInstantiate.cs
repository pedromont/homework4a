using UnityEngine;
using System.Collections;


public class GridInstantiate : MonoBehaviour {
	
	public Transform floorPrefab2;
	public Transform wallPrefab2;
	private float randomP;

	// Use this for initialization
	void Start () {

		for (int x = 0; x<5; x++) {
			for (int z = 0; z<5 ; z++){

				float randomP = Random.Range(0f, 1f); // or you can use Random.value
				Vector3 poss = new Vector3 (x * 5f, 0f ,z * 5f) + transform.position;

				if(randomP>0.30f){
					//Transform newClone = (Transform)Instantiate (floorPrefab2, poss, transform.rotation);
					Instantiate (floorPrefab2, poss, Quaternion.identity);
				}
				else if(randomP>0.05f && randomP<0.3f){
					//Transform newClone = (Transform)Instantiate (wallPrefab2, poss, transform.rotation);
					Instantiate (wallPrefab2, poss, Quaternion.identity);
				}

			} 
		}

		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		//regenerate gridinstantiate
		if ( Input.GetKeyDown (KeyCode.R) ) {
			Application.LoadLevel ( Application.loadedLevel );
		}
	}
}
