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

		if (GUI.Button (new Rect (sw / 2 - 30, sh/2 - 30, sw/12, sh/15), "Start")) {
						Application.LoadLevel ("1_Game");
				}
		if (GUI.Button(new Rect(sw/2 - 30 ,sh/2+30,sw/12,sh/15),"Quit")){
						Application.Quit();
		}
	}
}
