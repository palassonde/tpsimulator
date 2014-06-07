using UnityEngine;
using System.Collections;

public class DensityFault : MonoBehaviour {

	private float dist;
	private int nbrTreesAround;

	void countCloseSaplings(string thing){

		GameObject[] cs;

		cs = GameObject.FindGameObjectsWithTag (thing);

		nbrTreesAround = 0;

		foreach (GameObject s in cs) {

			dist = Vector3.Distance(transform.position,s.transform.position);

			if (dist < 3){

				nbrTreesAround++;
			}
		}
	}
	
	void Start () {

		countCloseSaplings ("Saplings");

		if (nbrTreesAround > 1){
		
			PlayerController.fault++;

			if (nbrTreesAround > 2)
				PlayerController.fault++;
		}
	}

	void Update () {

	}
}
