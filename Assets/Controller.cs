using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public Transform targets, sources, letters;

	void Start () {
		Debug.Assert (targets.childCount == numLetters);
		Debug.Assert (sources.childCount == numLetters);
		Debug.Assert (letters.childCount == numLetters);
		ResetLetters ();
	}

	public const int numLetters = 6;
	private LinkedList<Letter> lettersInTarget = new LinkedList<Letter>();
	private Letter[] lettersInSource = new Letter[numLetters];

	/** Moves all letters into the source positions */
	void ResetLetters () {
		lettersInTarget.Clear ();

		for (int i = 0; i < numLetters; i++) {
			lettersInSource [i] = letters.GetChild (i).gameObject.GetComponent<Letter> ();
			lettersInSource [i].gotoSource (i);
		}
	}

	void Backspace (){
		if (lettersInTarget.Count == 0)
			return;
		Letter lastLetter = lettersInTarget.Last.Value;
		lettersInTarget.RemoveLast ();
		MoveToSource (lastLetter);
	}

	/** MoveToSource moves a letter to the first available slot in lettersInSource, and performs the
	 * necessary updates in the graphics.
	 * 
	 * Warning: MoveToSource does not remove the letter from lettersInTarget, you need to remove it from LettersInTarget
	 * yourself when calling MoveToSource. */
	void MoveToSource (Letter letter){
		for (int i = 0; i < numLetters; i++)
			if (lettersInSource [i] == null) {
				lettersInSource [i] = letter;
				letter.gotoSource (i);
				break;
			}	
	}

	void Enter (){
		if (lettersInTarget.Count == 0)
			return;
		
		string word="";
		foreach (Letter letter in lettersInTarget) {
			word = word + letter.letter;
		}
		print ("The word is " + word);

		foreach (Letter letter in lettersInTarget) {
			MoveToSource (letter);
		}
		lettersInTarget.Clear ();
	}
	void LetterKeyPress (char key){
		for (int i = 0; i < numLetters; i++) {
			Letter letter = lettersInSource [i];
			if (letter != null && letter.letter == key) {
				lettersInSource [i] = null;
				lettersInTarget.AddLast (letter);
				letter.gotoTarget (lettersInTarget.Count - 1);
				break;
			}
		}
	}

	void Update () {
		foreach (char key in Input.inputString) {
			if (key >= 'A' && key <= 'Z')
				LetterKeyPress (key);
			else if (key >= 'a' && key <= 'z')
				LetterKeyPress (System.Char.ToUpper (key));
			else if (key == 8)
				Backspace ();
			else if (key == 13)
				Enter ();
			else
				print ("Unknown key: " + key+" "+System.Convert.ToInt32(key));
		}
	}
}
