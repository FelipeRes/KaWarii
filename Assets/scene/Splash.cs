using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	public float time;
	public bool start;
	// Use this for initialization
	void Start () {
		Invoke ("Comeca", time);
	}
	void Update(){
		if (start && Input.GetMouseButtonDown(0)) {
			Application.LoadLevel ("Abertura");
		}

	}
	
	void Comeca(){
		start = true;
	}
}
