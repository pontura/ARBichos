using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text field;
	public static UI mInstance;
	public CameraFlash flash;
	public ShowPhoto showPhoto;

	public static UI Instance
	{
		get 
		{
			return mInstance;
		}
	}
	void Start () {
		mInstance = this;
		Events.DebugText += DebugText;


	}

	void DebugText (string texto) {
		field.text = texto;
	}
}
