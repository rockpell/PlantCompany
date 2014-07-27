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
		//gameObject.SendMessage ("TextMessage", "첫번째 나라를 클릭하였습니다");	
		GameObject.Find ("NewsMaster").SendMessage ("TextMessage", "첫번째 나라를 클릭하였습니다");
	}
}
