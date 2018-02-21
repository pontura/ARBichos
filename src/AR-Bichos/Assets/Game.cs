using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static Game mInstance;
	public Camera cam;
	public GameObject eyeFocus;
	public PathsWalkable paths;
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
		paths.Init ();
		animalsManager.Init ();
	}
//	void Update () {
//
//		return;
//
//
//
//
//
//
//
//		if (state == states.WAITING)
//			return;
//		
//		RaycastHit[] hits;
//		hits = Physics.RaycastAll(cam.transform.position, cam.transform.forward, 100.0F);
//
//		for (int i = 0; i < hits.Length; i++)
//		{
//			RaycastHit hit = hits[i];
//			if(hit.transform.gameObject.name == "floor")
//				eyeFocus.transform.position = hit.point;
//		}
//	}
}
