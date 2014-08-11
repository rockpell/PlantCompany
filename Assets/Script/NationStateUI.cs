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
				Ntext = NationScript.RNation[0].Name;
				break;
		case 2:
				Ntext = NationScript.RNation[1].Name;
				break;
		case 3:
				Ntext = NationScript.RNation[2].Name;
				break;
		case 4:
				Ntext = NationScript.RNation[3].Name;
				break;
		case 5:
				Ntext = NationScript.RNation[4].Name;
				break;
		}

		NationState.text = string.Format("{0}", Ntext);
		}
	}
}
