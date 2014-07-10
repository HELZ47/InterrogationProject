using UnityEngine;
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
		placeStrings = new string[5] {"Federal reserve", "Stock exchange", "Department of\nEqual Opportunity", "Liberty Bank HQ", "I don't know"};
		timeStrings = new string[5] {"Monday\n1:00 PM", "Wednesday\n6:00 PM", "Thursday\n10:00 AM", "Friday\n2:00 PM", "I don't know"};
		peopleStrings = new string[5] {"Michael Deer\nJournalist", "Sarah Jackson\nFinancier", "Mei Yamato\nGovernment agent", "Mist\nProgrammer", "I don't know"};
		meansStrings = new string[5] {"Cutting off\ncommunications", "Planting false\ninformation", "Shutting off\nthe power", "Bomb threat", "I don't know"};
		
		rightAnswers = new int[4] {1, 1, 2, 1};
		
		/**
		float xPos = 0.6f;
		float xOffset = 0.1f;
		float yPos = 0.35f;
		float yOffset = 0.1f;
		float zPos = 1.0f;		//In case we want to do z-ordering
		*/

		/*
		 * Josh settings
		float rectRightInset = 250f;
		float rectY = 245f;
		float rectWidth = 135f;
		float rectHeight = 50f;
		float rectXOffset = 6f;
		float rectYOffset = 72f;
		int textSize = 10;
		*/

		/*
		 * Pierre settings
		 */
		float rectRightInset = 205f;
		float rectY = 195f;
		float rectWidth = 105f;
		float rectHeight = 50f;
		float rectXOffset = 6f;
		float rectYOffset = 52f;
		int textSize = 9;

		for (int i = 0; i < 4; i++) {
			placeObjects[i].GetComponent<DataField>().type = DataField.DataFieldType.PlaceField;
			placeObjects[i].GetComponent<DataField>().text.text = placeStrings[i];
			placeObjects[i].GetComponent<DataField>().buttonRect = new Rect (
				Screen.width - rectRightInset - (rectWidth+rectXOffset)*i, rectY + (rectHeight+rectYOffset)*0, rectWidth, rectHeight);
//			placeObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos, zPos);
			placeObjects[i].GetComponent<DataField>().unselectedStyle.fontSize = textSize;
			placeObjects[i].GetComponent<DataField>().selectedStyle.fontSize = textSize;
			placeObjects[i].GetComponent<DataField>().text.enabled = false;
			
			timeObjects[i].GetComponent<DataField>().type = DataField.DataFieldType.TimeField;
			timeObjects[i].GetComponent<DataField>().text.text = timeStrings[i];
			timeObjects[i].GetComponent<DataField>().buttonRect = new Rect (
				Screen.width - rectRightInset - (rectWidth+rectXOffset)*i, rectY + (rectHeight+rectYOffset)*1, rectWidth, rectHeight);
//			timeObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos + yOffset*1, zPos);
			timeObjects[i].GetComponent<DataField>().unselectedStyle.fontSize = textSize;
			timeObjects[i].GetComponent<DataField>().selectedStyle.fontSize = textSize;
			timeObjects[i].GetComponent<DataField>().text.enabled = false;
			
			peopleObjects[i].GetComponent<DataField>().type = DataField.DataFieldType.PersonField;
			peopleObjects[i].GetComponent<DataField>().text.text = peopleStrings[i];
			peopleObjects[i].GetComponent<DataField>().buttonRect = new Rect (
				Screen.width - rectRightInset - (rectWidth+rectXOffset)*i, rectY + (rectHeight+rectYOffset)*2, rectWidth, rectHeight);
//			peopleObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos + yOffset*2, zPos);
			peopleObjects[i].GetComponent<DataField>().unselectedStyle.fontSize = textSize;
			peopleObjects[i].GetComponent<DataField>().selectedStyle.fontSize = textSize;
			peopleObjects[i].GetComponent<DataField>().text.enabled = false;
			
			meansObjects[i].GetComponent<DataField>().type = DataField.DataFieldType.MeansField;
			meansObjects[i].GetComponent<DataField>().text.text = meansStrings[i];
			meansObjects[i].GetComponent<DataField>().buttonRect = new Rect (
				Screen.width - rectRightInset - (rectWidth+rectXOffset)*i, rectY + (rectHeight+rectYOffset)*3, rectWidth, rectHeight);
			//			meansObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos + yOffset*3, zPos);
			meansObjects[i].GetComponent<DataField>().selectedStyle.fontSize = textSize;
			meansObjects[i].GetComponent<DataField>().unselectedStyle.fontSize = textSize;
			meansObjects[i].GetComponent<DataField>().text.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if (GameManager.instance.gameState == GameManager.GameState.MainMenu || GameManager.instance.gameState == GameManager.GameState.LieDetector) {
//			for (int i = 0; i < 4; i++) {
//				placeObjects[i].GetComponent<DataField>().text.enabled = true;
//				timeObjects[i].GetComponent<DataField>().text.enabled = true;
//				peopleObjects[i].GetComponent<DataField>().text.enabled = true;
//				meansObjects[i].GetComponent<DataField>().text.enabled = true;
//			}
//		}	
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
	
	public bool AllSelected () {
		bool placeSelected = false;
		bool timeSelected = false;
		bool personSelected = false;
		bool meansSelected = false;
		foreach (GameObject o in placeObjects) {
			if (o.GetComponent<DataField>().selected) {
				placeSelected = true;
			}
		}
		foreach (GameObject o in timeObjects) {
			if (o.GetComponent<DataField>().selected) {
				timeSelected = true;
			}
		}
		foreach (GameObject o in peopleObjects) {
			if (o.GetComponent<DataField>().selected) {
				personSelected = true;
			}
		}
		foreach (GameObject o in meansObjects) {
			if (o.GetComponent<DataField>().selected) {
				meansSelected = true;
			}
		}
		return placeSelected && timeSelected && personSelected && meansSelected;
	}
}
