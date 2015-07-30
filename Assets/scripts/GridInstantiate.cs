using UnityEngine;
using System.Collections;


public class GridInstantiate : MonoBehaviour {
	
	public Transform floorPrefab2;
	public Transform wallPrefab2;
	private float randomp;

	// Use this for initialization
	void Start () {

		for (int x = 0; x<5; x++) {
			for (int z = 0; z<5 ; z++){

				randomp = Random.Range(0f, 1f);
				Vector3 poss = new Vector3 (x * 5f, 0f ,z * 5f);


				if(randomp>0.30f){
					Transform newClone = (Transform)Instantiate (floorPrefab2, poss, transform.rotation);
				}
				if(randomp>0.05f && randomp<0.3f){
					Transform newClone = (Transform)Instantiate (wallPrefab2, poss, transform.rotation);
				}

			} 
		}


		//Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		//regenerate gridinstantiate
		if ( Input.GetKeyDown (KeyCode.R) ) {
			Application.LoadLevel ( Application.loadedLevel );
		}
	}
}
