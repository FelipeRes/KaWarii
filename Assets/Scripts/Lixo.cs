using UnityEngine;
using System.Collections;

public class Lixo : MonoBehaviour {
	public float fatorDeAumentoDeEsplosao;
	public Vector3 direcaoDaEsplosao;
	private Rigidbody corpo;

	// Use this for initialization
	void Start () {
		corpo = this.GetComponent<Rigidbody> ();
	}
	

	public void esplodindo(int forcaDeEsplosao){
		this.transform.parent = null;
		corpo.AddForce (direcaoDaEsplosao * forcaDeEsplosao*fatorDeAumentoDeEsplosao);
		Debug.Log ("funciona " + name);
	}

}
