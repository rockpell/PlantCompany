using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	int sw = Screen.width;
	int sh = Screen.height;

	public GUISkin StartFont;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.skin = StartFont;

		if (GUI.Button (new Rect (sw / 2 - sw/8, sh/2, sw/4, sh/8), "Start")) {
						Application.LoadLevel ("1_Game");
				}
		if (GUI.Button(new Rect(sw/2 - sw/8 ,sh/2 + sh*3/15,sw/4,sh/8),"Quit")){
						Application.Quit();
		}
	}
}
