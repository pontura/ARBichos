using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour {

	public Text field;
	float timer = 60;
	int totalPhotos = 10;
	int photosTaken;

	void Start () {
		if (Data.Instance.playMode == Data.playModes.TIME)
			LoopTimer ();
		else
			SetPhotosField ();
	}
	public void NewPhotoTaken()
	{
		photosTaken++;
		if (photosTaken >= totalPhotos)
			Finish ();
		else
			SetPhotosField ();
	}
	public void SetPhotosField()
	{
		SetFieldValue (photosTaken + "/" + totalPhotos);
	}
	void LoopTimer () {
		timer--;
		SetFields ();

		if (timer <= 0)
			Finish ();
		else
			Invoke ("LoopTimer", 1);	
	}
	void SetFields()
	{
		if(timer>9)
			SetFieldValue( "00:" + timer);
		else
			SetFieldValue("00:0" + timer);
	}
	void SetFieldValue(string value)
	{
		field.text = value;
	}
	void Finish()
	{
		Data.Instance.LoadLevel ("Album");
	}

}
