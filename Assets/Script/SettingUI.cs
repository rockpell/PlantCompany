using UnityEngine;
using System.Collections;

public class SettingUI : MonoBehaviour
{
		//public GUISkin mySkin;
	
		int sw = Screen.width;
		int sh = Screen.height;
		bool SettingOn = false;

		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (SettingOn) 
						Time.timeScale = 0;
				else
						Time.timeScale = 1;
		}

		void OnMouseUp ()
		{
				if (SettingOn) {
						SettingOn = false;
				} else {
						SettingOn = true;
						GameObject.Find ("UI").transform.FindChild ("Menu").gameObject.SetActive (true);
				}
		}

		void OnGUI ()
		{
				if (SettingOn) {
						GUI.Box (new Rect (sw / 2 - sw / 8, sh / 2 - sh*3 / 12, sw / 4, sh*4 / 12),"");

						if (GUI.Button (new Rect (sw / 2 - sw / 12, sh *9 / 32, sw / 6, sh / 15), "게임으로 돌아가기")) {
								SettingOn = false;
								GameObject.Find ("UI").transform.FindChild ("Menu").gameObject.SetActive (false);
						}
						if (GUI.Button (new Rect(sw / 2 - sw / 12, sh * 12 / 32, sw / 6, sh / 15),"국경 ON/OFF")) {
								
						}
						if (GUI.Button (new Rect (sw / 2 - sw / 12, sh * 15 / 32, sw / 6, sh / 15), "게임종료"))
								Application.Quit ();
				}
		}
}
