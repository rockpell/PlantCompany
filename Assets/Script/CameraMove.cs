using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(-0.3f,0,0);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(0.3f,0,0);
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(0,0.3f,0);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			transform.Translate(0,-0.3f,0.0000000000000000000000000001f);
		}
	}
}
