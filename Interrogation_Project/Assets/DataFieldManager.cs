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
		placeStrings = new string[4] {"Federal reserve", "Stock exchange", "Department of Finance", "Bank HQ"};
		timeStrings = new string[4] {"10:00 AM", "Noon", "3:00 PM", "6:00 PM"};
		peopleStrings = new string[4] {"Journalist", "Financier", "Government agent", "Programmer"};
		meansStrings = new string[4] {"Cutting off communications", "Planting false information", "Shutting off the power", "Bomb threat"};
		
		rightAnswers = new int[4] {0, 2, 0, 2};
		
		float xPos = 0.6f;
		float xOffset = 0.1f;
		float yPos = 0.35f;
		float yOffset = 0.1f;
		float zPos = 1.0f;		//In case we want to do z-ordering
		
		for (int i = 0; i < 4; i++) {
			placeObjects[i].GetComponent<DataField>().text.text = placeStrings[i];
			placeObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos, zPos);
			timeObjects[i].GetComponent<DataField>().text.text = timeStrings[i];
			timeObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos + yOffset*1, zPos);
			peopleObjects[i].GetComponent<DataField>().text.text = peopleStrings[i];
			peopleObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos + yOffset*2, zPos);
			meansObjects[i].GetComponent<DataField>().text.text = meansStrings[i];
			meansObjects[i].transform.position = new Vector3 (xPos + xOffset*i, yPos + yOffset*3, zPos);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool ReportCorrect () {
		return  placeObjects[rightAnswers[0]].GetComponent<DataField>().selected &&
				timeObjects[rightAnswers[1]].GetComponent<DataField>().selected && 
				peopleObjects[rightAnswers[2]].GetComponent<DataField>().selected && 
				meansObjects[rightAnswers[3]].GetComponent<DataField>().selected; 
	}
}
