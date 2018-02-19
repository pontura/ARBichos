using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAsset : MonoBehaviour {

	public Animation anim;
	public SpriteRenderer sp;
	void Start()
	{
		sp.color = Color.white;
	}
	public void Walk()
	{
		//sp.enabled = false;
	//	anim.gameObject.SetActive (true);
		anim.Play ("Walk");
		sp.color = Color.white;
	}
	public void Run()
	{
		//sp.enabled = true;
		//anim.gameObject.SetActive (true);
		anim.Play ("Run");
	}
	public void Idle()
	{
		//sp.enabled = false;
		//anim.gameObject.SetActive (false);
		anim.Play ("Idle_A");
	}
	public void SetInTarget(bool isInTarget)
	{
		//sp.enabled = true;
		if(isInTarget)
			sp.color = Color.green;
		else
			sp.color = Color.red;
	}
}
