using UnityEngine;
using System.Collections;

public class BottomUI : MonoBehaviour {

	public static int nationSelect = 0;
	public static bool constructCheck = false;
	public Vector2 scrollPosition = Vector2.zero;

	bool ActionButton = false;

	int sw = Screen.width;
	int sh = Screen.height;

	string actionText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (nationSelect>0) {
			if(GUI.Button (new Rect (sw * 4 / 5 - 10, sh * 5 / 6, sw / 10, sh / 20), "발전소건설")){
				if(constructCheck)constructCheck=false;
				else constructCheck = true;
			}
			if(GUI.Button (new Rect (sw * 4 / 5 + sw / 10 - 5, sh * 5 / 6, sw / 10, sh / 20), "정보수집")){
				ActionButton = true;
				constructCheck=false;
				ActionText("정보수집을 ");
			}
		}
		if (constructCheck) {
						GUI.Box (new Rect (sw * 4 / 5, sh * 2 / 5, sw / 5, sh * 2 / 5), "");
						scrollPosition = GUI.BeginScrollView (new Rect (sw * 4 / 5, sh * 2 / 5, sw / 5, sh * 2 / 5), scrollPosition, new Rect (0, 0, sw / 5 - 20, sh / 2 + 10));
						if(GUI.Button (new Rect (10, 10, sw / 6, sh / 15), "수력발전소")){
							ActionButton = true;
							ActionText("수력발전소를 건설");
						}
						if(GUI.Button (new Rect (10, 10 * 2 + sh / 15, sw / 6, sh / 15), "화력발전소")){
							ActionButton = true;
							ActionText("화력발전소를 건설");
						}
						if(GUI.Button (new Rect (10, 10 * 3 + sh * 2 / 15, sw / 6, sh / 15), "원자력발전소")){
							ActionButton = true;
							ActionText("원자력발전소를 건설");
						}
						if(GUI.Button (new Rect (10, 10 * 4 + sh * 3 / 15, sw / 6, sh / 15), "태양광발전소")){
							ActionButton = true;
							ActionText("태양광발전소를 건설");
						}
						if(GUI.Button (new Rect (10, 10 * 5 + sh * 4 / 15, sw / 6, sh / 15), "풍력발전소")){
							ActionButton = true;
							ActionText("풍력발전소를 건설");
						}
						if(GUI.Button (new Rect (10, 10 * 6 + sh * 5 / 15, sw / 6, sh / 15), "중력발전소")){
							ActionButton = true;
							ActionText("중력발전소를 건설");
						}
						GUI.EndScrollView ();
				}
		if (ActionButton) {
			GUI.Box (new Rect (sw/2 - sw/10, sh/2 - sh/12, sw*2 / 9, sh/6), ""+actionText);
			GUI.Button(new Rect(sw/2 - sw/15, sh/2, sw / 15, sh/18), "확인");
			if(GUI.Button(new Rect(sw/2 +10, sh/2, sw / 15, sh/18), "취소"))
				ActionButton = false;
				}
	}

	void ActionText(string abc){
		actionText = string.Format("{0}",abc)+"하시겠습니까?";
	}

}
