using UnityEngine;
using System.Collections;

public class StateUI : MonoBehaviour {

	GUIText State;

	int sw = Screen.width;
	int sh = Screen.height;

	bool sample1ch = false;
	
	void Start () {
		State = gameObject.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		State.text = "현재 자금 보유량 : " + string.Format("{0}",PlayerState.Money);
	}

	void OnGUI(){
		if (GUI.Button (new Rect (0, sh / 3, sw / 15, sh / 16), "Sample1"))
						sample1ch = true;
		GUI.Button (new Rect(0,sh/3+sh/16,sw/15,sh/16),"Sample2");
		GUI.Button (new Rect(0,sh/3+sh/8,sw/15,sh/16),"Sample3");

		if (sample1ch) {
			GUI.Box (new Rect (sw/2 -sw/5, sh/2-sh/4, sw*2 / 5, sh/2), "국가별 정보");
			if(GUI.Button(new Rect(sw/2 +sw/5 - 30 ,sh/2-sh/4,30,20),"X"))
				sample1ch = false;
			GUI.Label(new Rect (sw/2 -sw/5 + 20, sh/2-sh/4 + 40, 40, 20), "국가명");
			GUI.Label(new Rect (sw/2 -sw/5 + 20, sh/2-sh/4 + 80, 40, 20), "성향");
			GUI.Label(new Rect (sw/2 -sw/5 + 20, sh/2-sh/4 + 120, 40, 20), "재산");
			GUI.Label(new Rect (sw/2 -sw/5 + 20, sh/2-sh/4 + 160, 70, 20), "소유 발전소");

			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh/4 + 40, 40, 20), ""+NationScript.RNation[0].Name);
			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh/4 + 80, 40, 20), ""+NationScript.RNation[0].Tendancy);
			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh/4 + 120, 40, 20), ""+NationScript.RNation[0].Money);
		}
	}
}
