using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public static int Money = 1000; // 플레이어 자금
	public static int time_Money=1; //시간당 자금
	public static int waterpowerMoney=2; //수력발전소 시간당 들어오는 자금
	public static int thermalpowerMoney=3; //화력발전소 시간당 들어오는 자금
	public static int solarpowerMoney=4; //태양광발전소 시간당 들어오는 자금
	public static int nuclearpowerMoney=5; //원자력발전소 시간당 들어오는 자금
	public static int windpowerMoney=6; //풍력발전소 시간당 들어오는 자금
	public static int gravitypowerMoney=7; //중력발전소 시간당 들어오 자금

	public static int waterLevel=0; // 발전기술레벨
	public static int fireLevel=0;
	public static int sunLevel=0;
	public static int nuclearLevel=0;
	public static int windLevel=0;
	public static int gravityLevel=0;


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
}
