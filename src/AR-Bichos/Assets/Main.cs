using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	
	public GameObject iOSController;
	public GameObject AndroidController;
	public static Main mInstance;

	public Game game;
	public Game game_to_instantiate;
	public Camera debugCam;
	public Camera cam_android;
	public Camera cam_ios;

	void Awake()
	{

		mInstance = this;

	#if UNITY_ANDROID
		AndroidController.SetActive(true);
	#elif UNITY_IOS
		iOSController.SetActive(true);
	#endif
	}
	public static Main Instance
	{
		get
		{
			return mInstance;
		}
	}
	void Start()
	{
		#if UNITY_EDITOR
			game = GameObject.Find("Game").GetComponent<Game>();
		#endif
		Events.AddWorld += AddWorld;
	}
	void AddWorld(Transform target, Vector3 pos, Quaternion rot)
	{
		Camera cam = cam_android;

	#if UNITY_IOS
		cam = cam_ios;
	#endif
		game = Instantiate(game_to_instantiate, pos,rot);
		game.Init ();

		game.transform.LookAt(cam.transform);
		game.transform.rotation = Quaternion.Euler(0.0f, game.transform.rotation.eulerAngles.y, game.transform.rotation.z);

		// Make Andy model a child of the anchor.
		game.transform.parent = target;
	}
	public Camera GetCamera()
	{
		#if UNITY_EDITOR
			return debugCam;
		#elif UNITY_IOS
			return cam_ios;
		#else
			return cam_android;
		#endif
	}

}
