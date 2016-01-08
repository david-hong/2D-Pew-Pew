using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
	public Transform shotPrefab;
	public Transform bomb;
	public float shootingRate = 0.01f;
	private float shootCooldown;

	void Start(){
		shootCooldown = 0f;
	}

	void Update(){
		if (shootCooldown > 0){
			shootCooldown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy){
		if (CanAttack){
			shootCooldown = shootingRate;

			// Create a new shot 
			var shotTransform = Instantiate(shotPrefab) as Transform;

			// Assign position
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			shotTransform.position = ray.origin;

			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null){
				shot.isEnemyShot = isEnemy;
			}

			/*
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript> ();

			// Make the weapon shot always towards it
			if (isEnemy = false) {
				if (move != null) {
					move.direction = this.transform.right; // towards in 2D space is the right of the sprite
				}
			}*/
		}
	}

	public void PowerUp(){
		var shotTransform = Instantiate(bomb) as Transform;
	}

	public bool CanAttack{
		get{
			return shootCooldown <= 0f;
		}
	}
}