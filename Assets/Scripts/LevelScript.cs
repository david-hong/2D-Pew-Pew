using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

	public Transform enemyPrefab;
	public int amount;

	// Use this for initialization
	void Start () {
		// Create a new shot 
		var enemy = Instantiate(enemyPrefab) as Transform;

		// Assign position
		enemy.position = new Vector3(8,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
