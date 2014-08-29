using UnityEngine;
using System.Collections;

public class NewsGUI : MonoBehaviour {
	
	public float timeDelay = 2.0f;

	bool timeCheck = false;
	bool timePass = false;

	float a = 0;

	// Use this for initialization
	void Start () {
		transform.guiText.material.color = new Vector4(1, 1, 1, 0);
		StartCoroutine("DisplayScore"); 
	}
	
	// Update is called once per frame
	void Update () {
		if(!timeCheck)StartCoroutine ("UpMehod");
	}
	IEnumerator DisplayScore()
	{
		yield return new WaitForSeconds(timeDelay);
		
		for(float a = 1; a >= 0; a -= 0.05f)
		{
			transform.guiText.material.color = new Vector4(1, 1, 1, a);
			yield return new WaitForFixedUpdate();
		}
		
		Destroy(gameObject);
	}

	IEnumerator UpMehod(){
		Vector3 pos = transform.position;
		pos.y += 0.0005f;
		transform.position = pos;
		if (a <= 1 && !timePass) {
			a+= 0.015f;
		}
		transform.guiText.material.color = new Vector4(1, 1, 1, a);
		/*for(float a = 0; a <=1; a += 0.1f)
		{

			yield return new WaitForFixedUpdate();
		}*/

		if (pos.y >= 0.98F && !timePass) {
			//Debug.Log("Time Stop");
			timeCheck = true;
			yield return new WaitForSeconds (0.5f);
			timePass = true;
			timeCheck = false;
		}
	}
}
