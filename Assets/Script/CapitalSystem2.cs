using UnityEngine;
using System.Collections;

public class CapitalSystem2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		BottomUI.nationSelect = 2;
		BottomUI.constructCheck = false;
	}
}
