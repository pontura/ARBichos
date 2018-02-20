using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	public GameObject iOSController;
	public GameObject AndroidController;

	public Game game;
	public Camera cam_android;
	public Camera cam_ios;
	void Awake()
	{
	#if UNITY_ANDROID
		AndroidController.SetActive(true);
	#elif UNITY_IOS
		iOSController.SetActive(true);
	#endif
	}
	void Start()
	{
		#if UNITY_EDITOR
		Game newGame = Instantiate(game);
		newGame.Init (cam_android);
		#endif
		Events.AddWorld += AddWorld;
	}
	void AddWorld(Transform target, Vector3 pos, Quaternion rot)
	{
		Camera cam = cam_android;
	#if UNITY_IOS
		cam = cam_ios;
	#endif
		Game newGame = Instantiate(game, pos,rot);
		newGame.Init (cam);

		newGame.transform.LookAt(cam.transform);
		newGame.transform.rotation = Quaternion.Euler(0.0f, newGame.transform.rotation.eulerAngles.y, newGame.transform.rotation.z);

		// Make Andy model a child of the anchor.
		newGame.transform.parent = target;
	}

}
