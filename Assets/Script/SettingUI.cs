using UnityEngine;
using System.Collections;

public class SettingUI : MonoBehaviour {
	//public GUISkin mySkin;



	int sw = Screen.width;
	int sh = Screen.height;

	bool SettingOn = false;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		if (SettingOn)SettingOn = false;
		else SettingOn = true;
	}

	void OnGUI(){

		if(SettingOn){
			GUI.Box (new Rect(sw*3/8 ,sh/2-100 ,sw/4 ,90), "Menu");
			if(GUI.Button(new Rect(sw*5/8 -30 ,sh/2-100,30,20),"X"))
				SettingOn=false;
			if(GUI.Button (new Rect(sw/2-sw*3/32,sh/2-60,sw*3/16,30),"게임종료"))
				Application.Quit ();
		}
	}
}
