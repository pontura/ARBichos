using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour {

	public GameObject panel;
	void Start () {
		panel.SetActive (true);

	}

	public void Init() {
		panel.SetActive (true);
	}

	public void Clicked()
	{
		SceneManager.LoadScene ("Intro");
	}
}
