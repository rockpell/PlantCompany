using UnityEngine;
using System.Collections;

public class BottomUI : MonoBehaviour {

	public static int nationSelect = 0;

	int sw = Screen.width;
	int sh = Screen.height;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (nationSelect>0) {
			GUI.Button (new Rect (sw * 4 / 5 - 10, sh * 5 / 6, sw / 10, sh / 20), "기술지원");
			GUI.Button (new Rect (sw * 4 / 5 + sw / 10 - 5, sh * 5 / 6, sw / 10, sh / 20), "정보수집");
		}
	}
}
