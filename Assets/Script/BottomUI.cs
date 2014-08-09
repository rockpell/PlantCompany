using UnityEngine;
using System.Collections;

public class BottomUI : MonoBehaviour {

	public static int nationSelect = 0; // 나라 선택
	public static bool constructCheck = false;
	public Vector2 scrollPosition = Vector2.zero;

	bool ActionButton = false; // 확인창 활성화

	int sw = Screen.width;
	int sh = Screen.height;

	int selectNumber=0; // 선택 번호 ex) 1:정보수집, 2:수력, 3: 화력, 4:원자력, 5:태양광, 6:풍력, 7:중력

	string actionText;
	
	void Start () {
	
	}

	void Update () {
	
	}

	void initialize(){  // 버튼 선택, 건설 및 정보 선택 초기화
		ActionButton = false;
		selectNumber = 0;
	}

	void OnGUI(){
		if (nationSelect>0) {
			if(GUI.Button (new Rect (sw * 4 / 5 - 10, sh * 5 / 6, sw / 10, sh / 20), "발전기술판매")){
				if(constructCheck)constructCheck=false;
				else constructCheck = true;
			}
			if(GUI.Button (new Rect (sw * 4 / 5 + sw / 10 - 5, sh * 5 / 6, sw / 10, sh / 20), "정보수집")){
				ActionButton = true;
				constructCheck=false;
				selectNumber = 1;
				ActionText("정보수집을 ");
			}
		}
		if (constructCheck) {
			GUI.Box (new Rect (sw * 7 / 10, sh * 2 / 5, sw*3 / 10 , sh * 2 / 5), "");
			scrollPosition = GUI.BeginScrollView (new Rect (sw * 7 / 10, sh * 2 / 5, sw*3 / 10, sh * 2 / 5), scrollPosition, new Rect (0, 0, sw / 5 - 20, sh / 2 + 10));
			if (GUI.Button (new Rect (10, 10, sw / 6, sh / 15), "수력발전기술")) {
				ActionButton = true;
				ActionText ("수력발전기술을 판매");
				if(NationScript.RNation[nationSelect-1].PlantData.water>0){
					GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "이미 기술을 판매하였습니다.");
					ActionButton = false;
				}
				else if(PlayerState.waterLevel==0)selectNumber = 8;
				else selectNumber = 2;
			}
			GUI.Label(new Rect(10 + sw / 6 +10, 10, sw/16, sh/20), "소유자 : "+NationScript.RNation[nationSelect-1].PlantData.water); 

			if (GUI.Button (new Rect (10, 10 * 2 + sh / 15, sw / 6, sh / 15), "화력발전기술")) {
				ActionButton = true;
				ActionText ("화력발전기술을 판매");
				if(NationScript.RNation[nationSelect-1].PlantData.fire>0){
					GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "이미 기술을 판매하였습니다.");
					ActionButton = false;
				}
				else if(PlayerState.fireLevel==0)selectNumber = 8;
				else selectNumber = 3;
			}
			GUI.Label(new Rect(10 + sw/6 +10, 10 * 2 + sh / 15, sw / 16, sh / 20),"소유자 : "+NationScript.RNation[nationSelect-1].PlantData.fire);

			if (GUI.Button (new Rect (10, 10 * 3 + sh * 2 / 15, sw / 6, sh / 15), "원자력발전기술")) {
				ActionButton = true;
				ActionText ("원자력발전기술을 판매");
				if(NationScript.RNation[nationSelect-1].PlantData.nuclear>0){
					GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "이미 기술을 판매하였습니다.");
					ActionButton = false;
				}
				else if(PlayerState.nuclearLevel==0)selectNumber = 8;
				else selectNumber = 4;
			}
			GUI.Label(new Rect(10 + sw/6 +10, 10 * 3 + sh * 2 / 15, sw / 16, sh / 20),"소유자 : "+NationScript.RNation[nationSelect-1].PlantData.nuclear);

			if (GUI.Button (new Rect (10, 10 * 4 + sh * 3 / 15, sw / 6, sh / 15), "태양광발전기술")) {
				ActionButton = true;
				ActionText ("태양광발전기술을 판매");
				if(NationScript.RNation[nationSelect-1].PlantData.sun>0){
					GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "이미 기술을 판매하였습니다.");
					ActionButton = false;
				}
				else if(PlayerState.sunLevel==0)selectNumber = 8;
				else selectNumber = 5;
			}
			GUI.Label(new Rect(10 + sw/6 +10, 10 * 4 + sh * 3 / 15, sw / 16, sh / 20),"소유자 : "+NationScript.RNation[nationSelect-1].PlantData.sun);

			if (GUI.Button (new Rect (10, 10 * 5 + sh * 4 / 15, sw / 6, sh / 15), "풍력발전기술")) {
				ActionButton = true;
				ActionText ("풍력발전기술을 판매");
				if(NationScript.RNation[nationSelect-1].PlantData.wind>0){
					GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "이미 기술을 판매하였습니다.");
					ActionButton = false;
				}
				else if(PlayerState.windLevel==0)selectNumber = 8;
				else selectNumber = 6;
			}
			GUI.Label(new Rect(10 + sw/6 +10, 10 * 5 + sh * 4 / 15, sw / 16, sh / 20),"소유자 : "+NationScript.RNation[nationSelect-1].PlantData.wind);

			if (GUI.Button (new Rect (10, 10 * 6 + sh * 5 / 15, sw / 6, sh / 15), "중력발전기술")) {
				ActionButton = true;
				ActionText ("중력발전기술을 판매");
				if(NationScript.RNation[nationSelect-1].PlantData.gravity>0){
					GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "이미 기술을 판매하였습니다.");
					ActionButton = false;
				}
				else if(PlayerState.gravityLevel==0)selectNumber = 8;
				else selectNumber = 7;
			}
			GUI.Label(new Rect(10 + sw/6 +10, 10 * 6 + sh * 5 / 15, sw / 16, sh / 20),"소유자 : "+NationScript.RNation[nationSelect-1].PlantData.gravity);

			GUI.EndScrollView ();
				}
		if (ActionButton) {
			GUI.Box (new Rect (sw/2 - sw/10, sh/2 - sh/12, sw*2 / 9, sh/6), ""+actionText);
			if(GUI.Button(new Rect(sw/2 - sw/15, sh/2, sw / 15, sh/18), "확인")){
				SelectMethod(selectNumber);
				initialize();
			}
			if(GUI.Button(new Rect(sw/2 +10, sh/2, sw / 15, sh/18), "취소"))
				initialize();
				}
	}

	void ActionText(string abc){
		actionText = string.Format("{0}",abc)+"하시겠습니까?";
	}

	void SelectMethod(int number){
		switch (number) {
		case 1:
			if(PlayerState.Money>=300){
				NationScript.RNation[nationSelect-1].DataLevel += 1;
				PlayerState.Money -= 300;
				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "정보수집을 시작합니다");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 2:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantData.water = 1;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "수력발전기술을 판매하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 3:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantData.fire = 1;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "화력발전기술을 판매하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 4:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantData.nuclear = 1;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "원자력발전기술을 판매하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 5:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantData.sun = 1;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "태양광발전기술을 판매하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 6:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantData.wind = 1;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "풍력발전기술을 판매하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 7:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantData.gravity = 1;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "중력발전기술을 판매하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 8:
			GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "발전 기술이 1이상이여만 판매가 가능합니다");
			break;
		}
	}
}
