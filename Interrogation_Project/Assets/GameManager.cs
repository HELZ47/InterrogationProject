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
	public float startUpTimer;
	public bool startUpTimerStarted;

	public enum GameState {Startup, MainMenu, LieDetector }
	public GameState gameState;

	public InterfaceManager prisonerInfoPanel;
	public Question_Timer questionTimer;

	public enum LieDetectorState { Formulated_Question, Pick_Prisoner, Pick_Answer, Detect_Lie }
	public LieDetectorState lieDetectorState;

	public enum LDQuestionType { Where, Who, How, When }
	public LDQuestionType ldQuestionType;

	public enum PickedPrisoner { P_1, P_2, P_3, P_4 }
	public PickedPrisoner pickedPrisoner;

	public enum AnswerType { Where, Who, How, When }
	public AnswerType answerType;
	public enum AnswerNumber { A_1, A_2, A_3, A_4 }
	public AnswerNumber answerNumber;

	public bool tellingTruth;

	//Wake function
	void Awake () {
		_pInstance = new GameManager ();
	}

	// Use this for initialization
	void Start () {
		_pInstance.gameState = GameState.Startup;
		_pInstance.prisonerInfoPanel = GameObject.Find ("img_StartGame_Instructions").GetComponent<InterfaceManager>();
		_pInstance.questionTimer = GameObject.Find ("gr_GameTimers").GetComponent<Question_Timer>();
	}
	
	// Update is called once per frame
	void Update () {
		//print (_pInstance.ldQuestionType.ToString () + " " + _pInstance.pickedPrisoner + " " + _pInstance.answerNumber + " " + _pInstance.tellingTruth);
		switch (_pInstance.gameState) {
		case GameState.Startup:
			if (Input.GetMouseButtonDown(0)) {
				_pInstance.startUpTimerStarted = true;
				//_pInstance.gameState = GameState.MainMenu;
			}
			if (_pInstance.startUpTimerStarted == true) {
				_pInstance.startUpTimer += Time.deltaTime;
				if (_pInstance.startUpTimer > 0.5f) {
					_pInstance.gameState = GameState.MainMenu;
				}
			}
			break;
		case GameState.MainMenu:
			if (_pInstance.questionTimer.timeUp) {
				_pInstance.gameState = GameState.LieDetector;
				_pInstance.lieDetectorState = LieDetectorState.Formulated_Question;
			}
			break;
		case GameState.LieDetector:
			switch (_pInstance.lieDetectorState) {
			case LieDetectorState.Detect_Lie:
				switch (_pInstance.pickedPrisoner) {
				case PickedPrisoner.P_1:
					if (_pInstance.ldQuestionType == LDQuestionType.Where
					    && _pInstance.answerNumber == AnswerNumber.A_2) {
						_pInstance.tellingTruth = true;
					}
					else if (_pInstance.ldQuestionType == LDQuestionType.When
					         && _pInstance.answerNumber == AnswerNumber.A_2) {
						_pInstance.tellingTruth = true;
					}
					else {
						_pInstance.tellingTruth = false;
					}
					break;
				case PickedPrisoner.P_2:
					if (_pInstance.ldQuestionType == LDQuestionType.Where
					    && _pInstance.answerNumber == AnswerNumber.A_2) {
						_pInstance.tellingTruth = true;
					}
					else if (_pInstance.ldQuestionType == LDQuestionType.Who
					         && _pInstance.answerNumber == AnswerNumber.A_3) {
						_pInstance.tellingTruth = true;
					}
					else if (_pInstance.ldQuestionType == LDQuestionType.How
					         && _pInstance.answerNumber == AnswerNumber.A_2) {
						_pInstance.tellingTruth = true;
					}
					else {
						_pInstance.tellingTruth = false;
					}
					break;
				case PickedPrisoner.P_3:
					if (_pInstance.ldQuestionType == LDQuestionType.Who
					    && _pInstance.answerNumber == AnswerNumber.A_3) {
						_pInstance.tellingTruth = true;
					}
					else {
						_pInstance.tellingTruth = false;
					}
					break;
				case PickedPrisoner.P_4:
					if (_pInstance.ldQuestionType == LDQuestionType.Where
					    && _pInstance.answerNumber == AnswerNumber.A_2) {
						_pInstance.tellingTruth = true;
					}
					else if (_pInstance.ldQuestionType == LDQuestionType.When
					         && _pInstance.answerNumber == AnswerNumber.A_2) {
						_pInstance.tellingTruth = true;
					}
					else if (_pInstance.ldQuestionType == LDQuestionType.How
					         && _pInstance.answerNumber == AnswerNumber.A_2) {
						_pInstance.tellingTruth = true;
					}
					else {
						_pInstance.tellingTruth = false;
					}
					break;
				}
				break;
			}
			break;
		}
	}
}
