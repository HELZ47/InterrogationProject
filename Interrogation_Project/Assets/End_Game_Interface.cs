using UnityEngine;
using System.Collections;

public class End_Game_Interface : MonoBehaviour {

	//Fields
	public enum InterfaceType { SendButton }
	public InterfaceType interfaceType;
	public GameObject dataManager;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		switch (interfaceType) {
		case InterfaceType.SendButton:
			if (GameManager.instance.gameState == GameManager.GameState.Startup
			    || GameManager.instance.gameState == GameManager.GameState.EndGame) {
				GetComponentInChildren<GUITexture>().enabled = false;
			}
			else {
				GetComponentInChildren<GUITexture>().enabled = true;
			}
			
			if (GetComponentInChildren<GUI_Button>().clicked && GameManager.instance.gameState != GameManager.GameState.Startup) {
				if (dataManager.GetComponent<DataFieldManager>().AllSelected()) {
					GameManager.instance.gameState = GameManager.GameState.EndGame;
				}
			}
			break;
		}
	}
}
