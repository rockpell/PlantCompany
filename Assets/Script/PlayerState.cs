using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public static int Money = 500; // 플레이어 자금
	public static int time_Money=1; //시간당 자금

	public static int waterpowerMoney=20; //수력발전소 시간당 들어오는 자금
	public static int thermalpowerMoney=30; //화력발전소 시간당 들어오는 자금
	public static int nuclearpowerMoney=50; //원자력발전소 시간당 들어오는 자금
	public static int solarpowerMoney=5; //태양광발전소 시간당 들어오는 자금
	public static int windpowerMoney=30; //풍력발전소 시간당 들어오는 자금
	public static int gravitypowerMoney=40; //중력발전소 시간당 들어오 자금

	public static int waterLevel=0; // 발전기술레벨
	public static int fireLevel=0;
	public static int sunLevel=0;
	public static int nuclearLevel=0;
	public static int windLevel=0;
	public static int gravityLevel=0;

	public static int waterNumber=0;
	public static int fireNumber=0;
	public static int nuclearNumber=0;
	public static int sunNumber=0;
	public static int windNumber=0;
	public static int gravityNumber=0;

	public static int waterCost = 200; // 발전소 건설 비용
	public static int fireCost = 100;
	public static int nuclearCost = 500;
	public static int sunCost = 100;
	public static int windCost = 300;
	public static int gravityCost = 400;

	public struct Characteristic{
		public int constructExpenses;
		public int output;
		public int environment;
	}

	float _timerForText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_timerForText += Time.deltaTime;
		if (_timerForText > 1.0f)
		{
			_timerForText = 0;
			Money += time_Money;
			playerProfit();
		}
	}

	public void playerProfit(){
		time_Money = 1 + waterpowerMoney*waterLevel*waterNumber + thermalpowerMoney*fireLevel*fireNumber + solarpowerMoney*sunLevel*sunNumber + nuclearpowerMoney*nuclearLevel*nuclearNumber + windpowerMoney*windLevel*windNumber + gravitypowerMoney*gravityLevel*gravityNumber;
	}

	public static void PlantChar(int plant, int chart){
		Characteristic [] PlantCharter = new Characteristic[6];

		switch(plant){
		case 1: // 수력
			if(chart==1){
				PlantCharter[plant-1].constructExpenses++;
				waterCost -= waterCost/10;
			}
			else if(chart==2){
				PlantCharter[plant-1].output++;
				waterpowerMoney += waterpowerMoney/10;
			}
			else if(chart==3){
				PlantCharter[plant-1].environment++;
			}
			break;
		case 2: // 화력
			if(chart==1){
				PlantCharter[plant-1].constructExpenses++;
				fireCost -= fireCost/10;
			}
			else if(chart==2){
				PlantCharter[plant-1].output++;
				thermalpowerMoney += thermalpowerMoney/10;
			}
			else if(chart==3){
				PlantCharter[plant-1].environment++;
			}
			break;
		case 3: // 원자력
			if(chart==1){
				PlantCharter[plant-1].constructExpenses++;
				nuclearCost -= nuclearCost/10;
			}
			else if(chart==2){
				PlantCharter[plant-1].output++;
				nuclearpowerMoney += nuclearpowerMoney/10;
			}
			else if(chart==3){
				PlantCharter[plant-1].environment++;
			}
			break;
		case 4: // 태양광
			if(chart==1){
				PlantCharter[plant-1].constructExpenses++;
				sunCost -=sunCost/10;
			}
			else if(chart==2){
				PlantCharter[plant-1].output++;
				solarpowerMoney += solarpowerMoney/10;
			}
			else if(chart==3){
				PlantCharter[plant-1].environment++;
			}
			break;
		case 5: // 풍력
			if(chart==1){
				PlantCharter[plant-1].constructExpenses++;
				windCost -= windCost/10;
			}
			else if(chart==2){
				PlantCharter[plant-1].output++;
				windpowerMoney += windpowerMoney/10;
			}
			else if(chart==3){
				PlantCharter[plant-1].environment++;
			}
			break;
		case 6: // 중력
			if(chart==1){
				PlantCharter[plant-1].constructExpenses++;
				gravityCost -= gravityCost/10;
			}
			else if(chart==2){
				PlantCharter[plant-1].output++;
				gravitypowerMoney += gravitypowerMoney/10;
			}
			else if(chart==3){
				PlantCharter[plant-1].environment++;
			}
			break;
		}
	}
}
