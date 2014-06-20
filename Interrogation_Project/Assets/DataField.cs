using UnityEngine;
using System.Collections;

public class DataField : MonoBehaviour {

	public enum DataFieldType { PlaceField, TimeField, PersonField, MeansField };
	public DataFieldType type;
	public bool selected;
	public GUIText text;
	public GUITexture texture;
	public GUIStyle unselectedStyle;
	public GUIStyle selectedStyle;
	public Rect buttonRect;

	public Texture selectedTexture;
	public Texture unSelectedTexture;
	
	void Awake () {
		text = gameObject.GetComponent<GUIText>();
		//texture = gameObject.GetComponent<GUITexture>();
	}

	// Use this for initialization
	void Start () {
		text.fontStyle = unselectedStyle.fontStyle;


	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameState != GameManager.GameState.Startup
		    && GameManager.instance.gameState != GameManager.GameState.EndGame
		    && GameManager.instance.gameState != GameManager.GameState.Conviction) {
			guiTexture.enabled = true;
			guiTexture.texture = selected ? selectedTexture : unSelectedTexture;
			if (GetComponent<GUI_Button>().clicked) {
				GameObject.Find ("_Game_Manager").GetComponent<DataFieldManager>().Select (gameObject, type);
			}
		}
		else {
			guiTexture.enabled = false;
		}
		//guiTexture.texture = selected ? selectedTexture : unSelectedTexture;
	}
	
//	void OnGUI () {
//		if (GameManager.instance.gameState == GameManager.GameState.MainMenu || GameManager.instance.gameState == GameManager.GameState.LieDetector) {
//			GUIStyle style = selected ? unselectedStyle : selectedStyle;  
//			if (GUI.Button (buttonRect,text.text, style)) {
//				GameObject.Find ("_Game_Manager").GetComponent<DataFieldManager>().Select (gameObject, type);
//			}
//		}
//	}
}
