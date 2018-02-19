using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {

	public float escapeSpeed;
	public float speed;
	PathsWalkable paths;
	public AnimalAsset asset;

	PathWalkable pathDestination;
	PathWalkable myPath;
	float miniumDist = 0.01f;

	public Transform front;
	public Transform back;
	bool isInTarget;

	public enum states
	{
		RUNNING,
		ALERT,
		IDLE
	}
	public states state;
	public void Init()
	{
		
		Idle ();
		paths = Game.Instance.paths;
		pathDestination = paths.GetRandomTarget (null);
	}
	void Move()
	{
		state = states.RUNNING;
		if (isInTarget) {
			asset.Run ();
		}
		else
			asset.Walk ();
		myPath = pathDestination;
		pathDestination = paths.GetRandomTarget (myPath);
		transform.position = myPath.transform.position;
		GetNextPath ();	
	}
	void Update()
	{
		if (myPath == null || state == states.IDLE || state == states.ALERT)
			return;
		if (Vector3.Distance (transform.position, pathDestination.transform.position) < miniumDist) {
			Move ();
			return;
		}
		if (Vector3.Distance (transform.position, myPath.transform.position) <  miniumDist) {
			GetNextPath ();		
		} else {
			transform.LookAt (myPath.transform);
			float realSpeed = speed;
			if (isInTarget)
				realSpeed = escapeSpeed;
			transform.Translate (transform.forward * (Time.deltaTime * (realSpeed/10)), Space.World );
		}
	}
	void GetNextPath ()
	{
		myPath = paths.GetNearPathFromTo (myPath, pathDestination);
	}
	void Idle ()
	{
		state = states.IDLE;
		Invoke ("Run", Random.Range(10,40)/10);
		asset.Idle ();
	}
	void Run()
	{		
		Move ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (isInTarget)
			return;
		if (other.tag == "Eyes") {
			isInTarget = true;
			//transform.LookAt (Game.Instance.cam.transform);
			CancelInvoke ();
			state = states.ALERT;
			Invoke ("Espace", 0.3f);
			Game.Instance.animalsManager.SetInTarget (this, true);
			asset.SetInTarget (true);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Eyes") {
			isInTarget = false;
			Invoke ("OutOfDanger", 4);
			Game.Instance.animalsManager.SetInTarget (this, false);
			asset.SetInTarget (false);
		}
	}
	void Espace()
	{
		state = states.RUNNING;
		pathDestination = paths.GetFarAwayTarget (myPath);
		GetNextPath ();	
	}
	void OutOfDanger()
	{
		if (isInTarget)
			return;
		state = states.RUNNING;
		asset.Walk ();
		pathDestination = paths.GetRandomTarget (myPath);
		GetNextPath ();	
	}
}
