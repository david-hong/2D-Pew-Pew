using UnityEngine;

public class EnemyScript : MonoBehaviour{
	private bool hasSpawn;
	private MoveScript moveScript;
	private WeaponScript[] weapons;
	public int points;
	private Vector3 pos;
	private GUIStyle style = null;

	void Awake(){
		weapons = GetComponentsInChildren<WeaponScript>();
		moveScript = GetComponent<MoveScript>();
	}

	void Start(){
		hasSpawn = false;

		// Disable everything
		GetComponent<Collider2D>().enabled = false;
		if(moveScript)
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
		else if(this.transform.position.y < -20){
			Destroy(gameObject);
		}
		else{
			// Auto-fire
			/*foreach (WeaponScript weapon in weapons){
				if (weapon != null && weapon.enabled && weapon.CanAttack){
					weapon.Attack(true);
				}
			}*/
		}
	}

	private void Spawn(){
		hasSpawn = true;

		GetComponent<Collider2D>().enabled = true;
		if(moveScript != null)
			moveScript.enabled = true;
		foreach (WeaponScript weapon in weapons){
			weapon.enabled = true;
		}
	}

	public void dead(){
		ScoreScript.Instance.addScore (this.points);
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