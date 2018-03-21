using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour {

	public float speed;
	public AnimalAsset asset;

	float miniumDist = 0.01f;

	public Transform[] targetPhotoParts;

	bool isInTarget;

	public enum states
	{
		IDLE,
		MOVEING
	}
	public states state;
	public void Init()
	{		
		Idle ();
	}

	void Update()
	{
		if (state == states.IDLE)
			return;
	}
	void Idle ()
	{
		state = states.IDLE;
		Invoke ("Move", 3);
		asset.Idle ();
	}
	void Move()
	{
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
