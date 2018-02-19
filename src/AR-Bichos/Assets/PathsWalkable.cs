using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsWalkable : MonoBehaviour {

	public List<PathWalkable> paths;

	public void Init () {
		foreach (PathWalkable path in GetComponentsInChildren<PathWalkable>())
			paths.Add (path);
	}
	public PathWalkable GetNearPathFromTo(PathWalkable myPath, PathWalkable pathDestination)
	{
		float nearest = 1000;
		PathWalkable thePath = null;
		foreach (PathWalkable path in myPath.canWalkTo) {
			float dist = Vector3.Distance (path.transform.position, pathDestination.transform.position);
			if (dist < nearest) {
				nearest = dist;
				thePath = path;
			}
		}
		return thePath;
	}
	public PathWalkable GetRandomTarget(PathWalkable myPath)
	{
		PathWalkable p = paths [Random.Range (0, paths.Count)];
		if (myPath == null || p != myPath)
			return p;
		else
			return  GetRandomTarget (myPath);
	}
	public PathWalkable GetFarAwayTarget(PathWalkable myPath)
	{
		float faraway = 0;
		PathWalkable thePath = null;
		foreach (PathWalkable path in myPath.canWalkTo) {
			float dist = Vector3.Distance (path.transform.position, myPath.transform.position);
			if (dist > faraway) {
				faraway = dist;
				thePath = path;
			}
		}
		return thePath;
	}
}
