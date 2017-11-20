using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalContact : MonoBehaviour {

	public GameObject listManager;

	void Update () 
	{
		if (Input.GetKey (KeyCode.Space))
		{
			Destroy (listManager);
			print ("Le courant passe !");
		}
	}
}