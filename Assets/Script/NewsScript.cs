using UnityEngine;
using System.Collections;

public class NewsScript : MonoBehaviour {

	public GUIText TopNews;

	// Use this for initialization
	void Start () {
		TopNews.guiText.text ="a";
		Instantiate (TopNews, new Vector3 (0.4F, 0.98F, 1), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
