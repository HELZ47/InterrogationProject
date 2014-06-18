using UnityEngine;
using System.Collections;

public class Question_Timer : MonoBehaviour {

	//Fields
	public GUIText bigTimer, smallTimer;
	public float timer, timeLimit;
	public bool timerCounting;


	// Use this for initialization
	void Start () {
		timer = timeLimit;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerCounting) {
			print ("Timer working!");
			timer -= Time.deltaTime;
		}
		bigTimer.text = smallTimer.text = timer.ToString("F2");
	}

	public void StartTimer () {
		timerCounting = true;
	}

	public void ResetTimer () {
		timer = timeLimit;
		timerCounting = false;
	}

	public void StopTimer () {
		timerCounting = false;
	}
}
