using UnityEngine;
using System.Collections;

public class Otome : Inimigo {
	public float distanciaDeFuga;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		if (!isWait) {
			transform.LookAt (player.transform.position);
			distancia = Vector3.Distance (this.transform.position, player.transform.position);
			if (distancia < distanciaDeFuga) {
				transform.Translate (Vector3.back * velocidade * Time.deltaTime);
			}else if (distancia > alcanceDeAtaque) {
				transform.Translate (Vector3.forward * velocidade * Time.deltaTime);
			} else if (distancia <= alcanceDeAtaque && canAtack) {
				atacar ();
			}
		}
	}
	override public void atacar()	{
		canAtack = false;
		Debug.Log ("atacou");
		Invoke ("podeAtacar", tempoDeAtaque);
		//player.GetComponent<Player> ().adicionarDano (1);
		GameObject ataque_Instance = Instantiate (ataque, ataquePoint.position, Quaternion.identity) as GameObject;
		ataque_Instance.transform.rotation = this.transform.rotation;
	}

}
