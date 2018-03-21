using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Album : MonoBehaviour {

	public Text field;
	public AlbumPhoto albumPhoto;
	int id;

	void Start () {
		SetPhoto ();
	}
	public void Next() {
		if (id <= Data.Instance.photosManager.all.Count - 1) {
			id++;
			SetPhoto ();
		}
	}
	public void Prev() {
		if (id > 1) {
			id--;
			SetPhoto ();
		}
	}
	void SetPhoto ()
	{
		albumPhoto.Init (id);
		field.text = "Photo " + ((int)id + 1) + "/" + Data.Instance.photosManager.all.Count;
	}
	public void Done()
	{
		Data.Instance.LoadLevel ("Intro");
	}
}
