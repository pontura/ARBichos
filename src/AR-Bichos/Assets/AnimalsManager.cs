using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsManager : MonoBehaviour {

	public int total;
	public Animal animal;
	public List<Animal> all;
	public List<Animal> inTarget;
	public Transform container;

	public void Init () {
		for (int a = 0; a < total; a++) {
			Animal newAnimal = Instantiate (animal);	
			newAnimal.transform.SetParent (container);
			newAnimal.transform.localScale = Vector3.one;
			newAnimal.Init ();
		}
	}
	public void SetInTarget(Animal animal, bool isInTarget)
	{
		if (isInTarget && IsInTarget(animal) == false)
			inTarget.Add (animal);
		else if( IsInTarget(animal))
			inTarget.Remove (animal);
	}
	bool IsInTarget(Animal animal)
	{
		foreach (Animal a in inTarget) {
			if (a == animal)
				return true;
		}
		return false;
	}
}
