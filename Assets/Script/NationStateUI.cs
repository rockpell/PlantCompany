using UnityEngine;
using System.Collections;

public class NationStateUI : MonoBehaviour {

	GUIText NationState;
	string Ntext;

	// Use this for initialization
	void Start () {
		NationState = gameObject.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		if(BottomUI.nationSelect>0){
		switch(BottomUI.nationSelect){
		case 1: 
			Ntext = "첫";
				break;
		case 2:
			Ntext = "두";
				break;
		case 3:
			Ntext = "세";
				break;
		case 4:
			Ntext = "네";
				break;
		case 5:
			Ntext = "다섯";
				break;
		}

		NationState.text = string.Format("{0}", Ntext)+" 번째 나라";
		}
	}
}
