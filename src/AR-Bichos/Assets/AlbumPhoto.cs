using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumPhoto : MonoBehaviour {

	public RawImage rawImage;

	public void Init(int id) {
		rawImage.texture = Data.Instance.photosManager.all[id];
	}
}
