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
		if (SettingOn) 
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}

	void OnMouseUp(){
		if (SettingOn)SettingOn = false;
		else SettingOn = true;
	}

	void OnGUI(){

		if(SettingOn){
			GUI.Box (new Rect(sw/2 - sw/8 ,sh/2-sh/6 ,sw/4 ,sh/6), "게임 일시정지");
			if(GUI.Button(new Rect(sw/2-sw/12 ,sh*6/16,sw/6,sh/20),"게임으로 돌아가기"))
				SettingOn=false;
			if(GUI.Button (new Rect(sw/2-sw/12,sh*7/16,sw/6,sh/20),"게임종료"))
				Application.Quit ();
		}
	}
}
