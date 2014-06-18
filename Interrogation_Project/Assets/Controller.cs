using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Controller : MonoBehaviour {

	//Fields
	PlayerIndex playerOne, playerTwo, playerThree, PlayerFour;
	GamePadState stateOne, stateTwo, stateThree, stateFour, prevStateOne, prevStateTwo, prevStateThree, prevStateFour;
	float stabilizeTimer;

	public float heartBeatOne, heartBeatTwo, heartBeatThree, heartBeatFour;
	

	// Use this for initialization
	void Start () {
		playerOne = PlayerIndex.One;
		playerTwo = PlayerIndex.Two;
		playerThree = PlayerIndex.Three;
		PlayerFour = PlayerIndex.Four;

		stateOne = GamePad.GetState (playerOne);
		stateTwo = GamePad.GetState (playerTwo);
		stateThree = GamePad.GetState (playerThree);
		stateFour = GamePad.GetState (PlayerFour);

		prevStateOne = stateOne;
		prevStateTwo = stateTwo;
		prevStateThree = stateThree;
		prevStateFour = stateFour;

		//heartBeatOne = heartBeatTwo = heartBeatThree = heartBeatFour = 75f;
	}
	
	// Update is called once per frame
	void Update () {
		//re-assign the gamepad states (have to put it here)
		stateOne = GamePad.GetState (playerOne);
		stateTwo = GamePad.GetState (playerTwo);
		stateThree = GamePad.GetState (playerThree);
		stateFour = GamePad.GetState (PlayerFour);

		HeartBeat (1);
		HeartBeat (2);
		HeartBeat (3);
		if (Input.GetKey (KeyCode.P)) {
			Punish (1);
		}

		if (Input.GetKeyDown ("joystick 3 button 0")) {
			print ("button Pressed!");
		}

		prevStateOne = stateOne;
		prevStateTwo = stateTwo;
		prevStateThree = stateThree;
		prevStateFour = stateFour;
	}

	//Calculate and vibrates the controller of the player (1 ~ 4)
	void HeartBeat (int playerNumber) {
		float beatsPerSecond, beatsTimer, beatStrength;
		switch (playerNumber) {
		case (1):
			beatsPerSecond = heartBeatOne / 60f;
			beatsTimer = 1 / beatsPerSecond;
			beatStrength = 0.98f * (heartBeatOne / 200f);
			if (beatStrength > 0.98f) {
				beatStrength = 0.98f;
			}
			if ((Time.timeSinceLevelLoad - (int)Time.timeSinceLevelLoad) % beatsTimer < 0.1f) {
				GamePad.SetVibration (PlayerIndex.One, beatStrength, beatStrength);
			}
			else {
				GamePad.SetVibration (PlayerIndex.One, 0, 0);
			}
			break;
		case (2):
			beatsPerSecond = heartBeatTwo / 60f;
			beatsTimer = 1 / beatsPerSecond;
			beatStrength = 0.98f * (heartBeatOne / 200f);
			if (beatStrength > 0.98f) {
				beatStrength = 0.98f;
			}
			if ((Time.timeSinceLevelLoad - (int)Time.timeSinceLevelLoad) % beatsTimer < 0.1f) {
				GamePad.SetVibration (PlayerIndex.Two, beatStrength, beatStrength);
			}
			else {
				GamePad.SetVibration (PlayerIndex.Two, 0, 0);
			}
			break;
		case (3):
			beatsPerSecond = heartBeatThree / 60f;
			beatsTimer = 1 / beatsPerSecond;
			beatStrength = 0.98f * (heartBeatOne / 200f);
			if (beatStrength > 0.98f) {
				beatStrength = 0.98f;
			}
			if ((Time.timeSinceLevelLoad - (int)Time.timeSinceLevelLoad) % beatsTimer < 0.1f) {
				GamePad.SetVibration (PlayerIndex.Three, beatStrength, beatStrength);
			}
			else {
				GamePad.SetVibration (PlayerIndex.Three, 0, 0);
			}
			break;
		case (4):
			beatsPerSecond = heartBeatFour / 60f;
			beatsTimer = 1 / beatsPerSecond;
			beatStrength = 0.98f * (heartBeatOne / 200f);
			if (beatStrength > 0.98f) {
				beatStrength = 0.98f;
			}			
			if ((Time.timeSinceLevelLoad - (int)Time.timeSinceLevelLoad) % beatsTimer < 0.1f) {
				GamePad.SetVibration (PlayerIndex.Four, beatStrength, beatStrength);
			}
			else {
				GamePad.SetVibration (PlayerIndex.Four, 0, 0);
			}
			break;
		}
	}

	//Punish the player and increase its heart rate
	void Punish (int playerNumber) {
		switch (playerNumber) {
		case (1):
			GamePad.SetVibration(PlayerIndex.One, 1, 1);
			heartBeatOne += 0.3f;
			break;
		}
	}
}
