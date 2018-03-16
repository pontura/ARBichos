using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static Game mInstance;
	public GameObject eyeFocus;
	public AnimalsManager animalsManager;
	public GameObject world;

	public states state;

	public enum states
	{
		WAITING,
		DONE
	}


	public void Init () {
		UIPanels.Instance.configScreens.SetState (ConfigScreens.states.DONE);
		state = states.DONE;
		animalsManager.Init ();
	}
}
