using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public int damage = 1;
	public bool isEnemyShot = false;
	public bool isBomb = false;

	void Start () {
		this.Destroy(gameObject, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
