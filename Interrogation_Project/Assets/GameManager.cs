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

	public enum GameState {Startup, MainMenu, LieDetector, EndGame, Conviction }
	public GameState gameState;

	public InterfaceManager prisonerInfoPanel;
	public Question_Timer questionTimer;


	//formulated qustion = pick question (inspector)
	//pick_prisoner = inspector pick player
	//pick_answer = inspector enters player's choice. Ex: prisoner says "Idk", 2you put "Idk" in the program
	//detect lie = process to see if it is a lie 
	public enum LieDetectorState { Formulated_Question, Pick_Prisoner, Pick_Answer, Detect_Lie }
	public LieDetectorState lieDetectorState;

	public enum LDQuestionType { Where, Who, How, When }
	public LDQuestionType ldQuestionType;

	public enum PickedPrisoner { P_1, P_2, P_3, P_4 }
	public PickedPrisoner pickedPrisoner;

	public AssignPrisoner ap; // this will be the new way to reference the answer number

	public enum AnswerType { Where, Who, How, When }
	public AnswerType answerType;
	public enum AnswerNumber { A_1, A_2, A_3, A_4, A_5 }
	public AnswerNumber answerNumber;

	public bool tellingTruth;
	
	public enum ConvictedPrisoner { None, P_1, P_2, P_3, P_4 }
	public ConvictedPrisoner convictedPrisoner1;
	public ConvictedPrisoner convictedPrisoner2;
	public ConvictedPrisoner protectedPrisoner;
	public enum ConvictionState { Convicting, Protecting }
	public ConvictionState convictionState;
	
	public float lieDetectorUsedTimes;


	//Wake function
	void Awake () {
		_pInstance = new GameManager ();

	}

	// Use this for initialization
	void Start () {
		Random.seed = (int)System.DateTime.Now.Ticks;
		_pInstance.gameState = GameState.Startup;
		_pInstance.prisonerInfoPanel = GameObject.Find ("img_StartGame_Instructions").GetComponent<InterfaceManager>();
		_pInstance.questionTimer = GameObject.Find ("gr_GameTimers").GetComponent<Question_Timer>();

		ap = new AssignPrisoner();
		ap.assignRole( Random.Range(0,4), Random.Range(0,4) );
		ap.assignInformation();

		for(int i = 0; i < 4; i++)
		{
			Debug.Log (ap.prisoner[i].outPut());
		}


	}

	public void isActivist(Prisoner p, int actNum)
	{
		if(actNum == ap.activ1)
		{
			//compare the answers
		}
		if(actNum == ap.activ2)
		{
			//compare the answers
		}
	}

	public void isHacker(Prisoner p, int crimNum)
	{
			if(crimNum == ap.crim1)
			{
			//compare the answers
			}

			if(crimNum == ap.crim2)
			{
			//compare the answers
			}
	}

	// Update is called once per frame
	void Update () {
		//	print (_pInstance.convictedPrisoner1); //not sure what this does
	//	print (_pInstance.convictedPrisoner2); //not sure what this does
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
		case GameState.LieDetector: //this is a hard coded section to compare the player's corresponding facts and answer selection
			switch (_pInstance.lieDetectorState) {
			case LieDetectorState.Detect_Lie:
				switch (_pInstance.pickedPrisoner) {
				/*
				case PickedPrisoner.P_1:
					if (_pInstance.ldQuestionType == LDQuestionType.Where
					    && _pInstance.answerNumber == ap.prisoner[0].f.where) {
						_pInstance.tellingTruth = true;
					}
*/

			

				
//this is the original 
				case PickedPrisoner.P_1:
					if (_pInstance.ldQuestionType == LDQuestionType.Where
					    && _pInstance.answerNumber == AnswerNumber.A_2) {
						_pInstance.tellingTruth = true;
					}
					else if (_pInstance.ldQuestionType == LDQuestionType.When
					         && _pInstance.answerNumber == AnswerNumber.A_2) {
						_pInstance.tellingTruth = true;
					}
					else if(_pInstance.ldQuestionType == LDQuestionType.Who
					         && _pInstance.answerNumber == AnswerNumber.A_5) {
						_pInstance.tellingTruth = true;
					}
					else if(_pInstance.ldQuestionType == LDQuestionType.How
					        && _pInstance.answerNumber == AnswerNumber.A_5) {
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
					else if(_pInstance.ldQuestionType == LDQuestionType.When
					        && _pInstance.answerNumber == AnswerNumber.A_5) {
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
					else if (_pInstance.ldQuestionType == LDQuestionType.Where
					         && _pInstance.answerNumber == AnswerNumber.A_5) {
						_pInstance.tellingTruth = true;
					}
					else if (_pInstance.ldQuestionType == LDQuestionType.How
					         && _pInstance.answerNumber == AnswerNumber.A_5) {
						_pInstance.tellingTruth = true;
					}
					else if (_pInstance.ldQuestionType == LDQuestionType.When
					         && _pInstance.answerNumber == AnswerNumber.A_5) {
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
					else if (_pInstance.ldQuestionType == LDQuestionType.Who
					         && _pInstance.answerNumber == AnswerNumber.A_5) {
						Debug.Log("Player 4, Idk for who should be true.");
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
