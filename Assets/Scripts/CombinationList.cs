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

	void Start ()
	{
		currentLine = Mathf.FloorToInt (Random.Range (0, list.Count));
		firstInput = list [currentLine].Substring(0, 4); 
		secondInput = list [currentLine].Substring(4, 4); 
		thirdInput = list [currentLine].Substring(8, 4); 
		print ("Press " + firstInput + " and " + secondInput + " and " + thirdInput);
	}

	void Update ()
	{
		if (list.Count > 0)
			TestInputThree ();
		
		else if (listHard.Count > 0)
			TestInputFour ();
	}

	void TestInputThree()
	{
		if (!hasPressed && Input.GetButton (firstInput) && Input.GetButton (secondInput) && Input.GetButton (thirdInput)) 
		{
			hasPressed = true;
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
			print ("Great success!");
			listHard.RemoveAt (currentLine);

			if (listHard.Count > 0)
				StartCoroutine (ChooseCombinationFour ());
		}
	}

	IEnumerator ChooseCombinationThree ()
	{
		yield return new WaitForSeconds (2);
		currentLine = Mathf.FloorToInt (Random.Range (0, list.Count));
		firstInput = list [currentLine].Substring(0, 4); 
		secondInput = list [currentLine].Substring(4, 4); 
		thirdInput = list [currentLine].Substring(8, 4); 
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
		print ("Press " + firstInput + " and " + secondInput + " and " + thirdInput + " and " + fourthInput);
		hasPressed = false;
	}
}