using UnityEngine;
using System.Collections;

public class DataField : MonoBehaviour {

	public bool selected;
	public GUIText text;
	public GUITexture texture;
	public GUIStyle unselectedStyle;
	public GUIStyle selectedStyle;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<GUIText>();
		texture = gameObject.GetComponent<GUITexture>();
		text.fontStyle = unselectedStyle.fontStyle;
	}
	
	// Update is called once per frame
	void Update () {
	
	}	
}
