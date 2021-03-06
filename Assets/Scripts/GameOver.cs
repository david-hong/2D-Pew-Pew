﻿using UnityEngine;
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

		if (GUI.Button (new Rect (Screen.width / 2 - buttonWidth / 2,
		                          Screen.height / 3 - buttonHeight / 2 + 170,
		                          buttonWidth,
		                          buttonHeight/2), "Submit")) {
			saveScore();
			
			Application.LoadLevel ("highScore");
		}

	}

	private void saveScore(){
		string file = "";

		using (StreamReader reader = new StreamReader("Assets/Scripts/data/highScore")){
			string line = reader.ReadLine();
			bool written = false;
			int currScore = ScoreScript.Instance.Score;

			while(line != null){
				string[] score = line.Split(null);

				if(!written && currScore > int.Parse(score[0])){
					file += currScore + " " + name + "\n";
					written = true;
				}
				file += line + "\n";
				line = reader.ReadLine();
			}
			if(!written){
				file += currScore + " " + name + "\n";
			}
		}
		
		
		using (StreamWriter writer = new StreamWriter ("Assets/Scripts/data/highScore")) {
			writer.Write (file);
		}
	}
}
