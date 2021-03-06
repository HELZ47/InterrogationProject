﻿using UnityEngine;
using System.Collections;

public class DataFieldManager : MonoBehaviour {
	
	public string[] placeStrings;
	public string[] timeStrings;
	public string[] peopleStrings;
	public string[] meansStrings;

	public GameObject[] placeObjects;
	public GameObject[] timeObjects;
	public GameObject[] peopleObjects;
	public GameObject[] meansObjects;

	public int[] rightAnswers;
	
	// Use this for initialization
	void Start () {
		placeStrings = new string[4] {"Federal reserve", "Stock exchange", "Department of\nEqual Opportunity", "Liberty Bank HQ"};
		timeStrings = new string[4] {"Monday\n1:00 PM", "Wednesday\n6:00 PM", "Thursday\n10:00 AM", "Friday\n2:00 PM"};
		peopleStrings = new string[4] {"Mr. Wolfe\nJournalist", "Sarah Jackson\nFinancier", "Mei Yamato\nGovernment agent", "Mist\nProgrammer"};
		meansStrings = new string[4] {"Cutting off\ncommunications", "Planting false\ninformation", "Shutting off\nthe power", "Bomb threat"};
		
		rightAnswers = new int[4] {1, 1, 2, 1};
		
		/**
		float xPos = 0.6f;
		float xOffset = 0.1f;
		float yPos = 0.35f;
		float yOffset = 0.1f;
		float zPos = 1.0f;		//In case we want to do z-ordering
		*/
		
		float rectRightInset = 250f;
		float rectY = 150f;
		float rectWidth = 140f;
		float rectHeight = 100f;
		float rectXOffset = 10f;
		float rectYOffset = 20f;
		
		for (int i = 0; i < 4; i++) {
			placeObjects[i].GetComponent<DataField>().type = DataField.DataFieldType.PlaceField;
			placeObjects[i].GetComponent<DataField>().text.text = placeStrings[i];
			placeObjects[i].GetComponent<DataField>().buttonRect = new Rect (
				Screen.width - rectRightInset - (rectWidth+rectXOffset)*i, rectY + (rectHeight+rectYOffset)*0, rectWidth, rectHeight);
//			placeObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos, zPos);
			placeObjects[i].GetComponent<DataField>().text.enabled = false;
			
			timeObjects[i].GetComponent<DataField>().type = DataField.DataFieldType.TimeField;
			timeObjects[i].GetComponent<DataField>().text.text = timeStrings[i];
			timeObjects[i].GetComponent<DataField>().buttonRect = new Rect (
				Screen.width - rectRightInset - (rectWidth+rectXOffset)*i, rectY + (rectHeight+rectYOffset)*1, rectWidth, rectHeight);
//			timeObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos + yOffset*1, zPos);
			timeObjects[i].GetComponent<DataField>().text.enabled = false;
			
			peopleObjects[i].GetComponent<DataField>().type = DataField.DataFieldType.PersonField;
			peopleObjects[i].GetComponent<DataField>().text.text = peopleStrings[i];
			peopleObjects[i].GetComponent<DataField>().buttonRect = new Rect (
				Screen.width - rectRightInset - (rectWidth+rectXOffset)*i, rectY + (rectHeight+rectYOffset)*2, rectWidth, rectHeight);
//			peopleObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos + yOffset*2, zPos);
			peopleObjects[i].GetComponent<DataField>().text.enabled = false;
			
			meansObjects[i].GetComponent<DataField>().type = DataField.DataFieldType.MeansField;
			meansObjects[i].GetComponent<DataField>().text.text = meansStrings[i];
			meansObjects[i].GetComponent<DataField>().buttonRect = new Rect (
				Screen.width - rectRightInset - (rectWidth+rectXOffset)*i, rectY + (rectHeight+rectYOffset)*3, rectWidth, rectHeight);
			//			meansObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos + yOffset*3, zPos);
			meansObjects[i].GetComponent<DataField>().text.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState == GameManager.GameState.MainMenu || GameManager.instance.gameState == GameManager.GameState.LieDetector) {
			for (int i = 0; i < 4; i++) {
				placeObjects[i].GetComponent<DataField>().text.enabled = true;
				timeObjects[i].GetComponent<DataField>().text.enabled = true;
				peopleObjects[i].GetComponent<DataField>().text.enabled = true;
				meansObjects[i].GetComponent<DataField>().text.enabled = true;
			}
		}	
	}
	
	public void Select (GameObject o, DataField.DataFieldType type) {
		switch (type) {
		case (DataField.DataFieldType.PlaceField):
			foreach (GameObject obj in placeObjects) {
				if (obj != o) obj.GetComponent<DataField>().selected = false;
				else obj.GetComponent<DataField>().selected = !obj.GetComponent<DataField>().selected;
			}
			break;
		case (DataField.DataFieldType.TimeField):
			foreach (GameObject obj in timeObjects) {
				if (obj != o) obj.GetComponent<DataField>().selected = false;
				else obj.GetComponent<DataField>().selected = !obj.GetComponent<DataField>().selected;
			}
			break;
		case (DataField.DataFieldType.PersonField):
			foreach (GameObject obj in peopleObjects) {
				if (obj != o) obj.GetComponent<DataField>().selected = false;
				else obj.GetComponent<DataField>().selected = !obj.GetComponent<DataField>().selected;
			}
			break;
		case (DataField.DataFieldType.MeansField):
			foreach (GameObject obj in meansObjects) {
				if (obj != o) obj.GetComponent<DataField>().selected = false;
				else obj.GetComponent<DataField>().selected = !obj.GetComponent<DataField>().selected;
			}
			break;
		}
	}	
	
	public bool ReportCorrect () {
		return  placeObjects[rightAnswers[0]].GetComponent<DataField>().selected &&
				timeObjects[rightAnswers[1]].GetComponent<DataField>().selected && 
				peopleObjects[rightAnswers[2]].GetComponent<DataField>().selected && 
				meansObjects[rightAnswers[3]].GetComponent<DataField>().selected; 
	}
}
