using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanels : MonoBehaviour {

	public Text field;
	public static UIPanels mInstance;
	public CameraFlash flash;
	public ShowPhoto showPhoto;
	public ConfigScreens configScreens;

	public static UIPanels Instance
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
