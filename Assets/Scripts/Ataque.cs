using UnityEngine;
using System.Collections;

public class Ataque : MonoBehaviour {

	public int forca;
	public float tempo;
	public float tempoCombo;
	public bool tempoOk;
	public GameObject player;
	public string animatorPlay;

	private float tempoDecorrido;


	void Start () {
	
	}
	void Update () {
		tempoDecorrido += Time.deltaTime;
		if (tempoDecorrido >= tempo) {
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.GetComponent<Inimigo> () != null) {
			coll.gameObject.GetComponent<Inimigo> ().adicionarDano(forca * player.GetComponent<Player>().força);
		}
	}
}
