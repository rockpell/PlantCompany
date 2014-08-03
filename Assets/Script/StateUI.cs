using UnityEngine;
using System.Collections;

public class StateUI : MonoBehaviour {

	GUIText State;

	int sw = Screen.width;
	int sh = Screen.height;

	bool sample1ch = false;

	public static int Money = 0;

	// Use this for initialization
	void Start () {
		State = gameObject.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		State.text = "현재 자금 보유량 : " + string.Format("{0}",Money);
		Money += 1;
	}

	void OnGUI(){
		if (GUI.Button (new Rect (0, sh / 3, sw / 15, sh / 16), "Sample1"))
						sample1ch = true;
		GUI.Button (new Rect(0,sh/3+sh/16,sw/15,sh/16),"Sample2");
		GUI.Button (new Rect(0,sh/3+sh/8,sw/15,sh/16),"Sample3");

		if (sample1ch) {
				GUI.Box (new Rect (sw*3/8, sh/2-sh/4, sw / 4, sh/4), "???");
			if(GUI.Button(new Rect(sw*5/8 - 30 ,sh/2-sh/4,30,20),"X"))
				sample1ch = false;
		}
	}
}
