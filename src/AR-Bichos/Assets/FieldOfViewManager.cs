using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewManager : MonoBehaviour {

	public FieldOfViewVisualizer visualizer;
	public Vector2 scaleFactorSubCamera;
	public Vector2 offsetSubCamera;

	void Start () {
		visualizer = GetComponent<FieldOfViewVisualizer> ();
	}

	void Update () {
		visualizer.scaleFactorSubCamera = scaleFactorSubCamera;
		visualizer.offsetSubCamera = new Vector2(offsetSubCamera.x*Screen.width, offsetSubCamera.y*Screen.height);
	}
}
