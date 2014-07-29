using UnityEngine;
using System.Collections;

public class NewsScript : MonoBehaviour {

	public GUIText TopNews;

	// Use this for initialization
	void Start () {
		TextMessage ("게임이 시작되었습니다.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TextMessage(string TM){
		TopNews.guiText.text = TM;
		Instantiate (TopNews, new Vector3 (0.43F, 0.98F, 1), Quaternion.identity);
	}
}
