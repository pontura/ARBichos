using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAsset : MonoBehaviour {

	public float speed;
	float originalZ;
	void Start () {
		originalZ = transform.localPosition.z;
	}

	void Update () {
		Vector3 pos = transform.localPosition;
		pos.z += (speed/100) * Time.deltaTime;
		if (pos.z > 2)
			pos.z = originalZ;
		transform.localPosition = pos;

	}
}
