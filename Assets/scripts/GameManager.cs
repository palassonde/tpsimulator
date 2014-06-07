using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float timeleft;

	// Use this for initialization
	void Start () {

		timeleft = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (timeleft < 1) {
			GameOver ();
		}

		timeleft -= Time.deltaTime;
	
	}

	void GameOver(){

	}
}
