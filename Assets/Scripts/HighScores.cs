using UnityEngine;
using System.Collections;
using System.IO;

public class HighScores : MonoBehaviour {

	private GUISkin skin;

	// Use this for initialization
	void Start () {
		skin = Resources.Load ("GUISkin") as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		const int buttonWidth = 120;
		const int buttonHeight = 60;

		GUI.skin = skin;

		if (GUI.Button (new Rect (20,
		                          20,
		                          buttonWidth,
		                          buttonHeight), "Back to menu")) {
			Application.LoadLevel ("menu");
		}

		//print scores
		string[] scores = this.getScores ();
		for (int i=0; i<scores.Length; i++) {
			GUI.Label(new Rect(40, 100 + 60 * i, 300, 50), scores[i]);
		}
	}

	private string[] getScores(){
		string[] file = new string[9];
		int i = 0;

		StreamReader reader = new StreamReader ("Assets/Scripts/data/highScore");
		string line = reader.ReadLine();
		while(line != null && i < 9){
			file[i] += line;
			line = reader.ReadLine();
			i++;
		}

		return file;
	}
}
