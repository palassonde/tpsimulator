using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	Transform target;
	public int z;
	
	void Start () {

		target = GameObject.Find ("Player").transform;
	
	}

	void Update () {

		transform.position = target.position + new Vector3 (0, 0, z);
	}
}
