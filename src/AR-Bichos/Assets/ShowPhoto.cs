using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPhoto : MonoBehaviour {

	public GameObject panel;
	bool isOn;

	void Start () {
		panel.SetActive (false);
	}
	
	public void SetOn()
	{
		Invoke ("Wait", 0.5f);
	}
	void Wait()
	{
		if (isOn)
			return;
		isOn = true;
		panel.SetActive (true);
		Invoke ("SetOff", 3);
	}
	void SetOff()
	{
		isOn = false;
		panel.SetActive (false);
	}
}
