using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {

	void Awake (){
		targetPosition = transform.localPosition;
		controller = GameObject.Find ("Controller").GetComponent<Controller>();
	}

	// Use this for initialization
	void Start () {
		updateLetter ();
//		targets = GameObject.Find ("Targets").transform;
//		sources = GameObject.Find ("Sources").transform;
	}
//	private Transform targets, sources;
	private Controller controller;
	public float speed = 1;

	// Update is called once per frame
	void Update () {
		updateLetter ();

		float delta = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, delta);
	}

	void OnValidate(){
		updateLetter ();
	}
		
	private Vector3 targetPosition;
	public void gotoPos(float x, float y) {
		targetPosition = new Vector3 (x,y,0);
	}

	public void gotoTarget(int i) {
		Transform child = controller.targets.GetChild (i);
		gotoPos (child.position.x, child.position.y);
	}

	public void gotoSource(int i) {
		Transform child = controller.sources.GetChild (i);
		gotoPos (child.position.x, child.position.y);
	}

	public char letter = 'A';
	public UnityEngine.U2D.SpriteAtlas spriteAtlas;
	public Sprite errorSprite;

	void updateLetter () {
		if (letter != previousLetter) {
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
			spriteRenderer.sprite = spriteAtlas.GetSprite(letter.ToString());
			if (spriteRenderer.sprite==null) spriteRenderer.sprite = errorSprite;
			previousLetter = letter;
		}
	}


	private char previousLetter='\x00';
}
