using UnityEngine;
using System.Collections;

public class CapitlaSystem1 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		BottomUI.nationSelect = 1;
		BottomUI.constructCheck = false;
	}
}
