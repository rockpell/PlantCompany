using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Transform MainCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(MainCamera.position.x<28){ // 카메라 오른쪽 이동
			if(Input.GetKey(KeyCode.RightArrow)){
				transform.Translate(0.3f,0,0,Space.World);
		}
			/*if(Input.GetAxis("Mouse X") < Screen.width*2/5){ 
				transform.Translate(0.3f, 0, 0 ,Space.World); 
			}*/
		}


		if(MainCamera.position.x>15){ // 카메라 왼쪽 이동
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(-0.3f,0,0,Space.World);
		}
		/*if(Input.GetMouseButton(0)){ 
			if(Input.GetAxis("Mouse X") > 0){ 
				transform.Translate(-0.3f, 0, 0 ,Space.World); 
			} 
		}*/
		}

		if(MainCamera.position.z<-12){ // 카메라 위로 이동
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(0,0,0.3f,Space.World);
		}
		/*if(Input.GetMouseButton(0)){ 
			if(Input.GetAxis("Mouse Y") < 0){ 
				transform.Translate(0, 0, 0.3f ,Space.World); 
			} 
		}*/
		}

		if(MainCamera.position.z>-38){ // 카메로 아래로 이동
		if(Input.GetKey(KeyCode.DownArrow)){
			transform.Translate(0,0,-0.3f,Space.World);
		}
		/*if(Input.GetMouseButton(0)){ 
			if(Input.GetAxis("Mouse Y") > 0){ 
				transform.Translate(0, 0, -0.3f ,Space.World); 
			} 
		}*/
		}
	
	if (MainCamera.position.y < 50) {
						if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
								transform.Translate (0, 0.5f, 0, Space.World); 
						}
				}

	if (MainCamera.position.y > 10) {
						if (Input.GetAxis ("Mouse ScrollWheel") > 0) { 
								transform.Translate (0, -0.5f, 0, Space.World); 
						}
				}

		}
}
