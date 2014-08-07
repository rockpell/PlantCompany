using UnityEngine;
using System.Collections;

public class StateUI : MonoBehaviour {

	public Vector2 scrollPosition = Vector2.zero;

	GUIText State;
	
	GUIStyle FirstColor = new GUIStyle();
	GUIStyle SecondColor = new GUIStyle();
	GUIStyle ThirdColor = new GUIStyle();
	GUIStyle FourthColor = new GUIStyle();
	GUIStyle FifthColor = new GUIStyle();
	GUIStyle SixthColor = new GUIStyle();

	int sw = Screen.width;
	int sh = Screen.height;
	int selectNumber;

	bool sample1ch = false;
	bool sample2ch = false;
	bool actionButton = false;

	string actionText;

	PlayerState abc = new PlayerState ();

	void Start () {
		State = gameObject.GetComponent<GUIText>();

		FirstColor.normal.textColor = Color.white;
		SecondColor.normal.textColor = Color.white;
		ThirdColor.normal.textColor = Color.white;
		FourthColor.normal.textColor = Color.white;
		FifthColor.normal.textColor = Color.white;
		SixthColor.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		State.text = "현재 자금 보유량 : " + string.Format("{0}",PlayerState.Money);

		TextColorChange ();
	}

	void initialize(){
		actionButton = false;
		selectNumber = 0;
	}

	void TextColorChange(){
		if (NationScript.RNation [0].PlantData.water == 1)
						FirstColor.normal.textColor = Color.red;
		if (NationScript.RNation [0].PlantData.fire == 1)
						SecondColor.normal.textColor = Color.red;
		if (NationScript.RNation [0].PlantData.nuclear == 1)
						ThirdColor.normal.textColor = Color.red;
		if (NationScript.RNation [0].PlantData.sun == 1)
						FourthColor.normal.textColor = Color.red;
		if (NationScript.RNation [0].PlantData.wind == 1)
						FifthColor.normal.textColor = Color.red;
		if (NationScript.RNation [0].PlantData.gravity == 1)
						SixthColor.normal.textColor = Color.red;
	}

	void OnGUI(){
		if (GUI.Button (new Rect (0, sh / 3, sw / 12, sh / 16), "국가별 정보")) {
						if (sample2ch)
								sample2ch = false;
						if (sample1ch)
								sample1ch = false;
						else
								sample1ch = true;
				}
		if (GUI.Button (new Rect (0, sh / 3 + sh / 16, sw / 15, sh / 16), "기술")) {
						if (sample1ch)
								sample1ch = false;
						if (sample2ch)
								sample2ch = false;
						else
								sample2ch = true;
				}
		GUI.Button (new Rect(0,sh/3+sh/8,sw/15,sh/16),"Sample3");

		if (sample1ch) {
			GUI.Box (new Rect (sw/2 -sw/5, sh/2-sh*3/8, sw*2 / 5, sh/2), "국가별 정보");
			if(GUI.Button(new Rect(sw/2 +sw/5 - 30 ,sh/2-sh*3/8,30,20),"X"))
				sample1ch = false;
			GUI.Label(new Rect (sw/2 -sw/5 + 20, sh/2-sh*3/8 + 40, 40, 20), "국가명");
			GUI.Label(new Rect (sw/2 -sw/5 + 20, sh/2-sh*3/8 + 80, 40, 20), "성향");
			GUI.Label(new Rect (sw/2 -sw/5 + 20, sh/2-sh*3/8 + 120, 40, 20), "재산");
			GUI.Label(new Rect (sw/2 -sw/5 + 20, sh/2-sh*3/8 + 160, 70, 20), "소유 발전소");

			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh*3/8 + 40, 40, 20), ""+NationScript.RNation[0].Name);
			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh*3/8 + 80, 40, 20), ""+NationScript.RNation[0].Tendancy);
			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh*3/8 + 120, 40, 20), ""+NationScript.RNation[0].Money);

			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh*3/8 + 160, 40, 20), "수력",FirstColor);
			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh*3/8 + 180, 40, 20), "화력",SecondColor);
			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh*3/8 + 200, 40, 20), "원자력",ThirdColor);
			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh*3/8 + 220, 40, 20), "태양광",FourthColor);
			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh*3/8 + 240, 40, 20), "풍력",FifthColor);
			GUI.Label(new Rect (sw/2 -sw/5 + 20 +90, sh/2-sh*3/8 + 260, 40, 20), "중력",SixthColor);
		}

		if (sample2ch) {
			GUI.Box (new Rect (sw/2 -sw/5, sh/2-sh*3/8, sw*2 / 5, sh/2+20), "발전기술");
			if(GUI.Button(new Rect(sw/2 +sw/5 - 30 ,sh/2-sh*3/8,30,20),"X"))
				sample2ch = false;
			scrollPosition = GUI.BeginScrollView (new Rect (sw/2 -sw/5, sh/2-sh*3/8+20, sw*2 / 5, sh/2), scrollPosition, new Rect (0, 0, sw*2 / 5-20, sh*2/3));
			GUI.Label(new Rect(10, sh/16, sw/5, sh/16),"수력발전 " + LevelText(PlayerState.waterLevel, 1));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh/16, sw/16, sh/16),"투자")){
				actionButton = true;
				selectNumber = 1;
				actionText = "수력발전에 투자하시겠습니까?";
			}
			GUI.Label(new Rect(10, sh*2/16, sw/5, sh/16),"화력발전 " + LevelText(PlayerState.fireLevel, 2));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*2/16, sw/16, sh/16),"투자")){
				actionButton = true;
				selectNumber = 2;
				actionText = "화력발전에 투자하시겠습니까?";
			}
			GUI.Label(new Rect(10, sh*3/16, sw/5, sh/16),"원자력발전 " + LevelText(PlayerState.nuclearLevel, 3));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*3/16, sw/16, sh/16),"투자")){
				actionButton = true;
				selectNumber = 3;
				actionText = "원자력발전에 투자하시겠습니까?";
			}
			GUI.Label(new Rect(10, sh*4/16, sw/5, sh/16),"태양광발전 " + LevelText(PlayerState.sunLevel, 4));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*4/16, sw/16, sh/16),"투자")){
				actionButton = true;
				selectNumber = 4;
				actionText = "태양광발전에 투자하시겠습니까?";
			}
			GUI.Label(new Rect(10, sh*5/16, sw/5, sh/16),"풍력발전 " + LevelText(PlayerState.windLevel, 5));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*5/16, sw/16, sh/16),"투자")){
				actionButton = true;
				selectNumber = 5;
				actionText = "풍력발전에 투자하시겠습니까?";
			}
			GUI.Label(new Rect(10, sh*6/16, sw/5, sh/16),"중력발전 " + LevelText(PlayerState.gravityLevel, 6));
			if(GUI.Button(new Rect(sw/2 -sw/5, sh*6/16, sw/16, sh/16),"투자")){
				actionButton = true;
				selectNumber = 6;
				actionText = "중력발전에 투자하시겠습니까?";
			}
			GUI.EndScrollView ();
			}

		if (actionButton) {
			GUI.Box (new Rect (sw/2 - sw/10, sh/2 - sh/12, sw*2 / 9, sh/6), ""+actionText);
			if(GUI.Button(new Rect(sw/2 - sw/15, sh/2, sw / 15, sh/18), "확인")){
				SelectMethod(selectNumber);
				initialize();

			}
			if(GUI.Button(new Rect(sw/2 +10, sh/2, sw / 15, sh/18), "취소")){
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
