using UnityEngine;
using System.Collections;

public class AreaGeneration : MonoBehaviour {

	MapGeneration mg = new MapGeneration();
	public Transform Capital1;
	public Transform Capital2;
	public Transform Capital3;
	public Transform Capital4;
	public Transform Capital5;

	int [,] mapArr = new int[26, 26];

	public struct Capital{
		public int cx;
		public int cy;
	}

	Capital [] cp = new Capital[5];
	
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
		while(nations<5){
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

		Instantiate (Capital1, new Vector3 (cp[0].cx* 1.73F, 0, cp[0].cy*1.52F*-1), Quaternion.identity);
		Instantiate (Capital2, new Vector3 (cp[1].cx* 1.73F, 0, cp[1].cy*1.52F*-1), Quaternion.identity);
		Instantiate (Capital3, new Vector3 (cp[2].cx* 1.73F, 0, cp[2].cy*1.52F*-1), Quaternion.identity);
		Instantiate (Capital4, new Vector3 (cp[3].cx* 1.73F, 0, cp[3].cy*1.52F*-1), Quaternion.identity);
		Instantiate (Capital5, new Vector3 (cp[4].cx* 1.73F, 0, cp[4].cy*1.52F*-1), Quaternion.identity);
	}
}