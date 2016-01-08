using UnityEngine;

public class EnemyScript : MonoBehaviour{
	private MoveScript moveScript;
	private WeaponScript[] weapons;
	public int points;

	void Awake(){
		weapons = GetComponentsInChildren<WeaponScript>();
		moveScript = GetComponent<MoveScript>();
	}

	void Start(){
	}

	void Update(){
			// Auto-fire
			/*foreach (WeaponScript weapon in weapons){
				if (weapon != null && weapon.enabled && weapon.CanAttack){
					weapon.Attack(true);
				}
			}*/
	}

	public void dead(){
		ScoreScript.Instance.addScore (this.points);
	}
}