using UnityEngine;
using System.Collections;

public class SettingUI : MonoBehaviour {
	//public GUISkin mySkin;

	public Texture2D newCursor;
	int cWidth = 20;
	int cHeight = 20;

	int sw = Screen.width;
	int sh = Screen.height;

	bool SettingOn = false;

	void Start () {
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		SettingOn = true;
	}

	void OnGUI(){

		GUI.Label (new Rect(Input.mousePosition.x, Screen.height-Input.mousePosition.y, cWidth, cHeight),newCursor);

		if(SettingOn){
			GUI.Box (new Rect(sw/2-80 ,sh/2-100 ,sw/4 ,90), "Menu");
			if(GUI.Button(new Rect(sw/2-110+sw/4 ,sh/2-100,30,20),"X"))
				SettingOn=false;
			if(GUI.Button (new Rect(sw/2-60,sh/2-60,sw/4-50,30),"게임종료"))
				Application.Quit ();
		}
	}
}
