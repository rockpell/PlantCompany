using UnityEngine;
using System.Collections;

public class AreaGeneration : MonoBehaviour {

	MapGeneration mg = new MapGeneration();

	public Transform Capital1;
	public Transform Capital2;
	public Transform Capital3;
	public Transform Capital4;
	public Transform Capital5;
	public Transform Nation1;
	public Transform Nation2;
	public Transform Nation3;
	public Transform Nation4;
	public Transform Nation5;
	public Transform Nation6;


	int [,] mapArr = new int[26, 26];
	ArrayList cpx = new ArrayList();
	ArrayList cpy = new ArrayList();
	
	void Start () {
		mapArr = mg.NationalArea();
		rand ();
		capitalGeneration ();
		areacul ();
	}

	void Update () {
	
	}

	void rand(/*int cpsel*/){ // 나중에 설정을 통해 나라 갯수 정하면 그 변수 cpsel로 가칭한거임
		int nations = 0;
		int x=0, y=0;
		int gap1 = 0, gap2 = 0;
		cpx.Clear ();
		cpy.Clear ();

		while(nations<5/*cpsel*/){
			x = Random.Range (0,26);
			y = Random.Range(0,26);
		    if(mapArr[x,y] == 1 || mapArr[x,y] == 2){

				cpx.Add (y);
				cpy.Add (x);

				for(int i=0; i<nations; i++){
					gap1 = (int) cpx[i] + (int) cpy[i];
					gap2 = x + y;
					if(gap2-gap1<7 && gap2-gap1>-7){
						cpy.RemoveAt (nations);
						cpx.RemoveAt (nations);
						nations--;
					}

				}

				nations++;
			}
		}
	}

	void capitalGeneration(){

		int nations;
		int count = 1;

		int [] cx = new int[cpx.Count];
		int [] cy = new int[cpy.Count];

		for (nations=0; nations<(int) cpx.Count; nations++) {

			cx [nations] = (int) cpx [nations];
			cy [nations] = (int) cpy [nations];

		}

		for (nations=0; nations<cpx.Count; nations++) {
			if(count==1) Instantiate (Capital1, new Vector3 (cx[nations]*1.73F, 0, cy[nations]*1.52F*-1), Quaternion.identity);
			if(count==2) Instantiate (Capital2, new Vector3 (cx[nations]*1.73F, 0, cy[nations]*1.52F*-1), Quaternion.identity);
			if(count==3) Instantiate (Capital3, new Vector3 (cx[nations]*1.73F, 0, cy[nations]*1.52F*-1), Quaternion.identity);
			if(count==4) Instantiate (Capital4, new Vector3 (cx[nations]*1.73F, 0, cy[nations]*1.52F*-1), Quaternion.identity);
			if(count==5) Instantiate (Capital5, new Vector3 (cx[nations]*1.73F, 0, cy[nations]*1.52F*-1), Quaternion.identity);

		}

	}

	void areacul() {

		int x = 0;
		int y = 0;
		int q = -1;
		bool visit = true; // 방문 표시(true = 처음 & false = 처음 아님)

		for (x=0; x<26; x++) { // 세로 축 탐색
			for(y=0;y<26;y++) { // 가로 축 탐색
				if(mapArr[x,y]==1 || mapArr[x,y]==2 || mapArr[x,y]==3) mapArr[x,y]=rangecul(x,y);
				/* mapArr 내부의 Value 해당 국가 소속값으로 바꿈. 
				 * Capital1 소속이면 1
				 * Capital2 소속이면 2... */
			}
		}

		for (x=1; x<25; x++) { 
			/* 국경지역 Value 변경
			 * Capital1 국경은 6
			 * Capital2 국경은 7... */

			for(y=1;y<25;y++) {

				//위로 찾기
				if(mapArr[x,y]!=0 && visit==true) {
					if(mapArr[x,y-1]!= mapArr[x,y] && mapArr[x,y-1]!=mapArr[x,y]+(int)cpx.Count) {
						mapArr[x,y]=mapArr[x,y]+(int)cpx.Count;
						visit = false;
					}
				}

				//아래로 찾기
				if(mapArr[x,y]!=0 && visit==true) {
					if(mapArr[x,y+1]!= mapArr[x,y] && mapArr[x,y+1]!=mapArr[x,y]+(int)cpx.Count) {
						mapArr[x,y]=mapArr[x,y]+(int)cpx.Count;
						visit = false;
					}
				}

				//왼쪽으로 찾기
				if(mapArr[x,y]!=0 && visit==true) {
					if(mapArr[x-1,y]!= mapArr[x,y] && mapArr[x-1,y]!=mapArr[x,y]+(int)cpx.Count) {
						mapArr[x,y]=mapArr[x,y]+(int)cpx.Count;
						visit = false;
					}
				}

				//오른쪽으로 찾기
				if(mapArr[x,y]!=0 && visit==true) {
					if(mapArr[x+1,y]!= mapArr[x,y] && mapArr[x+1,y]!=mapArr[x,y]+(int)cpx.Count) {
						mapArr[x,y]=mapArr[x,y]+(int)cpx.Count;
						visit = false;
					}
				}
				visit = true;
			}
		}

		for (x=0; x<26; x++) {
			for (y=0; y<26; y++) {
				if (mapArr [x, y] == (int)cpx.Count+1) Instantiate (Nation1, new Vector3 (y * 1.73F + q * 0.4325F, 0.1F , x * 1.52F * -1), Quaternion.identity);
				if (mapArr [x, y] == (int)cpx.Count+2) Instantiate (Nation2, new Vector3 (y * 1.73F + q * 0.4325F, 0.1F , x * 1.52F * -1), Quaternion.identity);
				if (mapArr [x, y] == (int)cpx.Count+3) Instantiate (Nation3, new Vector3 (y * 1.73F + q * 0.4325F, 0.1F , x * 1.52F * -1), Quaternion.identity);
				if (mapArr [x, y] == (int)cpx.Count+4) Instantiate (Nation4, new Vector3 (y * 1.73F + q * 0.4325F, 0.1F , x * 1.52F * -1), Quaternion.identity);
				if (mapArr [x, y] == (int)cpx.Count+5) Instantiate (Nation5, new Vector3 (y * 1.73F + q * 0.4325F, 0.1F , x * 1.52F * -1), Quaternion.identity);

			}
			q=q*-1;
		}
	}

	int rangecul(int x,int y) {
		int [] ran = new int[cpx.Count];
		int i=0;
		int p = 0;
		int count = 0;

		for (i=0; i<(int)cpx.Count; i++) ran [i] = (y - (int)cpx[i]) * (y - (int)cpx[i]) + (x - (int)cpy[i]) * (x - (int) cpy[i]);


		for (i=0; i<(int)cpx.Count; i++) {	
			for (p=0; p<(int)cpx.Count; p++) {
				if(ran[i]<=ran[p]) {
					if(cpx[i]!=cpx[p] && cpy[i]!=cpy[p]) count++;
				}
			}
			if(count==(int)cpx.Count-1) break;
			else count = 0;
		}
		return i + 1;
	}
}