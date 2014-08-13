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
			if(GUI.Button (new Rect (sw * 4 / 5 - 10, sh * 5 / 6, sw / 10, sh / 20), "발전소 건설")){
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
			GUI.Box (new Rect (sw * 7 / 10, sh * 2 / 5 - sh * 2 / 15, sw*3 / 10 , sh * 2 / 5 + sh * 2 / 15 ), "");

			if (GUI.Button (new Rect (sw * 7 / 10 + 10,sh * 2 / 5 +  10 - sh * 2 / 15, sw / 6, sh / 15), "수력발전소")) {
				ActionButton = true;
				ActionText ("수력발전소를 건설");
				if(PlayerState.waterLevel==0)selectNumber = 8;
				else selectNumber = 2;
			}
			GUI.Label(new Rect(sw * 7 / 10+ 10 + sw / 6 +10, sh * 2 / 5+ 10 - sh * 2 / 15, sw/14, sh/20), "소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.water); 

			if (GUI.Button (new Rect (sw * 7 / 10 + 10, sh * 2 / 5 + 10 * 2 - sh / 15, sw / 6, sh / 15), "화력발전소")) {
				ActionButton = true;
				ActionText ("화력발전소를 건설");
				if(PlayerState.fireLevel==0)selectNumber = 8;
				else selectNumber = 3;
			}
			GUI.Label(new Rect(sw * 7 / 10 + 10 + sw/6 +10, sh * 2 / 5 + 10 * 2 - sh / 15, sw / 14, sh / 20),"소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.fire);

			if (GUI.Button (new Rect (sw * 7 / 10 + 10,sh * 2 / 5 + 10 * 3 + sh * 0 / 15, sw / 6, sh / 15), "원자력발전소")) {
				ActionButton = true;
				ActionText ("원자력발전소를 건설");
				if(PlayerState.nuclearLevel==0)selectNumber = 8;
				else selectNumber = 4;
			}
			GUI.Label(new Rect(sw * 7 / 10 + 10 + sw/6 +10, sh * 2 / 5 + 10 * 3 + sh * 0 / 15, sw / 14, sh / 20),"소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.nuclear);

			if (GUI.Button (new Rect (sw * 7 / 10 + 10, sh * 2 / 5+ 10 * 4 + sh * 1 / 15, sw / 6, sh / 15), "태양광발전소")) {
				ActionButton = true;
				ActionText ("태양광발전소를 건설");
				if(PlayerState.sunLevel==0)selectNumber = 8;
				else selectNumber = 5;
			}
			GUI.Label(new Rect(sw * 7 / 10 + 10 + sw/6 +10, sh * 2 / 5 + 10 * 4 + sh * 1 / 15, sw / 14, sh / 20),"소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.sun);

			if (GUI.Button (new Rect (sw * 7 / 10 + 10, sh * 2 / 5 + 10 * 5 + sh * 2 / 15, sw / 6, sh / 15), "풍력발전소")) {
				ActionButton = true;
				ActionText ("풍력발전소를 건설");
				if(PlayerState.windLevel==0)selectNumber = 8;
				else selectNumber = 6;
			}
			GUI.Label(new Rect(sw * 7 / 10 + 10 + sw/6 +10,sh * 2 / 5 + 10 * 5 + sh * 2 / 15, sw / 14, sh / 20),"소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.wind);

			if (GUI.Button (new Rect (sw * 7 / 10 + 10, sh * 2 / 5 + 10 * 6 + sh * 3 / 15, sw / 6, sh / 15), "중력발전소")) {
				ActionButton = true;
				ActionText ("중력발전소를 건설");
				if(PlayerState.gravityLevel==0)selectNumber = 8;
				else selectNumber = 7;
			}
			GUI.Label(new Rect(sw * 7 / 10 + 10 + sw/6 +10, sh * 2 / 5 + 10 * 6 + sh * 3 / 15, sw / 14, sh / 20),"소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.gravity);

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
				NationScript.RNation[nationSelect-1].PlantNumber.water ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.water ++;
				PlayerState.waterNumber++;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "수력발전소를 건설하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 3:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantNumber.fire ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.fire ++;
				PlayerState.fireNumber++;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "화력발전소를 건설하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 4:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantNumber.nuclear ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.nuclear ++;
				PlayerState.nuclearNumber++;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "원자력발전소를 건설하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 5:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantNumber.sun ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.sun ++;
				PlayerState.sunNumber++;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "태양광발전소를 건설하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 6:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantNumber.wind ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.wind ++;
				PlayerState.windNumber++;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "풍력발전소를 건설하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 7:
			if(PlayerState.Money>=500){
				NationScript.RNation[nationSelect-1].PlantNumber.gravity ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.gravity ++;
				PlayerState.gravityNumber++;
				PlayerState.Money -=500;

				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "중력발전소를 건설하였습니다.");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;

		case 8:
			GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "발전 기술이 1이상이여만 건설 가능합니다");
			break;
		}
	}
}
