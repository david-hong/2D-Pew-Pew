using UnityEngine;

public class EnemyScript : MonoBehaviour{
	private bool hasSpawn;
	private MoveScript moveScript;
	private WeaponScript[] weapons;
	public int points;

	void Awake(){
		weapons = GetComponentsInChildren<WeaponScript>();
		moveScript = GetComponent<MoveScript>();
	}

	void Start(){
		hasSpawn = false;

		// Disable everything
		GetComponent<Collider2D>().enabled = false;
		moveScript.enabled = false;
		foreach (WeaponScript weapon in weapons){
			weapon.enabled = false;
		}
	}

	void Update(){
		if (hasSpawn == false){
			if (GetComponent<Renderer>().IsVisibleFrom(Camera.main)){
				this.Spawn();
			}
		}
		else{
			// Auto-fire
			foreach (WeaponScript weapon in weapons){
				if (weapon != null && weapon.enabled && weapon.CanAttack){
					weapon.Attack(true);
				}
			}

			// Out of camera?
			if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false){
				this.Destroy(gameObject);
			}
		}
	}

	private void Spawn(){
		hasSpawn = true;

		GetComponent<Collider2D>().enabled = true;
		moveScript.enabled = true;
		foreach (WeaponScript weapon in weapons){
			weapon.enabled = true;
		}
	}

	public void dead(){
		ScoreScript.Instance.addScore (this.points);
	}
}