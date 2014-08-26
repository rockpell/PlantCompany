using UnityEngine;
using System.Collections;

public class BottomUI : MonoBehaviour {

	public static int nationSelect = 0; // 나라 선택
	public static bool constructCheck = false;
	public Vector2 scrollPosition = Vector2.zero;

	bool ActionButton = false; // 확인창 활성화
	bool pause = false; // 게임 일시정지 변수

	int sw = Screen.width;
	int sh = Screen.height;

	int selectNumber=0; // 선택 번호 ex) 1:정보수집, 2:수력, 3: 화력, 4:원자력, 5:태양광, 6:풍력, 7:중력

	string actionText;
	
	void Start () {

	}

	void Update () {
		if (Time.timeScale == 0) {
			pause = true;
			ActionButton = false;
			constructCheck = false;
			}
		else if (Time.timeScale == 1)
						pause = false;
	}

	void initialize(){  // 버튼 선택, 건설 및 정보 선택 초기화
		ActionButton = false;
		selectNumber = 0;
	}

	void OnGUI(){
		if (nationSelect>0) {
			if(GUI.Button (new Rect (sw * 17 / 20, sh * 10 / 12, sw / 10, sh / 15), "발전소 건설") && !pause){
				if(constructCheck)constructCheck=false;
				else constructCheck = true;
			}
			if(GUI.Button (new Rect (sw * 17 / 20, sh * 11 / 12, sw / 10, sh / 15), "정보수집") && !pause){
				ActionButton = true;
				constructCheck=false;
				selectNumber = 1;
				ActionText("정보수집을 ");
			}
		}
		if (constructCheck) {
			GUI.BeginGroup(new Rect(sw * 7 / 10, sh * 2 / 5 - sh * 2 / 15, sw*3 / 10 , sh * 15 / 30+10));
			GUI.Box (new Rect (0,0, sw*3 / 10 , sh * 15 / 30+10), "");

			if (GUI.Button (new Rect (10,10, sw / 6, sh / 15), "수력발전소("+PlayerState.waterCost+")") && !pause) {
				ActionButton = true;
				ActionText ("수력발전소를 건설");
				if(PlayerState.waterLevel==0)selectNumber = 8;
				else selectNumber = 2;
			}
			GUI.Label(new Rect(10 + sw / 6 +10, 10, sw/12, sh/20), "소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.water); 

			if (GUI.Button (new Rect (10, 10 * 2 + sh / 15, sw / 6, sh / 15), "화력발전소("+PlayerState.fireCost+")") && !pause) {
				ActionButton = true;
				ActionText ("화력발전소를 건설");
				if(PlayerState.fireLevel==0)selectNumber = 8;
				else selectNumber = 3;
			}
			GUI.Label(new Rect(10 + sw/6 +10, 10 * 2 +sh / 15, sw / 12, sh / 20),"소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.fire);

			if (GUI.Button (new Rect (10, 10 * 3 + sh * 2 / 15, sw / 6, sh / 15), "원자력발전소("+PlayerState.nuclearCost+")") && !pause) {
				ActionButton = true;
				ActionText ("원자력발전소를 건설");
				if(PlayerState.nuclearLevel==0)selectNumber = 8;
				else selectNumber = 4;
			}
			GUI.Label(new Rect(10 + sw/6 +10, 10 * 3 + sh * 2 / 15, sw / 12, sh / 20),"소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.nuclear);

			if (GUI.Button (new Rect (10, 10 * 4 + sh * 3 / 15, sw / 6, sh / 15), "태양광발전소("+PlayerState.sunCost+")") && !pause) {
				ActionButton = true;
				ActionText ("태양광발전소를 건설");
				if(PlayerState.sunLevel==0)selectNumber = 8;
				else selectNumber = 5;
			}
			GUI.Label(new Rect(10 + sw/6 +10, 10 * 4 + sh * 3 / 15, sw / 12, sh / 20),"소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.sun);

			if (GUI.Button (new Rect (10, 10 * 5 + sh * 4 / 15, sw / 6, sh / 15), "풍력발전소("+PlayerState.windCost+")") && !pause) {
				ActionButton = true;
				ActionText ("풍력발전소를 건설");
				if(PlayerState.windLevel==0)selectNumber = 8;
				else selectNumber = 6;
			}
			GUI.Label(new Rect(10 + sw/6 +10, 10 * 5 + sh * 4 / 15, sw / 12, sh / 20),"소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.wind);

			if (GUI.Button (new Rect (10, 10 * 6 + sh * 5 / 15, sw / 6, sh / 15), "중력발전소("+PlayerState.gravityCost+")") && !pause) {
				ActionButton = true;
				ActionText ("중력발전소를 건설");
				if(PlayerState.gravityLevel==0)selectNumber = 8;
				else selectNumber = 7;
			}
			GUI.Label(new Rect(10 + sw/6 +10, 10 * 6 + sh * 5 / 15, sw / 12, sh / 20),"소유수 : "+NationScript.RNation[nationSelect-1].PlayerPlant.gravity);

			GUI.EndGroup();
				}
		if (ActionButton) {
			GUI.Box (new Rect (sw/2 - sw*9/64, sh/2 - sh/12, sw*18 / 64, sh/6), ""+actionText);
				SelectMethod(selectNumber);
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
				AllText("정보수집을 시작합니다");
			}
			else NewsScript.myQue.Enqueue("돈이 모자랍니다");
			break;

		case 2:
			if(PlayerState.Money>=PlayerState.waterCost){
				NationScript.RNation[nationSelect-1].PlantNumber.water ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.water ++;
				PlayerState.waterNumber++;
				PlayerState.Money -=PlayerState.waterCost;
				AllText("수력발전소를 건설하였습니다.");
			}
			else AllText("돈이 모자랍니다");
			break;

		case 3:
			if(PlayerState.Money>=PlayerState.fireCost){
				NationScript.RNation[nationSelect-1].PlantNumber.fire ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.fire ++;
				PlayerState.fireNumber++;
				PlayerState.Money -=PlayerState.fireCost;
				AllText("화력발전소를 건설하였습니다.");
			}
			else AllText("돈이 모자랍니다");
			break;

		case 4:
			if(PlayerState.Money>=PlayerState.nuclearCost){
				NationScript.RNation[nationSelect-1].PlantNumber.nuclear ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.nuclear ++;
				PlayerState.nuclearNumber++;
				PlayerState.Money -=PlayerState.nuclearCost;
				AllText("원자력발전소를 건설하였습니다.");
			}
			else AllText("돈이 모자랍니다");
			break;

		case 5:
			if(PlayerState.Money>=PlayerState.sunCost){
				NationScript.RNation[nationSelect-1].PlantNumber.sun ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.sun ++;
				PlayerState.sunNumber++;
				PlayerState.Money -=PlayerState.sunCost;
				AllText("태양광발전소를 건설하였습니다.");
			}
			else AllText("돈이 모자랍니다");
			break;

		case 6:
			if(PlayerState.Money>=PlayerState.windCost){
				NationScript.RNation[nationSelect-1].PlantNumber.wind ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.wind ++;
				PlayerState.windNumber++;
				PlayerState.Money -=PlayerState.windCost;
				AllText("풍력발전소를 건설하였습니다.");
			}
			else AllText("돈이 모자랍니다");
			break;

		case 7:
			if(PlayerState.Money>=PlayerState.gravityCost){
				NationScript.RNation[nationSelect-1].PlantNumber.gravity ++;
				NationScript.RNation[nationSelect-1].PlayerPlant.gravity ++;
				PlayerState.gravityNumber++;
				PlayerState.Money -=PlayerState.gravityCost;
				AllText("중력발전소를 건설하였습니다.");
			}
			else AllText("돈이 모자랍니다");
			break;

		case 8:
			AllText("발전 기술이 1이상이여만 건설 가능합니다");
			break;
		}
	}

	void AllText(string atext){
		NewsScript.myQue.Enqueue(atext);
	}
}
