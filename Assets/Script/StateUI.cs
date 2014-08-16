using UnityEngine;
using System.Collections;

public class StateUI : MonoBehaviour {

	public Vector2 scrollPosition = Vector2.zero;

	GUIText State;

	int sw = Screen.width;
	int sh = Screen.height;
	int selectNumber;

	bool sample1ch = false;
	bool sample2ch = false;
	bool sample3ch = false;
	bool actionButton = false;
	bool pause = false; // 게임 일시정지 변수

	int characteristic = 0; // 특성 변수
	int characterSelect = 0; // 특성 선택
	string charText;

	string actionText;

	PlayerState abc = new PlayerState ();

	void Start () {
		State = gameObject.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		State.text = "현재 자금 보유량 : " + string.Format("{0}",PlayerState.Money);
		if (Time.timeScale == 0) {
			pause = true;
			sample1ch = false;
			sample2ch = false;
			sample3ch = false;
			actionButton = false;
		}
		else if (Time.timeScale == 1)
			pause = false;
	}

	void initialize(){
		actionButton = false;
		selectNumber = 0;
		characteristic = 0;
		characterSelect = 0;
	}
	

	void OnGUI(){
		if (GUI.Button (new Rect (0, sh / 3 - sh*1/32, sw / 10, sh / 14), "국가별 정보") && !pause) {
			if (sample2ch)
				sample2ch = false;
			if(sample3ch){
				sample3ch = false;
				characteristic=0;
			}
			if (sample1ch)
				sample1ch = false;
			else
				sample1ch = true;
				}
		if (GUI.Button (new Rect (0, sh / 3 + sh*2 / 32, sw / 10, sh / 14), "기술") && !pause) {
			if (sample1ch)
					sample1ch = false;
			if(sample3ch){
				sample3ch = false;
				characteristic=0;
			}
			if (sample2ch)
				sample2ch = false;
			else
				sample2ch = true;
				}
		if(GUI.Button (new Rect(0,sh/3+sh*5/32,sw / 10,sh/14),"기술 특성") && !pause){
			if (sample1ch)
				sample1ch = false;
			if(sample2ch)
				sample2ch = false;
			if (sample3ch){
				sample3ch = false;
				characteristic=0;
			}
			else
				sample3ch = true;
		}

		if (sample1ch) {

			GUI.BeginGroup(new Rect(sw/2 -sw*3/10, sh/2-sh*3/8, sw*6 / 10, sh/2+sw*2/64));
			
			GUI.Box (new Rect (0, 0, sw*6 / 10, sh/2+sw*2/64), "국가별 정보");

			GUI.Label(new Rect (sw/64, 40, 40, sw*2/64), "국가명");
			GUI.Label(new Rect (sw/64, 80, 40, sw*2/64), "성향");
			GUI.Label(new Rect (sw/64, 120, 40, sw*2/64), "재산");
			GUI.Label(new Rect (sw/64, 160, 70, sw*2/64), "소유 발전소");

			GUI.Label(new Rect (sw/64 +sw*13/128,  40, 50, sw*2/64), ""+NationScript.RNation[0].Name);
			GUI.Label(new Rect (sw/64 +sw*13/128,  80, 50, sw*2/64), ""+NationScript.RNation[0].Tendancy);
			GUI.Label(new Rect (sw/64 +sw*13/128,  120, 50, sw*2/64), ""+NationScript.RNation[0].Money);

			GUI.Label(new Rect (sw/64 +sw*25/128,  40, 50, sw*2/64), ""+NationScript.RNation[1].Name);
			GUI.Label(new Rect (sw/64 +sw*25/128,  80, 50, sw*2/64), ""+NationScript.RNation[1].Tendancy);
			GUI.Label(new Rect (sw/64 +sw*25/128,  120, 50, sw*2/64), ""+NationScript.RNation[1].Money);

			GUI.Label(new Rect (sw/64 +sw*37/128,  40, 50, sw*2/64), ""+NationScript.RNation[2].Name);
			GUI.Label(new Rect (sw/64 +sw*37/128,  80, 50, sw*2/64), ""+NationScript.RNation[2].Tendancy);
			GUI.Label(new Rect (sw/64 +sw*37/128,  120, 50, sw*2/64), ""+NationScript.RNation[2].Money);

			GUI.Label(new Rect (sw/64 +sw*49/128,  40, 50, sw*2/64), ""+NationScript.RNation[3].Name);
			GUI.Label(new Rect (sw/64 +sw*49/128,  80, 50, sw*2/64), ""+NationScript.RNation[3].Tendancy);
			GUI.Label(new Rect (sw/64 +sw*49/128,  120, 50, sw*2/64), ""+NationScript.RNation[3].Money);

			GUI.Label(new Rect (sw/64 +sw*61/128,  40, 50, sw*2/64), ""+NationScript.RNation[4].Name);
			GUI.Label(new Rect (sw/64 +sw*61/128,  80, 50, sw*2/64), ""+NationScript.RNation[4].Tendancy);
			GUI.Label(new Rect (sw/64 +sw*61/128,  120, 50, sw*2/64), ""+NationScript.RNation[4].Money);

			GUI.Label(new Rect (sw/64 +sw*13/128,  160, 40, sw*2/64), "수력");
			GUI.Label(new Rect (sw/64 +sw*13/128,  180, 40, sw*2/64), "화력");
			GUI.Label(new Rect (sw/64 +sw*13/128,  200, 40, sw*2/64), "원자력");
			GUI.Label(new Rect (sw/64 +sw*13/128,  220, 40, sw*2/64), "태양광");
			GUI.Label(new Rect (sw/64 +sw*13/128,  240, 40, sw*2/64), "풍력");
			GUI.Label(new Rect (sw/64 +sw*13/128,  260, 40, sw*2/64), "중력");

			GUI.Label(new Rect (sw/64 +sw*13/128+50,  160, 40, sw*2/64), ""+NationScript.RNation[0].PlantNumber.water);
			GUI.Label(new Rect (sw/64 +sw*13/128+50,  180, 40, sw*2/64), ""+NationScript.RNation[0].PlantNumber.fire);
			GUI.Label(new Rect (sw/64 +sw*13/128+50,  200, 40, sw*2/64), ""+NationScript.RNation[0].PlantNumber.nuclear);
			GUI.Label(new Rect (sw/64 +sw*13/128+50,  220, 40, sw*2/64), ""+NationScript.RNation[0].PlantNumber.sun);
			GUI.Label(new Rect (sw/64 +sw*13/128+50,  240, 40, sw*2/64), ""+NationScript.RNation[0].PlantNumber.wind);
			GUI.Label(new Rect (sw/64 +sw*13/128+50,  260, 40, sw*2/64), ""+NationScript.RNation[0].PlantNumber.gravity);

			GUI.Label(new Rect (sw/64 +sw*25/128,  160, 40, sw*2/64), "수력");
			GUI.Label(new Rect (sw/64 +sw*25/128,  180, 40, sw*2/64), "화력");
			GUI.Label(new Rect (sw/64 +sw*25/128,  200, 40, sw*2/64), "원자력");
			GUI.Label(new Rect (sw/64 +sw*25/128,  220, 40, sw*2/64), "태양광");
			GUI.Label(new Rect (sw/64 +sw*25/128,  240, 40, sw*2/64), "풍력");
			GUI.Label(new Rect (sw/64 +sw*25/128,  260, 40, sw*2/64), "중력");

			GUI.Label(new Rect (sw/64 +sw*25/128+50,  160, 40, sw*2/64), ""+NationScript.RNation[1].PlantNumber.water);
			GUI.Label(new Rect (sw/64 +sw*25/128+50,  180, 40, sw*2/64), ""+NationScript.RNation[1].PlantNumber.fire);
			GUI.Label(new Rect (sw/64 +sw*25/128+50,  200, 40, sw*2/64), ""+NationScript.RNation[1].PlantNumber.nuclear);
			GUI.Label(new Rect (sw/64 +sw*25/128+50,  220, 40, sw*2/64), ""+NationScript.RNation[1].PlantNumber.sun);
			GUI.Label(new Rect (sw/64 +sw*25/128+50,  240, 40, sw*2/64), ""+NationScript.RNation[1].PlantNumber.wind);
			GUI.Label(new Rect (sw/64 +sw*25/128+50,  260, 40, sw*2/64), ""+NationScript.RNation[1].PlantNumber.gravity);

			GUI.Label(new Rect (sw/64 +sw*37/128,  160, 40, sw*2/64), "수력");
			GUI.Label(new Rect (sw/64 +sw*37/128,  180, 40, sw*2/64), "화력");
			GUI.Label(new Rect (sw/64 +sw*37/128,  200, 40, sw*2/64), "원자력");
			GUI.Label(new Rect (sw/64 +sw*37/128,  220, 40, sw*2/64), "태양광");
			GUI.Label(new Rect (sw/64 +sw*37/128,  240, 40, sw*2/64), "풍력");
			GUI.Label(new Rect (sw/64 +sw*37/128,  260, 40, sw*2/64), "중력");

			GUI.Label(new Rect (sw/64 +sw*37/128+50,  160, 40, sw*2/64), ""+NationScript.RNation[2].PlantNumber.water);
			GUI.Label(new Rect (sw/64 +sw*37/128+50,  180, 40, sw*2/64), ""+NationScript.RNation[2].PlantNumber.fire);
			GUI.Label(new Rect (sw/64 +sw*37/128+50,  200, 40, sw*2/64), ""+NationScript.RNation[2].PlantNumber.nuclear);
			GUI.Label(new Rect (sw/64 +sw*37/128+50,  220, 40, sw*2/64), ""+NationScript.RNation[2].PlantNumber.sun);
			GUI.Label(new Rect (sw/64 +sw*37/128+50,  240, 40, sw*2/64), ""+NationScript.RNation[2].PlantNumber.wind);
			GUI.Label(new Rect (sw/64 +sw*37/128+50,  260, 40, sw*2/64), ""+NationScript.RNation[2].PlantNumber.gravity);

			GUI.Label(new Rect (sw/64 +sw*49/128,  160, 40, sw*2/64), "수력");
			GUI.Label(new Rect (sw/64 +sw*49/128,  180, 40, sw*2/64), "화력");
			GUI.Label(new Rect (sw/64 +sw*49/128,  200, 40, sw*2/64), "원자력");
			GUI.Label(new Rect (sw/64 +sw*49/128,  220, 40, sw*2/64), "태양광");
			GUI.Label(new Rect (sw/64 +sw*49/128,  240, 40, sw*2/64), "풍력");
			GUI.Label(new Rect (sw/64 +sw*49/128,  260, 40, sw*2/64), "중력");

			GUI.Label(new Rect (sw/64 +sw*49/128+50,  160, 40, sw*2/64), ""+NationScript.RNation[3].PlantNumber.water);
			GUI.Label(new Rect (sw/64 +sw*49/128+50,  180, 40, sw*2/64), ""+NationScript.RNation[3].PlantNumber.fire);
			GUI.Label(new Rect (sw/64 +sw*49/128+50,  200, 40, sw*2/64), ""+NationScript.RNation[3].PlantNumber.nuclear);
			GUI.Label(new Rect (sw/64 +sw*49/128+50,  220, 40, sw*2/64), ""+NationScript.RNation[3].PlantNumber.sun);
			GUI.Label(new Rect (sw/64 +sw*49/128+50,  240, 40, sw*2/64), ""+NationScript.RNation[3].PlantNumber.wind);
			GUI.Label(new Rect (sw/64 +sw*49/128+50,  260, 40, sw*2/64), ""+NationScript.RNation[3].PlantNumber.gravity);

			GUI.Label(new Rect (sw/64 +sw*61/128,  160, 40, sw*2/64), "수력");
			GUI.Label(new Rect (sw/64 +sw*61/128,  180, 40, sw*2/64), "화력");
			GUI.Label(new Rect (sw/64 +sw*61/128,  200, 40, sw*2/64), "원자력");
			GUI.Label(new Rect (sw/64 +sw*61/128,  220, 40, sw*2/64), "태양광");
			GUI.Label(new Rect (sw/64 +sw*61/128,  240, 40, sw*2/64), "풍력");
			GUI.Label(new Rect (sw/64 +sw*61/128,  260, 40, sw*2/64), "중력");

			GUI.Label(new Rect (sw/64 +sw*61/128+50,  160, 40, sw*2/64), ""+NationScript.RNation[4].PlantNumber.water);
			GUI.Label(new Rect (sw/64 +sw*61/128+50,  180, 40, sw*2/64), ""+NationScript.RNation[4].PlantNumber.fire);
			GUI.Label(new Rect (sw/64 +sw*61/128+50,  200, 40, sw*2/64), ""+NationScript.RNation[4].PlantNumber.nuclear);
			GUI.Label(new Rect (sw/64 +sw*61/128+50,  220, 40, sw*2/64), ""+NationScript.RNation[4].PlantNumber.sun);
			GUI.Label(new Rect (sw/64 +sw*61/128+50,  240, 40, sw*2/64), ""+NationScript.RNation[4].PlantNumber.wind);
			GUI.Label(new Rect (sw/64 +sw*61/128+50,  260, 40, sw*2/64), ""+NationScript.RNation[4].PlantNumber.gravity);

				GUI.EndGroup();
		}

		if (sample2ch) {
			GUI.Box (new Rect (sw/2 -sw/5, sh/2-sh*3/8, sw*2 / 5, sh*5/8), "발전기술");

			scrollPosition = GUI.BeginScrollView (new Rect (sw/2 -sw/5, sh/2-sh*3/8+20, sw*2 / 5, sh*5/8), scrollPosition, new Rect (0, 0, 0, 0));
			GUI.Label(new Rect(10, sh*3/64, sw/4, sh/16),"수력발전 " + LevelText(PlayerState.waterLevel, 1));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*3/64, sw/14, sh/15),"투자") && !pause){
				actionButton = true;
				selectNumber = 1;
				actionText = "수력발전에 투자하시겠습니까?";
			}
			GUI.Label(new Rect(10, sh*9/64, sw/4, sh/16),"화력발전 " + LevelText(PlayerState.fireLevel, 2));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*9/64, sw/14, sh/15),"투자") && !pause){
				actionButton = true;
				selectNumber = 2;
				actionText = "화력발전에 투자하시겠습니까?";
			}
			GUI.Label(new Rect(10, sh*15/64, sw/4, sh/16),"원자력발전 " + LevelText(PlayerState.nuclearLevel, 3));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*15/64, sw/14, sh/15),"투자") && !pause){
				actionButton = true;
				selectNumber = 3;
				actionText = "원자력발전에 투자하시겠습니까?";
			}
			GUI.Label(new Rect(10, sh*21/64, sw/4, sh/16),"태양광발전 " + LevelText(PlayerState.sunLevel, 4));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*21/64, sw/14, sh/15),"투자") && !pause){
				actionButton = true;
				selectNumber = 4;
				actionText = "태양광발전에 투자하시겠습니까?";
			}
			GUI.Label(new Rect(10, sh*27/64, sw/4, sh/16),"풍력발전 " + LevelText(PlayerState.windLevel, 5));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*27/64, sw/14, sh/15),"투자") && !pause){
				actionButton = true;
				selectNumber = 5;
				actionText = "풍력발전에 투자하시겠습니까?";
			}
			GUI.Label(new Rect(10, sh*33/64, sw/4, sh/16),"중력발전 " + LevelText(PlayerState.gravityLevel, 6));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*33/64, sw/14, sh/15),"투자") && !pause){
				actionButton = true;
				selectNumber = 6;
				actionText = "중력발전에 투자하시겠습니까?";
			}
			GUI.EndScrollView ();
			}

		if (sample3ch) {
			GUI.BeginGroup(new Rect(sw/2 -sw*5/40, sh/2-sh*3/8, sw*5 / 20, sh*10/16));
			GUI.Box (new Rect (0, 0, sw*5 / 20, sh*10/16), "기술특성");

			if(GUI.Button(new Rect(sw*5/40 - sw/10,  sh*1/32+10, sw/5, sh / 15),"수력발전") && !pause){
				characteristic=1;
				charText="수력";
			}
			if(GUI.Button(new Rect(sw*5/40 - sw/10,  sh*4/32+10, sw/5, sh / 15),"화력발전") && !pause){
				characteristic=2;
				charText="화력";
			}
			if(GUI.Button(new Rect(sw*5/40 - sw/10,  sh*7/32+10, sw/5, sh / 15),"원자력발전") && !pause){
				characteristic=3;
				charText="원자력";
			}
			if(GUI.Button(new Rect(sw*5/40 - sw/10,  sh*10/32+10, sw/5, sh / 15),"태양광발전") && !pause){
				characteristic=4;
				charText="태양광";
			}
			if(GUI.Button(new Rect(sw*5/40 - sw/10,  sh*13/32+10, sw/5, sh / 15),"풍력발전") && !pause){
				characteristic=5;
				charText="풍력";
			}
			if(GUI.Button(new Rect(sw*5/40 - sw/10,  sh*16/32+10, sw/5, sh / 15),"중력발전") && !pause){
				characteristic=6;
				charText="중력";
			}
			GUI.EndGroup();
			}
		
		if(sample3ch && characteristic>0){
			GUI.BeginGroup(new Rect(sw/2 + sw*5/40, sh/2-sh*2/8, sw*1 / 5, sh/4));

			GUI.Box(new Rect(0,0, sw*1 / 5, sh/4), charText+"특성");

			if(GUI.Button(new Rect(0, sh/30, sw*1/5, sh/16),"건설 비용 감소") && !pause){
				characterSelect = 1;
				actionButton = true;
				actionText = "건설 비용 감소 특성 투자";
			}
			if(GUI.Button(new Rect(0, sh/30 + sh/16 +5, sw*1 / 5, sh/16),"생산량 증가") && !pause){
				characterSelect = 2;
				actionButton = true;
				actionText = "생산량 증가 특성 투자";
			}
			if(GUI.Button(new Rect(0, sh/30 + sh*2/16 +10, sw*1 / 5, sh/16),"친환경성 증가") && !pause){
				characterSelect = 3;
				actionButton = true;
				actionText = "친환경성 증가 특성 투자";
			}

			GUI.EndGroup();
		}

		if (actionButton) {
			GUI.Box (new Rect (sw/2 - sw*9/64, sh/2 - sh/12, sw*18 / 64, sh/6), ""+actionText);
			if(GUI.Button(new Rect(sw/2 - sw/15, sh/2, sw / 15, sh/18), "확인") && !pause){
				if(selectNumber!=0)SelectMethod(selectNumber);
				if(characteristic!=0)PlayerState.PlantChar(characteristic,characterSelect);
				initialize();

			}
			if(GUI.Button(new Rect(sw/2 +10, sh/2, sw / 15, sh/18), "취소") && !pause){
				initialize();
			}
		}
	}

	void SelectMethod(int number){
		switch (number) {
			
		case 1:
			if(PlayerState.Money>=500){
				PlayerState.waterLevel += 1;
				PlayerState.Money -=500;
				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "수력발전 기술에 투자하였습니다");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;
			
		case 2:
			if(PlayerState.Money>=500){
				PlayerState.fireLevel += 1;
				PlayerState.Money -=500;
				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "화력발전 기술에 투자하였습니다");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;
			
		case 3:
			if(PlayerState.Money>=500){
				PlayerState.nuclearLevel += 1;
				PlayerState.Money -=500;
				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "원자력발전 기술에 투자하였습니다");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;
			
		case 4:
			if(PlayerState.Money>=500){
				PlayerState.sunLevel += 1;
				PlayerState.Money -=500;
				
				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "태양광발전 기술에 투자하였습니다");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;
			
		case 5:
			if(PlayerState.Money>=500){
				PlayerState.windLevel += 1;
				PlayerState.Money -=500;
				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "풍력발전 기술에 투자하였습니다");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;
			
		case 6:
			if(PlayerState.Money>=500){
				PlayerState.gravityLevel += 1;
				PlayerState.Money -=500;
				GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "중력발전 기술에 투자하였습니다");
			}
			else GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "돈이 모자랍니다");
			break;
		}
	}

	string LevelText(int number, int plantKind){
		string text= "";

		switch (plantKind) {
				case 1:
						text = "Lv" + number + " 투자비용 : 500"; // 투자비용은 기술의 종류와 레벨마다 다르기 때문에 구분
						break;
				case 2:
						text = "Lv" + number + " 투자비용 : 500";
						break;
				case 3:
						text = "Lv" + number + " 투자비용 : 500";
						break;
				case 4:
						text = "Lv" + number + " 투자비용 : 500";
						break;
				case 5:
						text = "Lv" + number + " 투자비용 : 500";
						break;
				case 6:
						text = "Lv" + number + " 투자비용 : 500";
						break;
				}
		
			return text;
	}
}
