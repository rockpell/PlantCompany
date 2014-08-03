using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public static int Money = 1000; // 플레이어 자금

	float _timerForText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_timerForText += Time.deltaTime;
		if (_timerForText > 1.0f)
		{
			_timerForText = 0;
			Money += 1;
		}
	}
}
