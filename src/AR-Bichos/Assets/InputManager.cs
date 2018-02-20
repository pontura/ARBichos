using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public AnimalsManager animalsManager;
	public TakePhoto takePhoto;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			UI.Instance.flash.SetOn ();
			takePhoto.SetOn ();
			UI.Instance.showPhoto.SetOn ();
		}
		if (animalsManager.inTarget.Count > 0) {
			foreach (Animal Animal in animalsManager.inTarget)
				SetRayTo (Animal);
		}
	}
	float maxRange = 100;
	RaycastHit hit;
	void SetRayTo(Animal animal)
	{
		Vector3 from = Game.Instance.cam.transform.position;
		Vector3 to1 = animal.front.transform.position;
		Vector3 to2 = animal.back.transform.position;

		int seenBy = 0;
		if(Physics.Raycast(from, (to1 - from	), out hit, maxRange))
		{
			if (hit.transform.name == "floor") {
				seenBy++;
				Debug.DrawRay (from, (to1 - from), Color.green);
			}else {
				Debug.DrawRay(from, (to1 - from	), Color.red);
			}

		}
		if(Physics.Raycast(from, (to2 - from	), out hit, maxRange))
		{
			if (hit.transform.name == "floor") {
				seenBy++;
				Debug.DrawRay (from, (to2 - from), Color.green);
			}
			else {
				Debug.DrawRay(from, (to2 - from	), Color.red);
			}

		}
		if (seenBy==2) {
			animal.asset.SetTargetActive (true);
		//	Debug.DrawRay (from, (animal.transform.position - from), Color.green);
		} else {
			animal.asset.SetTargetActive (false);
			//Debug.DrawRay(from, (animal.transform.position - from	), Color.red);
		}
			
	}
}
