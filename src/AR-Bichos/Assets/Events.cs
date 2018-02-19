using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Events {
	
	public static System.Action<Vector3, Quaternion> AddWorld = delegate { };
	public static System.Action<string> DebugText = delegate { };

}
