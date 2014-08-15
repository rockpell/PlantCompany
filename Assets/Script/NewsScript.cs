using UnityEngine;
using System.Collections;

public class NewsScript : MonoBehaviour {

	public GUIText TopNews;

	int sw = Screen.width;

	// Use this for initialization
	void Start () {
		TextMessage ("게임이 시작되었습니다.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TextMessage(string TM){
		TopNews.guiText.text = TM;
		Instantiate (TopNews, new Vector3 ((sw*4/10)*0.001F, 0.98F, 2), Quaternion.identity);
	}
}
