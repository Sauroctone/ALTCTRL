using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationList : MonoBehaviour {

	public List<string> list = new List<string>();
	public List<string> listHard = new List<string>();

	int currentLine;
	string firstInput;
	string secondInput;
	string thirdInput;
	string fourthInput;
	bool hasPressed;

	public List<AudioClip> feedbackList = new List<AudioClip>();
	public AudioSource audioSource;
	public AudioClip intro;
	public AudioClip success;

	public List<AudioClip> instructions = new List<AudioClip> ();
	public List<AudioClip> instructionsHard = new List<AudioClip> ();

	bool skip;
	bool introIsDone;

	void Start ()
	{
		audioSource.PlayOneShot (intro);

		StartCoroutine (WaitForIntro());
	}

	void Update ()
	{
		if (introIsDone) 
		{
			if (list.Count > 0)
				TestInputThree ();
			else if (listHard.Count > 0)
				TestInputFour ();
		}

		if (!introIsDone && !skip && Input.anyKeyDown) 
		{
			skip = true;
			audioSource.Stop ();
		}
	}

	void TestInputThree()
	{
		if (!hasPressed && Input.GetButton (firstInput) && Input.GetButton (secondInput) && Input.GetButton (thirdInput)) 
		{
			hasPressed = true;
			audioSource.PlayOneShot (feedbackList[Mathf.FloorToInt(Random.Range(0, feedbackList.Count))]);
			print ("Great success!");
			list.RemoveAt (currentLine);

			if (list.Count > 0)
				StartCoroutine (ChooseCombinationThree ());
			else 
				StartCoroutine (ChooseCombinationFour ());
		}
	}

	void TestInputFour ()
	{
		if (!hasPressed && Input.GetButton (firstInput) && Input.GetButton (secondInput) && Input.GetButton (thirdInput) && Input.GetButton (fourthInput)) 
		{
			hasPressed = true;
			audioSource.PlayOneShot (feedbackList[Mathf.FloorToInt(Random.Range(0, feedbackList.Count))]);
			print ("Great success!");
			listHard.RemoveAt (currentLine);

			if (listHard.Count > 0)
				StartCoroutine (ChooseCombinationFour ());
			else
				Success ();
		}
	}

	void Success()
	{
		audioSource.PlayOneShot (success);
		print ("Enfin !");
	}

	IEnumerator WaitForIntro()
	{
		while (audioSource.isPlaying && !skip) 
		{
			yield return null;
		}

		StartCoroutine (ChooseCombinationThree ());
	}

	IEnumerator ChooseCombinationThree ()
	{
		yield return new WaitForSeconds (2);

		if (!introIsDone)
			introIsDone = true;

		currentLine = Mathf.FloorToInt (Random.Range (0, list.Count));
		firstInput = list [currentLine].Substring(0, 4); 
		secondInput = list [currentLine].Substring(4, 4); 
		thirdInput = list [currentLine].Substring(8, 4); 
		audioSource.PlayOneShot (instructions [currentLine]);
		print ("Press " + firstInput + " and " + secondInput + " and " + thirdInput);
		hasPressed = false;
	}

	IEnumerator ChooseCombinationFour ()
	{
		yield return new WaitForSeconds (2);
		currentLine = Mathf.FloorToInt (Random.Range (0, listHard.Count));
		firstInput = listHard [currentLine].Substring(0, 4); 
		secondInput = listHard [currentLine].Substring(4, 4); 
		thirdInput = listHard [currentLine].Substring(8, 4); 
		fourthInput = listHard [currentLine].Substring(12, 4); 
		audioSource.PlayOneShot (instructionsHard [currentLine]);
		print ("Press " + firstInput + " and " + secondInput + " and " + thirdInput + " and " + fourthInput);
		hasPressed = false;
	}
}