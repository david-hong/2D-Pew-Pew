using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour {

	public static SoundEffectsHelper Instance;
	public AudioClip explosionSound;
	public AudioClip playerShotSound;
	public AudioClip enemyShotSound;

	void Awake(){
		if (Instance != null) {
			Debug.LogError ("Multiple instances of SoundEH");
		}
		Instance = this;
	}

	public void MakeExplosionSound(){
		MakeSound (explosionSound);
	}

	public void MakePlayerShotSound(){
		MakeSound (playerShotSound);
	}

	public void MakeEnemyShotSound(){
		MakeSound (enemyShotSound);
	}

	private void MakeSound(AudioClip clip){
		AudioSource.PlayClipAtPoint (clip, transform.position);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
