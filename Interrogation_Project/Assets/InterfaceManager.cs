using UnityEngine;
using System.Collections;

public class InterfaceManager : MonoBehaviour {

	//Fields
	public enum InterfaceType { StartUp, MainMenu, Other }
	public InterfaceType interfaceType;

	public enum MMIconType { Background, Question, PrisonerIcon, PrisonerInfo }
	public MMIconType mmIconType;

	public InterfaceManager prisonerInfoPanel;

	public bool enabled;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.K)) {
			GameManager.instance.gameState = GameManager.GameState.MainMenu;
		}
		switch (interfaceType) {
		case InterfaceType.StartUp:
			StartUpInterface();
			break;
		case InterfaceType.MainMenu:
			MainMenuInterface();
			break;
		}
		CheckEnabled ();
	}

	//Handles The different interface types
	void StartUpInterface () {
		if (GameManager.instance.gameState == GameManager.GameState.Startup) {
			enabled = true;
		}
		else {
			enabled = false;
		}
	}

	void MainMenuInterface () {
		if (GameManager.instance.gameState == GameManager.GameState.MainMenu) {
			switch (mmIconType) {
			case MMIconType.Background:
				enabled = true;
				break;
			case MMIconType.PrisonerIcon:
				enabled = true;
				if (GetComponent<GUI_Button>().clicked) {
					GameManager.instance.prisonerInfoPanel = this.prisonerInfoPanel;
				}
				break;
			case MMIconType.PrisonerInfo:
				if (GameManager.instance.prisonerInfoPanel == this) {
					enabled = true;
				}
				else {
					enabled = false;
				}

				break;
			case MMIconType.Question:
				enabled = true;
				break;
			}

			//enabled = true;
		}
		else {
			enabled = false;
		}
	}

	//Display the image depending on whether it's enabled or not
	void CheckEnabled () {
		if (enabled) {
			foreach (GUITexture texture in GetComponentsInChildren<GUITexture>()) {
				texture.enabled = true;
			}
		}
		else {
			foreach (GUITexture texture in GetComponentsInChildren<GUITexture>()) {
				texture.enabled = false;
			}
		}
	}
}
