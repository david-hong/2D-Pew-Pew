using UnityEngine;
using System.Collections;

public class SpecialEffectsHelper : MonoBehaviour {

	public static SpecialEffectsHelper Instance;
	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;

	// Use this for initialization
	void Start () {
	
	}

	void Awake() {
		if (Instance != null) {
			Debug.LogError ("Multiple instances of SpecialEH");
		}

		Instance = this;
	}

	public void Explosion(Vector3 position){
		startEffect (smokeEffect, position);

		startEffect (fireEffect, position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private ParticleSystem startEffect(ParticleSystem prefab, Vector3 position){
		ParticleSystem newParticleSystem = Instantiate (prefab, position, Quaternion.identity) as ParticleSystem;

		Destroy (newParticleSystem.gameObject, newParticleSystem.startLifetime);

		return newParticleSystem;
	}
}
