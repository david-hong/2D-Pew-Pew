using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 1;
	public int maxHp = 1;
	public bool isEnemy = true;
	private Vector3 pos;
	private GUIStyle style = null;

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
			WeaponScript weapon = GetComponent<WeaponScript>();
			if(weapon)
				weapon.PowerUp();
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

	void OnGUI(){
		initStyles ();
		pos = Camera.main.WorldToScreenPoint (this.transform.position);
		pos.y = Screen.height - pos.y;
		GUI.Box (new Rect(pos.x - 50, pos.y - 60,
		                  100 * ((float)GetComponent<HealthScript>().hp / (float)GetComponent<HealthScript>().maxHp), 18),
		         GetComponent<HealthScript>().hp.ToString(), style);
	}
	
	private void initStyles(){
		if( style == null ){
			style = new GUIStyle( GUI.skin.box );
			style.normal.background = MakeTex( 2, 2, new Color( 0.3f, 0.8f, 0.3f, 1 ) );
			style.normal.textColor = new Color (255,255,255,1);
			style.fontSize = 12;
			style.fontStyle = FontStyle.Bold;
			style.padding = new RectOffset(0,0,0,0);
			style.border = new RectOffset(0,0,0,0);
			style.alignment = TextAnchor.MiddleCenter;
		}
	}
	
	private Texture2D MakeTex( int width, int height, Color col ){
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i ){
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
}
