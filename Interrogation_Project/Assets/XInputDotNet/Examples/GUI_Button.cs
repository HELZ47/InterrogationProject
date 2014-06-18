using UnityEngine;
using System.Collections;

public class GUI_Button : MonoBehaviour {

	//Fields
	public GUITexture mainTexture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (mainTexture.HitTest (Input.mousePosition) && Input.GetMouseButtonDown(0)) {
			print ("Clicked!");
		}
	}
}
