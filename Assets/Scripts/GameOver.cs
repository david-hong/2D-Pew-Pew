using UnityEngine;
using System.Collections;
using System.IO;

public class GameOver : MonoBehaviour {

	private string name;

	// Use this for initialization
	void Start () {
		name = "Name";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		const int buttonWidth = 120;
		const int buttonHeight = 60;

		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2,
			    Screen.height / 3 - buttonHeight / 2,
			    buttonWidth,
			    buttonHeight), "Retry!")) {
			Application.LoadLevel ("stage1");
		}

		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2,
			   Screen.height / 3 - buttonHeight / 2 + 70,
			   buttonWidth,
			   buttonHeight), "Back to menu")) {
			Application.LoadLevel ("menu");
		}

		name = GUI.TextField(new Rect (Screen.width / 2 - buttonWidth / 2,
		                 			Screen.height / 3 - buttonHeight / 2 + 140,
		                 			buttonWidth,
		                        	buttonHeight/2), name);

		string file = "";

		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2,
		                          Screen.height / 3 - buttonHeight / 2 + 170,
		                          buttonWidth,
		                          buttonHeight/2), "Submit")) {
			using (StreamReader reader = new StreamReader("Assets/Scripts/data/highScore")){
				string line = reader.ReadLine();
				bool written = false;
				while(line != null){
					string[] score = line.Split(null);
					if(!written && ScoreScript.Instance.getScore() > int.Parse(score[0])){
						file += ScoreScript.Instance.getScore () + " " + name + "\n";
						written = true;
					}
					file += line + "\n";
					line = reader.ReadLine();
				}
				if(!written){
					file += ScoreScript.Instance.getScore () + " " + name + "\n";
				}
			}
			
			
			using (StreamWriter writer = new StreamWriter ("Assets/Scripts/data/highScore")) {
				writer.Write (file);
			}
			
			Application.LoadLevel ("highScore");
		}

	}
}
