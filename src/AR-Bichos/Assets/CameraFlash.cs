using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlash : MonoBehaviour {

	public GameObject flash;

	public void SetOn()
	{
		flash.SetActive (true);
		Invoke ("Off", 0.6f);
	}
	void Off()
	{
		flash.SetActive (false);
	}
}
