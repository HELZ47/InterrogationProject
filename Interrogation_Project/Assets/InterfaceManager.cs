using UnityEngine;
using System.Collections;

public class InterfaceManager : MonoBehaviour {

	//Fields
	public enum InterfaceType { StartUp, MainMenu, LieDetector, Background }
	public InterfaceType interfaceType;

	public enum MMIconType { Background, Question, PrisonerIcon, PrisonerInfo, Instruction }
	public MMIconType mmIconType;

	public InterfaceManager prisonerInfoPanel;
	public Question_Timer questionTimer;
	public Texture replaceTexture;

	public enum LDIconType { FormulatedQuestion, PickPrisoner, PickAnswer, DetectLie }
	public LDIconType ldIconType;

	public enum QuestionType { Where, Who, How, When }
	public QuestionType questionType;

	public enum SmallQuestionType { Where, Who, How, When, PrisonerIcon }
	public SmallQuestionType smallQuestionType;

	public enum PrisonerIconType { P_1, P_2, P_3, P_4 }
	public PrisonerIconType prisonerIconType;

	public enum AnswerType { Where, Who, How, When }
	public AnswerType answerType;
	public enum AnswerNumber { A_1, A_2, A_3, A_4 }
	public AnswerNumber answerNumber;

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
		case InterfaceType.LieDetector:
			LieDetectorInterface ();
			break;
		case InterfaceType.Background:
			if (GameManager.instance.gameState != GameManager.GameState.Startup) {
				enabled = true;
			}
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
				if (GetComponent<GUI_Button>().clicked) {
					if (GetComponentInChildren<GUITexture>().texture != replaceTexture) {
						GameManager.instance.prisonerInfoPanel = this.prisonerInfoPanel;
					    questionTimer.StartTimer ();
					    GetComponentInChildren<GUITexture>().texture = replaceTexture;
					}
					else if (GetComponentInChildren<GUITexture>().texture == replaceTexture) {
						GameManager.instance.gameState = GameManager.GameState.LieDetector;
						GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Formulated_Question;
					}
				}
				break;
			case MMIconType.Instruction:
				if (GameManager.instance.prisonerInfoPanel == this) {
					enabled = true;
				}
				else {
					enabled = false;
				}
				break;
			}

			//enabled = true;
		}
		else {
			enabled = false;
		}
	}

	void LieDetectorInterface () {
		if (GameManager.instance.gameState == GameManager.GameState.LieDetector) {
			switch (ldIconType) {
			case LDIconType.FormulatedQuestion:
				if (GameManager.instance.lieDetectorState == GameManager.LieDetectorState.Formulated_Question) {
					enabled = true;
					if (GetComponent<GUI_Button>().clicked) {
						switch (questionType) {
						case QuestionType.Where:
							GameManager.instance.ldQuestionType = GameManager.LDQuestionType.Where;
							GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Pick_Prisoner;
							break;
						case QuestionType.Who:
							GameManager.instance.ldQuestionType = GameManager.LDQuestionType.Who;
							GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Pick_Prisoner;
							break;
						case QuestionType.How:
							GameManager.instance.ldQuestionType = GameManager.LDQuestionType.How;
							GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Pick_Prisoner;
							break;
						case QuestionType.When:
							GameManager.instance.ldQuestionType = GameManager.LDQuestionType.When;
							GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Pick_Prisoner;
							break;
						}
					}
				}
				else {
					enabled = false;
				}
				break;
			case LDIconType.PickPrisoner:
				if (GameManager.instance.lieDetectorState == GameManager.LieDetectorState.Pick_Prisoner
				    || GameManager.instance.lieDetectorState == GameManager.LieDetectorState.Pick_Answer) {
					switch (GameManager.instance.ldQuestionType) {
					case GameManager.LDQuestionType.Where:
						if (smallQuestionType == SmallQuestionType.Where) {
							enabled = true;
						}
						else {
							enabled = false;
						}
						break;
					case GameManager.LDQuestionType.Who:
						if (smallQuestionType == SmallQuestionType.Who) {
							enabled = true;
						}
						else {
							enabled = false;
						}
						break;
					case GameManager.LDQuestionType.How:
						if (smallQuestionType == SmallQuestionType.How) {
							enabled = true;
						}
						else {
							enabled = false;
						}
						break;
					case GameManager.LDQuestionType.When:
						if (smallQuestionType == SmallQuestionType.When) {
							enabled = true;
						}
						else {
							enabled = false;
						}
						break;
					}

					if (smallQuestionType == SmallQuestionType.PrisonerIcon) {
						enabled = true;
						if (GetComponentInChildren<GUI_Button>().clicked
						    && GameManager.instance.lieDetectorState == GameManager.LieDetectorState.Pick_Prisoner) {
							switch (prisonerIconType) {
							case PrisonerIconType.P_1:
								GameManager.instance.pickedPrisoner = GameManager.PickedPrisoner.P_1;
								GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Pick_Answer;
								break;
							case PrisonerIconType.P_2:
								GameManager.instance.pickedPrisoner = GameManager.PickedPrisoner.P_2;
								GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Pick_Answer;
								break;
							case PrisonerIconType.P_3:
								GameManager.instance.pickedPrisoner = GameManager.PickedPrisoner.P_3;
								GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Pick_Answer;
								break;
							case PrisonerIconType.P_4:
								GameManager.instance.pickedPrisoner = GameManager.PickedPrisoner.P_4;
								GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Pick_Answer;
								break;
							}
						}
					}
				}
				else {
					enabled = false;
				}
				break;
			case LDIconType.PickAnswer:
				if (GameManager.instance.lieDetectorState == GameManager.LieDetectorState.Pick_Answer) {
					switch (GameManager.instance.ldQuestionType) {
					case GameManager.LDQuestionType.Where:
						if (answerType == AnswerType.Where) {
							enabled = true;
						}
						else {
							enabled = false;
						}
						break;
					case GameManager.LDQuestionType.Who:
						if (answerType == AnswerType.Who) {
							enabled = true;
						}
						else {
							enabled = false;
						}
						break;
					case GameManager.LDQuestionType.How:
						if (answerType == AnswerType.How) {
							enabled = true;
						}
						else {
							enabled = false;
						}
						break;
					case GameManager.LDQuestionType.When:
						if (answerType == AnswerType.When) {
							enabled = true;
						}
						else {
							enabled = false;
						}
						break;
					}

					if (GetComponentInChildren<GUI_Button>().clicked && enabled) {
						switch (answerNumber) {
						case AnswerNumber.A_1:
							GameManager.instance.answerNumber = GameManager.AnswerNumber.A_1;
							GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Detect_Lie;
							break;
						case AnswerNumber.A_2:
							GameManager.instance.answerNumber = GameManager.AnswerNumber.A_2;
							GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Detect_Lie;
							break;
						case AnswerNumber.A_3:
							GameManager.instance.answerNumber = GameManager.AnswerNumber.A_3;
							GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Detect_Lie;
							break;
						case AnswerNumber.A_4:
							GameManager.instance.answerNumber = GameManager.AnswerNumber.A_4;
							GameManager.instance.lieDetectorState = GameManager.LieDetectorState.Detect_Lie;
							break;
						}
					}
				}
				else {
					enabled = false;
				}
				break;
			case LDIconType.DetectLie:

				break;
			}
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
