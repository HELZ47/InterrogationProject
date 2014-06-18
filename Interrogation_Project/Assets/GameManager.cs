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

	public enum GameState {Startup, MainMenu, LieDetector }
	public GameState gameState;

	public InterfaceManager prisonerInfoPanel;
	public Question_Timer questionTimer;

	public enum LieDetectorState { Formulated_Question, Pick_Prisoner, Pick_Answer, Detect_Lie }
	public LieDetectorState lieDetectorState;

	public enum LDQuestionType { Where, Who, How, When }
	public LDQuestionType ldQuestionType;

	//Wake function
	void Awake () {
		_pInstance = new GameManager ();
	}

	// Use this for initialization
	void Start () {
		_pInstance.gameState = GameState.Startup;
		_pInstance.prisonerInfoPanel = GameObject.Find ("img_StartGame_Instructions").GetComponent<InterfaceManager>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (_pInstance.gameState) {
		case GameState.Startup:
			if (Input.GetMouseButtonDown(0)) {
				_pInstance.gameState = GameState.MainMenu;
			}
			break;
		case GameState.MainMenu:
			if (questionTimer.timeUp) {
				_pInstance.gameState = GameState.LieDetector;
				_pInstance.lieDetectorState = LieDetectorState.Formulated_Question;
			}
			break;
		}
	}
}
