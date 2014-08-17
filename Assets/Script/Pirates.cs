using UnityEngine;
using System.Collections;

public class Pirates : MonoBehaviour
{

	public struct TargetInt{
		public int money;
		public int nationNumber;
	}

	TargetInt[] invasionProbability = new TargetInt[NationScript.RNation.Length];
		TargetInt[] MoneyList = new TargetInt[NationScript.RNation.Length];
		float _timerForText;
		int invastionTime = 30; // 침략시기

		void Start ()
		{
			NewsScript.myQue.Enqueue (invastionTime+"초에 해적이 침략합니다.");
		}

		void initialize ()
		{
				invastionTime = 40;
		}

		// Update is called once per frame
		void Update ()
		{
				_timerForText += Time.deltaTime;
				if (_timerForText > 1.0f) {
						_timerForText = 0;
						for (int i=0; i<MoneyList.Length; i++) {
								MoneyList [i].money = NationScript.RNation [i].Money;
				MoneyList[i].nationNumber = i;
						}
						MoneyRanking ();
						invastionTime--;
			if(invastionTime==0){
				DoInvasion(Target());
				initialize();
			}
				}
		}

		void MoneyRanking ()
		{
				TargetInt stemp;
				for (int p=0; p<MoneyList.Length; p++) {
						for (int i=0; i<MoneyList.Length-1; i++) {
								if (MoneyList [i].money < MoneyList [i + 1].money) {
										stemp = MoneyList [i];
										MoneyList [i] = MoneyList [i + 1];
										MoneyList [i + 1] = stemp;
								}
						}
				}
		}

		int Target ()
		{
				for (int i=0; i<invasionProbability.Length; i++) {
						invasionProbability [i] = MoneyList [i];
				}
				return invasionProbability [Random.Range (0, 3)].nationNumber;
		}

		void DoInvasion (int target)
		{
		string abc;
		int harmMoney;

		abc = "해적이 " +NationScript.RNation[target].Name+"를 침략합니다";
		NewsScript.myQue.Enqueue (abc);

		abc = NationScript.RNation[target].Name+"는 "+NationScript.RNation[target].Money/10 + "를 약탈당했습니다";
		NationScript.RNation [target].Money -= NationScript.RNation [target].Money / 10;
		NewsScript.myQue.Enqueue (abc);

		harmMoney = NationScript.RNation [target].PlantNumber.water * 100 + NationScript.RNation [target].PlantNumber.fire * 100 + NationScript.RNation [target].PlantNumber.nuclear * 100 + NationScript.RNation [target].PlantNumber.sun * 100 + NationScript.RNation [target].PlantNumber.wind * 100 + NationScript.RNation [target].PlantNumber.gravity * 100;
		PlayerState.Money -= harmMoney;
		abc = "당신은 "+harmMoney + "만큼의 금전적 피해를 입었습니다";
		NewsScript.myQue.Enqueue (abc);
	}
}
