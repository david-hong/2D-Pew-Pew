using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public Transform bombPowerUp;
	private Transform bomb;
	private int prev = 0;
	private int nextBombIn = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreScript.Instance.getScore () % nextBombIn < prev % nextBombIn) {
			bomb = Instantiate(bombPowerUp) as Transform;
			nextBombIn += 10;
		}
		prev = ScoreScript.Instance.getScore ();
	}
}
