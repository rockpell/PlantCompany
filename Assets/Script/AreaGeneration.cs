using UnityEngine;
using System.Collections;

public class AreaGeneration : MonoBehaviour {

	MapGeneration mg = new MapGeneration();
	public Transform Capital1;
	int [,] mapArr = new int[26, 26];

	public struct Capital{
		public int cx;
		public int cy;
	}

	Capital [] cp = new Capital[10];
	
	void Start () {
		mapArr = mg.NationalArea();
		rand ();
		capitalGeneration ();
	}

	void Update () {
	
	}

	void rand(){


		int nations = 0;
		int x=0, y=0;
		int gap1 = 0, gap2 = 0;
		while(nations<10){
			x = Random.Range (0,26);
			y = Random.Range(0,26);
		    if(mapArr[x,y] == 1 || mapArr[x,y] == 2){
				cp[nations].cx = y;
				cp[nations].cy = x;

				for(int i=0; i<nations; i++){
					gap1 = cp[i].cx + cp[i].cy;
					gap2 = x + y;
					if(gap2-gap1<7 && gap2-gap1>-7){
						nations--;
					}
				}

				nations++;
			}
		}
	}

	void capitalGeneration(){
		for (int i=0; i<10; i++) {
			Instantiate (Capital1, new Vector3 (cp[i].cx* 1.73F, 0, cp[i].cy*1.52F*-1), Quaternion.identity);
		}
	}
}