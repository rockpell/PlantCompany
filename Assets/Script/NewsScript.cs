using UnityEngine;
using System.Collections;

public class NewsScript : MonoBehaviour {

	public GUIText TopNews;

	int sw = Screen.width;

	public float waitTime = 2.0f;

	bool queCheck = false;

	public static Queue myQue = new Queue();

	// Use this for initialization
	void Start () {
		//myQue.Enqueue("게임이 시작되었습니다.");
	}
	
	// Update is called once per frame
	void Update () {

		if (myQue.Count != 0 && !queCheck) {
			//Debug.Log("QueCheck");
			StartCoroutine("TextQue");
				queCheck = true;
			}
	}

	void TextMessage(string TM){
		TopNews.guiText.text = TM;
		Instantiate (TopNews, new Vector3 (0.37F, 0.95F, 2), Quaternion.identity);
	}

	IEnumerator TextQue(){
		//Debug.Log ("TextQue");
		TextMessage ((string)myQue.Dequeue ());
		yield return new WaitForSeconds(waitTime);
		if (myQue.Count == 0) {
						queCheck = false;
				} else if (myQue.Count != 0) {
					StartCoroutine("TextQue");
				}
	}
}
