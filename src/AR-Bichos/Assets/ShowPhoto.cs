using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPhoto : MonoBehaviour {

	public GameObject panel;
	public RawImage rawImage;
	bool isOn;

	void Start () {
		panel.SetActive (false);
	}
	
	public void SetOn()
	{
		rawImage.texture = Data.Instance.photosManager.GetLast();
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
