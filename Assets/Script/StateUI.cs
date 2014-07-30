﻿using UnityEngine;
using System.Collections;

public class StateUI : MonoBehaviour {

	GUIText State;

	int Money = 0;

	// Use this for initialization
	void Start () {
		State = gameObject.GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		State.text = "현재 자금 보유량 : " + string.Format("{0:D2}",Money);
		Money += 1;
	}
}
