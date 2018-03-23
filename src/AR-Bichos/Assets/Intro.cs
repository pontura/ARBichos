using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	void Start()
	{
		
	}
	public void PlayByPhotos()
	{
		Data.Instance.playMode = Data.playModes.PHOTOS;
		Done();
	}
	public void PlayByTime()
	{
		Data.Instance.playMode = Data.playModes.TIME;
		Done();
	}
	public void PlayFree()
	{
		Data.Instance.playMode = Data.playModes.FREE;
		Done();
	}
	public void Done()
	{
		SceneManager.LoadScene ("World");
	}
}
