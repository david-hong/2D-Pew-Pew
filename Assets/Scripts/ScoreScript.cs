using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public static ScoreScript Instance;
	private int score;
	private bool addable;

	public void addScore(int n){
		if (addable) {
			score += n;
			Debug.Log (score);
		}
	}

	public void playerDead(){
		addable = false;
	}

	// Use this for initialization
	void Start () {
		score = 0;
		if (Instance != null) {
			Debug.LogError ("Mulltiple instances of score script");
		}
		Instance = this;
		addable = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
