using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2 (10, 10);
	public Vector2 direction = new Vector2 (-1, 0);
	private Vector2 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < - 40) {
			this.Destroy(gameObject);
		}
		Vector3 playerPos = GameObject.Find("Player").transform.position;
		if (playerPos.x < transform.position.x) {
			direction.x = -1;
		} else {
			direction.x = 1;
		}
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}

	void FixedUpdate(){
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
