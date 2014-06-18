using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Fields
	private static GameManager _pInstance;
	public static GameManager instance {
		get {
			return _pInstance;
		}
	}

	public enum GameState {Startup, MainMenu, Other }
	public GameState gameState;

	public InterfaceManager prisonerInfoPanel;

	//Wake function
	void Awake () {
		_pInstance = new GameManager ();
	}

	// Use this for initialization
	void Start () {
		_pInstance.gameState = GameState.Startup;
	}
	
	// Update is called once per frame
	void Update () {
		switch (_pInstance.gameState) {
		case GameState.Startup:
			if (Input.GetMouseButtonDown(0)) {
				_pInstance.gameState = GameState.MainMenu;
			}
			break;
		}
		print (_pInstance.gameState);
	}
}
