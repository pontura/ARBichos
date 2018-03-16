using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {

	public float speed;
	public AnimalAsset asset;

	float miniumDist = 0.01f;

	public Transform[] targetPhotoParts;

	bool isInTarget;
	public PathsWalkable pathsWalkable;

	public enum states
	{
		IDLE,
		MOVEING
	}
	public states state;
	public void Init()
	{		
		Idle ();
		//pathsWalkable.Init (this.transform.position);
	}

	void Update()
	{
		if (state == states.IDLE)
			return;
//		if (Vector3.Distance (transform.position, pathsWalkable.goTo.transform.position) < miniumDist) {
//			Idle ();
//		} else {
//			transform.LookAt (pathsWalkable.goTo.transform);
//			float realSpeed = speed;
//			transform.Translate (transform.forward * (Time.deltaTime * (realSpeed / 10)), Space.World);
//		}
	}
	void Idle ()
	{
		state = states.IDLE;
		Invoke ("Move", 3);
		asset.Idle ();
	}
	void Move()
	{
		pathsWalkable.SetNewPath ();
		state = states.MOVEING;
		asset.Walk ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (isInTarget)
			return;
		if (other.tag == "Eyes") {
			isInTarget = true;
			CancelInvoke ();
			Main.Instance.game.animalsManager.SetInTarget (this, true);
			asset.SetInTarget (true);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Eyes") {
			isInTarget = false;
			Main.Instance.game.animalsManager.SetInTarget (this, false);
			asset.SetInTarget (false);
		}
	}

}
