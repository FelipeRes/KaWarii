using UnityEngine;
using System.Collections;

public class MonteDeLixo : MonoBehaviour {
	public int 			forcaDaEsplosao;
	private bool 		esplodiu 		= false;
	public GameObject[] objeto 			= new GameObject[4];
	public float 		tempoDeDetruicao;
	public GameObject 	powerUp;

	// Use this for initialization

	// Update is called once per frame
	public void esplosao(){
		if (!esplodiu) {
			esplodiu = true;
			for (int cont = 0; cont < 4; cont++) {
				if(objeto [cont] != null){
					objeto [cont].GetComponent<Lixo> ().esplodindo (forcaDaEsplosao);
				}
			}
			Invoke ("autoDestruicao", tempoDeDetruicao);
			GameObject instantiate = GameObject.Instantiate (powerUp, transform.position, Quaternion.identity) as GameObject;

		}
	}
	void autoDestruicao(){
		Destroy (this.gameObject);
	}
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.GetComponent<Ataque>() != null) {
			Debug.Log ("OI");
			esplosao ();
		}
	}
}
