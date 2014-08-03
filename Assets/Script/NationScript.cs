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

	public static allNation [] RNation = new allNation[5];

	void Start () {
	
	}

	void Update () {
	
	}
}
