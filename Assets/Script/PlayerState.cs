using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public static int Money = 1000; // 플레이어 자금
	public static int time_Money=1; //시간당 자금

	public static int waterpowerMoney=200; //수력발전소 시간당 들어오는 자금
	public static int thermalpowerMoney=300; //화력발전소 시간당 들어오는 자금
	public static int solarpowerMoney=400; //태양광발전소 시간당 들어오는 자금
	public static int nuclearpowerMoney=500; //원자력발전소 시간당 들어오는 자금
	public static int windpowerMoney=600; //풍력발전소 시간당 들어오는 자금
	public static int gravitypowerMoney=700; //중력발전소 시간당 들어오 자금

	public static int waterLevel=0; // 발전기술레벨
	public static int fireLevel=0;
	public static int sunLevel=0;
	public static int nuclearLevel=0;
	public static int windLevel=0;
	public static int gravityLevel=0;

	public static int water_factory=0; //발전소 개수
	public static int fire_factory=0;
	public static int sun_factory=0;
	public static int nuclear_factory=0;
	public static int wind_factory=0;
	public static int gravity_factory=0;



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
		}
	}

	public void playerProfit(){
		time_Money =1+waterpowerMoney*waterLevel + thermalpowerMoney*fireLevel + solarpowerMoney*sunLevel + nuclearpowerMoney*nuclearLevel + windpowerMoney*windLevel + gravitypowerMoney*gravityLevel;
	}
}
