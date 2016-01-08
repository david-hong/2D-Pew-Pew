using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2(25,25);
	private Vector2 movement;
	private Rigidbody2D rigidBodyComponent;
	private bool jumping;
	public Vector2 jumpForce = new Vector2(120f, 330f);
	private bool alive;

	// Use this for initialization
	void Start () {
		jumping = false;
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!alive)
			return;

		this.move ();
		this.attack ();

		if (jumping && this.onGround()) {
			jumping = false;
		}
	}

	private void move(){
		float inputX = Input.GetAxis ("Horizontal");
		movement = new Vector2 (speed.x * inputX, 0);
	}

	private void attack(){
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		
		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript> ();
			if (weapon != null) {
				weapon.Attack (false);
				SoundEffectsHelper.Instance.MakePlayerShotSound ();
			}
		}
	}

	private bool onGround(){
		return (transform.position.y + 8.9050 < 0.01f || transform.position.y + 5.655 < 0.01f || transform.position.y + 3.345 < 0.01f);
	}

	private void jump(){
		jumping = true;
		rigidBodyComponent.AddForce(new Vector2(0 , 10000f), ForceMode2D.Force);
	}

	void FixedUpdate(){
		if (!alive)
			return;

		// 4 - Move the game object
		if (rigidBodyComponent == null)rigidBodyComponent = GetComponent<Rigidbody2D>();
			rigidBodyComponent.velocity = movement;

		
		if (Input.GetKeyDown ("space") && jumping == false) {
			this.jump ();
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (!alive)
			return;

		bool damagePlayer = false;

		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript> ();
		if (enemy != null) {
			damagePlayer = true;
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
		}

		if (damagePlayer) {
			HealthScript playerHealth = this.GetComponent<HealthScript> ();
			if (playerHealth != null)
				playerHealth.Damage (1);
		}
	}

	public void dead(){
		alive = false;
		GetComponent<Renderer> ().enabled = false;
		GetComponent<Rigidbody2D> ().isKinematic = true;
		GetComponent<BoxCollider2D> ().enabled = false;
		transform.parent.gameObject.AddComponent<GameOver> ();
		LevelScript.Instance.dead ();
	}
}
