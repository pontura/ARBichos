using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text field;

	void Start () {
		Events.DebugText += DebugText;


	}

	void DebugText (string texto) {
		field.text = texto;
	}
}
