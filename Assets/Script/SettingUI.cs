using UnityEngine;
using System.Collections;

public class SettingUI : MonoBehaviour {
	//public GUISkin mySkin;

	bool SettingOn = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		SettingOn = true;
	}

	void OnGUI(){
		if(SettingOn){
		GUI.Box (new Rect(Screen.width/2-80 ,Screen.height/2-100 ,230 ,90), "Menu");
			if(GUI.Button(new Rect(Screen.width/2+120 ,Screen.height/2-100,30,20),"X"))
				SettingOn=false;
			if(GUI.Button (new Rect(Screen.width/2-60,Screen.height/2-60,200,30),"게임종료"))
				Application.Quit ();
		}
	}
}
