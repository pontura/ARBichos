using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotosManager : MonoBehaviour {

	public List<RenderTexture> all;

	public void AddPhoto(RenderTexture rt) {
		all.Add(rt);	
	}
	public RenderTexture GetLast()
	{
		return all [all.Count - 1];
	}

}
