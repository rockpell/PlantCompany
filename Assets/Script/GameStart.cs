using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	int sw = Screen.width;
	int sh = Screen.height;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button (new Rect (sw / 2 - 30, sh / 2 - 15, 60, 30), "Start")) {
						Application.LoadLevel ("1_Game");
				}
		if (GUI.Button(new Rect(sw/2+60,sh/2-15,60,30),"Quit")){
						Application.Quit();
		}
	}
}
