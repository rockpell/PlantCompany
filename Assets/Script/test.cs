using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
	public Transform MainCamera;
	float preX,preY;
	float preDistance1, nowDistance1;
	float preDistance, nowDistance;

	int cnt = Input.touchCount; // 현재 터치되어 있는 카운트 가져오기

		void Update ()
		{
				
				
				if (Time.timeScale != 0) {
						//Debug.Log ("touch Cnt : " + cnt);

						// 동시에 여러곳을 터치 할 수 있기 때문.
						
						for (int i=0; i<cnt; ++i) {
							
								// i 번째로 터치된 값 이라고 보면 된다.
								
								Touch touch = Input.GetTouch (i);
								Vector2 pos = touch.position;
									
								if (touch.phase == TouchPhase.Began) {
										
										//Debug.Log ("시작점 : (" + i + ") : x = " + pos.x + ", y = " + pos.y);
										
								} else if (touch.phase == TouchPhase.Ended) {
									
										//Debug.Log ("끝점 : (" + i + ") : x = " + pos.x + ", y = " + pos.y);
									
								} else if (touch.phase == TouchPhase.Moved) {
									
										//Debug.Log ("이동중 : (" + i + ") : x = " + pos.x + ", y = " + pos.y);
								}
						}
						if (cnt == 1) {
								if (MainCamera.position.x > 15 && Input.GetTouch (0).position.x - preX > 0) {// 왼쪽
										transform.Translate (-0.5f, 0, 0, Space.World); 
								}
								if (MainCamera.position.x < 70 && Input.GetTouch (0).position.x - preX < 0) {// 오른쪽
										transform.Translate (0.5f, 0, 0, Space.World); 
								}
								if (MainCamera.position.z > -70 && Input.GetTouch (0).position.y - preY > 0) { // 아래쪽
										transform.Translate (0, 0, -0.5f, Space.World);
								}
								if (MainCamera.position.z < -13 && Input.GetTouch (0).position.y - preY < 0) { // 위쪽
										transform.Translate (0, 0, 0.5f, Space.World);
								}
								preX = Input.GetTouch (0).position.x;
								preY = Input.GetTouch (0).position.y;
						}

						if (cnt == 2) {

								nowDistance = Vector2.Distance (Input.GetTouch (0).position, Input.GetTouch (1).position);
								if (nowDistance - preDistance > 0) { // 확대
										transform.Translate (0, -0.5f, 0, Space.World);
								}
								if (nowDistance - preDistance < 0) { // 축소
										transform.Translate (0, 0.5f, 0, Space.World); 
								}
								preDistance = Vector2.Distance (Input.GetTouch (0).position, Input.GetTouch (1).position);
						}
				}
		}
			
}
