using UnityEngine;
using System.Collections;

public class End_Game_Interface : MonoBehaviour {

	//Fields
	public enum InterfaceType { SendButton, EventFacts, EventResults, Background, Conviction, FollowUp}
	public InterfaceType interfaceType;
	public GameObject dataManager;
	public bool enabled;
	
	public enum FactType { Where, Who, How, When }
	public FactType factType;
	public Texture correctTexture;
	
	public enum ConvictionType { Prisoner, Send, Background, Title, Convict }
	public ConvictionType convictionType;
	public enum PrisonerType { P_1, P_2, P_3, P_4 }
	public PrisonerType prisonerType;
	
	public enum FollowUpType { Prisoner, Prisoner_Reveal }
	public FollowUpType followUpType;
	public enum PrisonerProfile { P_1, P_2, P_3, P_4 }
	public PrisonerProfile prisonerProfile;
	public enum PrisonerRevealType { R_1, R_2, R_3, R_4 }
	public PrisonerRevealType prisonerRevealType;
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		switch (interfaceType) {
		case InterfaceType.SendButton:
			if (GameManager.instance.gameState == GameManager.GameState.Startup
			    || GameManager.instance.gameState == GameManager.GameState.EndGame
			    || GameManager.instance.gameState == GameManager.GameState.Conviction) {
				//GetComponentInChildren<GUITexture>().enabled = false;
				enabled = false;
			}
			else {
				//GetComponentInChildren<GUITexture>().enabled = true;
				enabled = true;
			}
			
			if (GetComponentInChildren<GUI_Button>().clicked && GameManager.instance.gameState != GameManager.GameState.Startup) {
				if (dataManager.GetComponent<DataFieldManager>().AllSelected()) {
					GameManager.instance.gameState = GameManager.GameState.Conviction;
				}
			}
			break;
		case InterfaceType.EventFacts:
			if (GameManager.instance.gameState == GameManager.GameState.EndGame) {
				enabled = true;
				switch (factType) {
				case FactType.Where:
					if (dataManager.GetComponent<DataFieldManager>().placeObjects[1].GetComponent<DataField>().selected) {
						GetComponentInChildren<GUITexture>().texture = correctTexture;
					}
					break;
				case FactType.Who:
					if (dataManager.GetComponent<DataFieldManager>().peopleObjects[2].GetComponent<DataField>().selected) {
						GetComponentInChildren<GUITexture>().texture = correctTexture;
					}
					break;
				case FactType.How:
					if (dataManager.GetComponent<DataFieldManager>().meansObjects[1].GetComponent<DataField>().selected) {
						GetComponentInChildren<GUITexture>().texture = correctTexture;
					}
					break;
				case FactType.When:
					if (dataManager.GetComponent<DataFieldManager>().timeObjects[1].GetComponent<DataField>().selected) {
						GetComponentInChildren<GUITexture>().texture = correctTexture;
					}
					break;
				}
			}
			else {
				enabled = false;
			}
			break;
		case InterfaceType.EventResults:
			if (GameManager.instance.gameState == GameManager.GameState.EndGame) {
				enabled = true;
				if (dataManager.GetComponent<DataFieldManager>().ReportCorrect()) {
					GetComponentInChildren<GUITexture>().texture = correctTexture;
				}
			}
			else {
				enabled = false;
			}
			break;
		case InterfaceType.Background:
			if (GameManager.instance.gameState == GameManager.GameState.EndGame) {
				enabled = true;
			}
			else {
				enabled = false;
			}
			break;
		case InterfaceType.Conviction:
			if (GameManager.instance.gameState == GameManager.GameState.Conviction) {
				switch (convictionType) {
				case ConvictionType.Background:
					enabled = true;
					break;
				case ConvictionType.Prisoner:
					enabled = true;
					if (GameManager.instance.convictionState == GameManager.ConvictionState.Convicting) {
						if (GetComponentInChildren<GUI_Button>().clicked) {
							switch (prisonerType) {
							case PrisonerType.P_1:
								if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.convictedPrisoner1 = GameManager.ConvictedPrisoner.P_1;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.convictedPrisoner2 = GameManager.ConvictedPrisoner.P_1;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								break;
							case PrisonerType.P_2:
								if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.convictedPrisoner1 = GameManager.ConvictedPrisoner.P_2;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.convictedPrisoner2 = GameManager.ConvictedPrisoner.P_2;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								break;
							case PrisonerType.P_3:
								if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.convictedPrisoner1 = GameManager.ConvictedPrisoner.P_3;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.convictedPrisoner2 = GameManager.ConvictedPrisoner.P_3;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								break;
							case PrisonerType.P_4:
								if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.convictedPrisoner1 = GameManager.ConvictedPrisoner.P_4;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.convictedPrisoner2 = GameManager.ConvictedPrisoner.P_4;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								break;
							}
						}
					}
					else if (GameManager.instance.convictionState == GameManager.ConvictionState.Protecting) {
						if (GetComponentInChildren<GUI_Button>().clicked && GetComponentInChildren<GUITexture>().texture != correctTexture) {
							switch (prisonerType) {
							case PrisonerType.P_1:
								if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.protectedPrisoner = GameManager.ConvictedPrisoner.P_1;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								break;
							case PrisonerType.P_2:
								if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.protectedPrisoner = GameManager.ConvictedPrisoner.P_2;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								break;
							case PrisonerType.P_3:
								if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.protectedPrisoner = GameManager.ConvictedPrisoner.P_3;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								break;
							case PrisonerType.P_4:
								if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.None) {
									GameManager.instance.protectedPrisoner = GameManager.ConvictedPrisoner.P_4;
									GetComponentInChildren<GUITexture>().texture = correctTexture;
								}
								break;
							}
						}
					}
					break;
				case ConvictionType.Send:
					if (GameManager.instance.convictionState == GameManager.ConvictionState.Protecting) {
						enabled = true;
						if (GetComponentInChildren<GUI_Button>().clicked) {
							GameManager.instance.gameState = GameManager.GameState.EndGame;
						}
					}
					else {
						enabled = false;
					}
					break;
				case ConvictionType.Convict:
					if (GameManager.instance.convictionState == GameManager.ConvictionState.Convicting) {
						enabled = true;
						if (GetComponentInChildren<GUI_Button>().clicked
						    && GameManager.instance.convictedPrisoner1 != GameManager.ConvictedPrisoner.None
						    && GameManager.instance.convictedPrisoner2 != GameManager.ConvictedPrisoner.None) {
							GameManager.instance.convictionState = GameManager.ConvictionState.Protecting;
						}
					}
					else {
						enabled = false;
					}
					break;
				case ConvictionType.Title:
					enabled = true;
					if (GameManager.instance.convictionState == GameManager.ConvictionState.Protecting) {
						GetComponentInChildren<GUITexture>().texture = correctTexture;
					}
					break;
				}
			}
			else {
				enabled = false;
			}
			break;
		case InterfaceType.FollowUp:
			if (GameManager.instance.gameState == GameManager.GameState.EndGame) {
				enabled = true;
				switch (followUpType) {
				case FollowUpType.Prisoner:
					switch (prisonerProfile) {
					case PrisonerProfile.P_1:
						if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.P_1) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.P_1) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.P_1) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						break;
					case PrisonerProfile.P_2:
						if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.P_2) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.P_2) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.P_2) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						break;
					case PrisonerProfile.P_3:
						if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.P_3) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.P_3) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.P_3) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						break;
					case PrisonerProfile.P_4:
						if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.P_4) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.P_4) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.P_4) {
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						break;
					}
					break;
				case FollowUpType.Prisoner_Reveal:
					switch (prisonerRevealType) {
					case PrisonerRevealType.R_1:
						if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.P_1) {
							enabled = true;
						}
						else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.P_1) {
							enabled = true;
						}
						else if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.P_1) {
							enabled = true;
						}
						else {
							enabled = false;
						}
						break;
					case PrisonerRevealType.R_2:
						if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.P_2) {
							enabled = true;
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.P_2) {
							enabled = true;
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.P_2) {
							enabled = true;
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else {
							enabled = false;
						}
						break;
					case PrisonerRevealType.R_3:
						if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.P_3) {
							enabled = true;
						}
						else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.P_3) {
							enabled = true;
						}
						else if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.P_3) {
							enabled = true;
						}
						else {
							enabled = false;
						}
						break;
					case PrisonerRevealType.R_4:
						if (GameManager.instance.convictedPrisoner1 == GameManager.ConvictedPrisoner.P_4) {
							enabled = true;
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.convictedPrisoner2 == GameManager.ConvictedPrisoner.P_4) {
							enabled = true;
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else if (GameManager.instance.protectedPrisoner == GameManager.ConvictedPrisoner.P_4) {
							enabled = true;
							GetComponentInChildren<GUITexture>().texture = correctTexture;
						}
						else {
							enabled = false;
						}
						break;
					}
					break;
				}
			}
			else {
				enabled = false;
			}
			break;
		}
		
		
		CheckEnabled ();
	}
	
	void CheckEnabled () {
		if (enabled) {
			GetComponentInChildren<GUITexture>().enabled = true;
		}
		else {
			GetComponentInChildren<GUITexture>().enabled = false;
		}
	}
}
