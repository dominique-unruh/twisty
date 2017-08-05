using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public Transform targets, sources, letters;

	// Use this for initialization
	void Start () {
		Debug.Assert (targets.childCount == numLetters);
		Debug.Assert (sources.childCount == numLetters);
		Debug.Assert (letters.childCount == numLetters);
	}

	public const int numLetters = 6;
	private List<Letter> lettersInTarget = new List<Letter>();
	private Letter[] lettersInSource = new Letter[numLetters];

	// Update is called once per frame
	void Update () {
		foreach (char letter in Input.inputString) {
			print ("Key press: " + letter);
		}
	}
}
