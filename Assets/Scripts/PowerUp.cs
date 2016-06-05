using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	public int curaDeVida;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.GetComponent<Player> () != null) {
			coll.gameObject.GetComponent<Player> ().curar (curaDeVida);
			Destroy (this.gameObject);
		}
	}
}
