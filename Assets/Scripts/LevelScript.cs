using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform ghostPrefab;
	public Transform tankPrefab;

	public float amount = 1;
	public float spawnrate = 5;
	private float cooldown = 4;
	public float exponential = 1.5f;
	public float maxIncrease = 1;
	private bool spawnable;

	public static LevelScript Instance;


	// Use this for initialization
	void Start () {
		spawnable = true;
		if (Instance != null) {
			Debug.Log("Multiple instances of levelscript");
		}
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		} else {
			this.spawn();
			cooldown = spawnrate;
		}
	}

	public void dead(){
		spawnable = false;
	}

	private void spawn(){
		if (!spawnable)
			return;

		maxIncrease *= exponential;
		int rng = Random.Range (1, (int)Mathf.Round(maxIncrease));
		amount = amount + 2;

		for(int i = 0; i < Mathf.Round(amount); i++){
			int enemyRNG = Random.Range(1,11);
			int positionRNG = Random.Range (1, 11);
			
			// Assign position based on posRNG
			float posX;
			float posY;
			if(positionRNG <= 4){
				posX = -7.7f + (float)(0.1f * i);
				posY = -8.0f;
			}
			else if(positionRNG <= 8){
				posX = 27 - (float)(0.1f * i);
				posY = -8.0f;
			}
			else if(positionRNG == 9){
				posX = 15.9f - (float)(0.1f * i);
				posY = 2.7f;
			}
			else{
				posX = 5.2f - (float)(0.1f * i);
				posY = -1.4f;
			}

			if(enemyRNG <= 7){
				var enemy = Instantiate(enemyPrefab) as Transform;
				enemy.position = new Vector3(posX,posY,0f);
				enemy.GetComponent<MoveScript>().direction = new Vector2(1,0);
			}
			else if(enemyRNG <= 8){
				var enemy = Instantiate(tankPrefab) as Transform;
			}
			else{
				var enemy = Instantiate(ghostPrefab) as Transform;
			}
		}
	}
}
