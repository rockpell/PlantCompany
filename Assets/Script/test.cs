using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
		public Transform MainCamera;
		float preX = 0, preY = 0;
				
		void Update ()
		{
				
				// 현재 터치되어 있는 카운트 가져오기
					
				int cnt = Input.touchCount;

				//Debug.Log ("touch Cnt : " + cnt);

				// 동시에 여러곳을 터치 할 수 있기 때문.
						
				for (int i=0; i<cnt; ++i) {
							
						// i 번째로 터치된 값 이라고 보면 된다.
								
						Touch touch = Input.GetTouch (i);
						Vector2 pos = touch.position;
									
						if (touch.phase == TouchPhase.Began) {
										
								Debug.Log ("시작점 : (" + i + ") : x = " + pos.x + ", y = " + pos.y);
										
						} else if (touch.phase == TouchPhase.Ended) {
									
								Debug.Log ("끝점 : (" + i + ") : x = " + pos.x + ", y = " + pos.y);
									
						} else if (touch.phase == TouchPhase.Moved) {
									
								Debug.Log ("이동중 : (" + i + ") : x = " + pos.x + ", y = " + pos.y);
								
								
				if(MainCamera.position.x>15 && pos.x-preX>0){
					transform.Translate(-0.5f,0,0,Space.World); // 왼쪽
				}
				if(MainCamera.position.x<70 && pos.x-preX<0){
					transform.Translate(0.5f,0,0,Space.World); // 오른쪽
				}
				if(MainCamera.position.z>-70 && pos.y-preY>0){ // 아래쪽
					transform.Translate(0,0,-0.5f,Space.World);
				}
				if(MainCamera.position.z<-13 && pos.y-preY<0){ // 위쪽
					transform.Translate(0,0,0.5f,Space.World);
				}
								preX = pos.x;
								preY = pos.y;
						}
							
				}
				
		}
			
}
