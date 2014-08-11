using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public static int Money = 1000; // 플레이어 자금
	public static int time_Money=1; //시간당 자금

	public static int waterpowerMoney=200; //수력발전소 시간당 들어오는 자금
	public static int thermalpowerMoney=300; //화력발전소 시간당 들어오는 자금
	public static int nuclearpowerMoney=400; //원자력발전소 시간당 들어오는 자금
	public static int solarpowerMoney=500; //태양광발전소 시간당 들어오는 자금
	public static int windpowerMoney=600; //풍력발전소 시간당 들어오는 자금
	public static int gravitypowerMoney=700; //중력발전소 시간당 들어오 자금

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
}
