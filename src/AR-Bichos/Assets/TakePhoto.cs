using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePhoto : MonoBehaviour {

	//public RenderTexture[] all;
	int id;
	public UIPanels uiPanels;

	public void SetOn()
	{
		SavePhoto ();
		Invoke("SetOff", 0.1f);
		uiPanels.uiTimer.NewPhotoTaken ();
	}
	void SavePhoto()
	{
		RenderTexture rt = new RenderTexture (1024, 768, 16, RenderTextureFormat.ARGB32);
		rt.Create ();
		Main.Instance.GetCamera().targetTexture = rt;
		Data.Instance.photosManager.AddPhoto (rt);
		id++;
	}
	void SetOff()
	{
		Main.Instance.GetCamera().targetTexture = null;
	}
}
