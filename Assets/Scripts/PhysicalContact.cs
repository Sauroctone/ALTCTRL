using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalContact : MonoBehaviour {

	public GameObject listManager;
	public AudioClip failure;
	public AudioSource audioSource;

	void Update () 
	{
		if (Input.GetKey (KeyCode.Space))
		{
			audioSource.Stop ();
			audioSource.PlayOneShot (failure);
			Destroy (listManager);
			print ("Le courant passe !");
		}
	}
}