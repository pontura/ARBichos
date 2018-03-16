using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
	
	public static System.Action<Transform, Vector3, Quaternion> AddWorld = delegate { };
	public static System.Action<string> DebugText = delegate { };
	public static System.Action<ConfigScreens.states> ConfigSetState = delegate { };
}
