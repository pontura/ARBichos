using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public AnimalsManager animalsManager;
	public TakePhoto takePhoto;
	Game game;

	void Start()
	{
		game = GetComponent<Game> ();
	}
	void Update () {
		
		if (game.state == Game.states.WAITING)
			return;
		
		if (Input.GetMouseButtonDown (0)) {
			UIPanels.Instance.flash.SetOn ();
			takePhoto.SetOn ();
			UIPanels.Instance.showPhoto.SetOn ();
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
		Vector3 from = Main.Instance.GetCamera().transform.position;
		Transform[] allParts = animal.targetPhotoParts;

		int seenBy = allParts.Length;
		foreach (Transform t in allParts) {
			
			if(Physics.Raycast(from, (t.position - from	), out hit, maxRange))
			{
				if (hit.transform.tag != "photoPart") {
					seenBy--;
					Debug.DrawRay (from, (t.position  - from), Color.red);
				} else {
					Debug.DrawRay(from, (t.position  - from	), Color.green);
				}
			}
		}

		return;
		//print("seenBy: " + seenBy + " of " + allParts.Length);

		if (seenBy==2) {
			animal.asset.SetTargetActive (true);
			//	Debug.DrawRay (from, (animal.transform.position - from), Color.green);
		} else {
			animal.asset.SetTargetActive (false);
			//Debug.DrawRay(from, (animal.transform.position - from	), Color.red);
		}

//
//		Vector3 to1 = animal.front.transform.position;
//		Vector3 to2 = animal.back.transform.position;
//
//		int seenBy = 0;
//		if(Physics.Raycast(from, (to1 - from	), out hit, maxRange))
//		{
//			if (hit.transform.name == "floor") {
//				seenBy++;
//				Debug.DrawRay (from, (to1 - from), Color.green);
//			}else {
//				Debug.DrawRay(from, (to1 - from	), Color.red);
//			}
//
//		}
//		if(Physics.Raycast(from, (to2 - from	), out hit, maxRange))
//		{
//			if (hit.transform.name == "floor") {
//				seenBy++;
//				Debug.DrawRay (from, (to2 - from), Color.green);
//			}
//			else {
//				Debug.DrawRay(from, (to2 - from	), Color.red);
//			}
//
//		}
//		if (seenBy==2) {
//			animal.asset.SetTargetActive (true);
//		//	Debug.DrawRay (from, (animal.transform.position - from), Color.green);
//		} else {
//			animal.asset.SetTargetActive (false);
//			//Debug.DrawRay(from, (animal.transform.position - from	), Color.red);
//		}
			
	}
}
