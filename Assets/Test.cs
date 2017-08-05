using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public Letter a;
	public Letter b;
	public Letter c;
	public Letter d;

	public float radius = 5;
	public float wait = .5f;

	IEnumerator test(){
		while (true) {
			Vector2 pos = Random.insideUnitCircle * radius;
			Letter l = letters [Random.Range (0, letters.Length)];
			l.gotoPos (pos.x, pos.y);
			yield return new WaitForSeconds(wait);
		}
	}
	IEnumerator test2(){
		yield return new WaitForSeconds(wait);
		a.gotoTarget (1);
		yield return new WaitForSeconds(wait);
		b.gotoTarget (2);
		yield return new WaitForSeconds(wait);
		c.gotoTarget (0);
		yield return new WaitForSeconds(wait);
		d.gotoSource (1);
	}

	private Letter[] letters;

	// Use this for initialization
	void Start () {
		letters = new Letter[] { a,b,c,d };
		StartCoroutine (test2 ());
	}

}
