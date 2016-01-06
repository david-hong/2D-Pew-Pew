using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	private GUISkin skin;

	// Use this for initialization
	void Start () {
		skin = Resources.Load ("GUISkin") as GUISkin;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		const int buttonWidth = 84;
		const int buttonHeight = 60;

		GUI.skin = skin;


		Rect buttonRect = new Rect (Screen.width / 2 - buttonWidth / 2,
			                  2 * Screen.height / 3 - buttonHeight / 2,
			                  buttonWidth, buttonHeight);

		if (GUI.Button (buttonRect, "Start!")) {
			Application.LoadLevel ("stage1");
		}
	}
}
