using UnityEngine;
using System.Collections;

public class NationScript : MonoBehaviour {

	public struct kindPlant{ // 발전소 정보
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
		public kindPlant PlantData; // 국가 소유 발전소
		public int DataLevel; // 정보수집 단계
	}

	public static int time_nationProfit=1;
	public static allNation [] RNation = new allNation[4];
	public static int [] nationProfit = new int[RNation.Length];



	float _timerForText;

	void Start () {
		for(int i=0; i<RNation.Length; i++){ // 국가별 수익 초기화
			nationProfit[i] = time_nationProfit;
		}
		RNation [0].Name = "First";
	}

	void Update () {
		_timerForText += Time.deltaTime;
		if (_timerForText > 1.0f)
		{
			_timerForText = 0;
			for(int i=0; i<RNation.Length; i++){
				RNation[i].Money += nationProfit[i];
			}
		}
	}

}
