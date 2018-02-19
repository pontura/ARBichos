using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public AnimalsManager animalsManager;
	void Update () {
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

		bool isBeenSeen = false;
		if(Physics.Raycast(from, (to1 - from	), out hit, maxRange))
		{
			if (hit.transform.name == "floor") {
				Debug.DrawRay (from, (to1 - from), Color.green);
				isBeenSeen = true;

			} else {
				Debug.DrawRay(from, (to1 - from	), Color.red);
			}
		}
		if(Physics.Raycast(from, (to2 - from	), out hit, maxRange))
		{
			if (hit.transform.name == "floor") {
				Debug.DrawRay (from, (to2 - from), Color.green);
				isBeenSeen = true;
			} else {
				Debug.DrawRay(from, (to2 - from	), Color.red);
			}
		}
			
	}
}
