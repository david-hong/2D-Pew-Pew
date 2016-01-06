using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public int damage = 1;
	public bool isEnemyShot = false;

	void Start () {
		this.Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Renderer> ().IsVisibleFrom (Camera.main) == false) {
			//this.Destroy (gameObject);
		}
	}
}
