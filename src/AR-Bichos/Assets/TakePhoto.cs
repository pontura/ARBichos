using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePhoto : MonoBehaviour {

	public RenderTexture rt;

	public void SetOn()
	{
		Game.Instance.cam.targetTexture = rt;
		Invoke("SetOff", 0.1f);
	}
	void SetOff()
	{
		Game.Instance.cam.targetTexture = null;
	}
}
