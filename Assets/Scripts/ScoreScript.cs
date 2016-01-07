using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	private GUISkin skin;

	public static ScoreScript Instance;
	private int score;
	private bool addable;

	public int getScore(){
		return score;
	}

	public void addScore(int n){
		if (addable) {
			score += n;
		}
	}

	public void playerDead(){
		addable = false;
	}

	// Use this for initialization
	void Start () {
		
		skin = Resources.Load ("GameSkin") as GUISkin;

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

	void OnGUI(){
		GUI.skin = skin;
		GUI.Label(new Rect(10,10, 200, 30), "SCORE "+score);
	}
}
