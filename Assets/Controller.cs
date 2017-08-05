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
	private List<Letter> lettersInTarget = new List<Letter>();
	private Letter[] lettersInSource = new Letter[numLetters];

	/** Moves all letters into the source positions */
	void ResetLetters () {
		lettersInTarget.Clear ();

		for (int i = 0; i < numLetters; i++) {
			lettersInSource [i] = letters.GetChild (i).gameObject.GetComponent<Letter> ();
			lettersInSource [i].gotoSource (i);
		}
	}

	void Update () {
		foreach (char letter in Input.inputString) {
			print ("Key press: " + letter);
		}
	}
}
