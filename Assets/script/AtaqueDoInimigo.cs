using UnityEngine;
using System.Collections;

public class AtaqueDoInimigo : MonoBehaviour {
	public int forca;
	public float tempo;
	public float tempoDecorrido;
	public Inimigo inimigo;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		tempoDecorrido += Time.deltaTime;
		if (tempoDecorrido >= tempo) {
			inimigo.podeAtacar ();
			Destroy(this.gameObject);
		}
	
	}
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.GetComponent<Player> () != null) {
			coll.gameObject.GetComponent<Player> ().adicionarDano (forca);
		}
	}

}
