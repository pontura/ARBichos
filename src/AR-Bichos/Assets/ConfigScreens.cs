using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigScreens : MonoBehaviour {

	public GameObject panel;
	public Text field;

	public states state;
	bool isDone;

	public enum states
	{
		IDLE,
		CONFIG_AREA,
		TOUCH_TO_CREATE,
		DONE
	}
	void Start()
	{
		
	}
	public void SetState(states newState) {
		
		if (isDone)
			return;
		
		switch (newState) {
		case states.CONFIG_AREA:
			panel.SetActive (true);
			field.text = "Move the device until an area is detected";
			break;
		case states.TOUCH_TO_CREATE:
			panel.SetActive (true);
			field.text = "Tap where you want to place the game";
			break;
		case states.DONE:
			panel.SetActive (false);
			isDone = true;
			break;
		}

	}
}
