﻿using UnityEngine;
using System.Collections;

public class NationScript : MonoBehaviour {

	public struct numberPlant{ // 국가의 발전소 소유 개수
		public int fire;
		public int water;
		public int sun;
		public int wind;
		public int nuclear;
		public int gravity;
	}

	public struct allNation{ // 국가의 정보
		public string Name;  // 국가명
		public int Money; // 국가 돈
		public int Tendancy; // 국가성향
		public numberPlant PlayerPlant; // 국가 소유 발전기술
		public numberPlant PlantNumber; // 국가 소유 발전소 개수
		public int DataLevel; // 정보수집 단계
	}

	public static int time_nationProfit=1;
	public static allNation [] RNation = new allNation[5];
	public static int [] nationProfit = new int[RNation.Length];



	float _timerForText;

	void Start () {
		for(int i=0; i<RNation.Length; i++){ // 국가별 수익 초기화
			nationProfit[i] = time_nationProfit;
			RNation[i].Money = 1000; // 초기자금 초기화
		}
		RNation[0].Name = "First";
		RNation[1].Name = "Second";
		RNation[2].Name = "Third";
		RNation[3].Name = "Fourth";
		RNation[4].Name = "Fifth";

	}

	void Update () {
		_timerForText += Time.deltaTime;
		if (_timerForText > 1.0f)
		{
			_timerForText = 0;
			for(int i=0; i<RNation.Length; i++){
				nationProfit[i]=1 + RNation[i].PlantNumber.water*100 + RNation[i].PlantNumber.fire*100 + RNation[i].PlantNumber.nuclear*100 + RNation[i].PlantNumber.sun*100 + RNation[i].PlantNumber.wind*100 + RNation[i].PlantNumber.gravity*100;
				RNation[i].Money += nationProfit[i];
			}
		}
	}
}
