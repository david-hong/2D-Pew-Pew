using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 1;
	public int maxHp = 1;
	public bool isEnemy = true;

	public void Damage(int damageCount){
		hp -= damageCount;
		if (hp <= 0) {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound ();

			if (isEnemy) {
				EnemyScript enemy = gameObject.GetComponent<EnemyScript> ();
				if (enemy != null) {
					enemy.dead ();
					this.Destroy (gameObject);
				}
			}
			else{
				PlayerScript player = gameObject.GetComponent<PlayerScript>();
				player.dead();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider){
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		if (shot != null) {
			if (shot.isEnemyShot != isEnemy) {
				this.Damage (shot.damage);

				//destroy shot
				if (!shot.isBomb)
					this.Destroy (shot.gameObject);
			}
		} else if(otherCollider.gameObject.transform.name.Contains("Bomb PowerUp")){
			GetComponent<WeaponScript>().PowerUp();
			Destroy(otherCollider.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
