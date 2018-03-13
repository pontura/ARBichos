using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static Game mInstance;
	public Camera cam;
	public GameObject eyeFocus;
	public AnimalsManager animalsManager;
	public GameObject world;

	public states state;
	public enum states
	{
		WAITING,
		DONE
	}

	public static Game Instance
	{
		get
		{
			return mInstance;
		}
	}
	public void Init (Camera cam) {
		this.cam = cam;
		mInstance = this;
		state = states.DONE;
		animalsManager.Init ();
	}
}
