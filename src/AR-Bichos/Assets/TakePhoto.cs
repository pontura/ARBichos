using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePhoto : MonoBehaviour {

	public RenderTexture rt;

	public void SetOn()
	{
		Main.Instance.GetCamera().targetTexture = rt;
		Invoke("SetOff", 0.1f);
	}
	void SetOff()
	{
		Main.Instance.GetCamera().targetTexture = null;
	}
}
