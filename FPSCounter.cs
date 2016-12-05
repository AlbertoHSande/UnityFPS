using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {

	private int fps;
	const float interval = 1f;
	private int accWaiting = 0;
	public float next = 0;

	void Start(){
		next = Time.realtimeSinceStartup + interval;
	}

	void Update(){
		accWaiting++;
		//Debug.Log (accWaiting);
		if (Time.realtimeSinceStartup > next) {
			fps = accWaiting;
			accWaiting = 0;
			next += interval;
		}
	}

	void OnGUI(){
		GUIStyle gs = new GUIStyle (GUI.skin.label);
		if (fps < 30) {
			gs.normal.textColor = Color.red;
		} else if (fps >= 30 & fps <= 50) {
			gs.normal.textColor = Color.yellow;
		} else
			gs.normal.textColor = Color.green;
		
		GUI.Label (new Rect (0, 0, 50, 50), fps.ToString (), gs);
	}

}
