using UnityEngine;
using System.Collections;

public class SettingUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		GameObject.Find ("NewsMaster").SendMessage ("TextMessage","설정창");
	}
}
