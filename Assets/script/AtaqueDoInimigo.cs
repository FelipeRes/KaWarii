using UnityEngine;
using System.Collections;

public class AtaqueDoInimigo : MonoBehaviour {
	public float 	tempoDeDuraçao;
	public int		dano;
	public int 		velocidade;
	void Start () {
		Destroy (this.gameObject, tempoDeDuraçao);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * velocidade * Time.deltaTime);
	
	}
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.GetComponent<Player> () != null) {
			coll.gameObject.GetComponent<Player> ().adicionarDano (dano);
			Destroy (this.gameObject);
		}
	}

}
