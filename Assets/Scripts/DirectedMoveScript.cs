using UnityEngine;
using System.Collections;

public class DirectedMoveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 playerPos = GameObject.Find("Player").transform.position;
		GetComponent<Rigidbody2D>().AddForce((playerPos - transform.position) * 0.5f);
	}
}
