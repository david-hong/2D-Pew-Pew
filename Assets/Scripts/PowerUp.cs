using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public Transform bombPowerUp;
	private Transform bomb;
	private int prev = 0;
	private int nextBombIn = 20;
	private const int powerupIncrementer = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreScript.Instance.Score > nextBombIn) {
			bomb = Instantiate(bombPowerUp) as Transform;
			nextBombIn += nextBombIn + powerupIncrementer;
		}
	}
}
