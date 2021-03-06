﻿using UnityEngine;
using System.Collections;

public class Question_Timer : MonoBehaviour {

	//Fields
	public GUIText bigTimer, smallTimer;
	public float timer, timeLimit;
	public bool timerCounting, timeUp;


	// Use this for initialization
	void Start () {
		timer = timeLimit;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerCounting) {
			timer -= Time.deltaTime;
		}
		bigTimer.text = smallTimer.text = ((int)(timer/60)).ToString() + ":" + (timer%60).ToString("F0");

		if (GameManager.instance.gameState == GameManager.GameState.MainMenu) {
			smallTimer.enabled = timerCounting;
			bigTimer.enabled = (GameManager.instance.prisonerInfoPanel == GameObject.Find ("img_StartQuestion_Instructions").GetComponent<InterfaceManager>());
		}
		else {
			smallTimer.enabled = bigTimer.enabled = false;
		}

		if (timer < 0) {
			timeUp = true;
		}
		else {
			timeUp = false;
		}
	}

	public void StartTimer () {
		//bigTimer.enabled = smallTimer.enabled = true;
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
