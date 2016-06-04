using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {
	public int 			vida;
	public GameObject 	player;
	public GameObject 	ataque;
	public int 			velocidade;
	public float 		alcanceDeAtaque;
	public float 		distancia;
	public bool 		canAtack = true;
	public int 			pontosEspecial;



	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform.position);
		distancia = Vector3.Distance (this.transform.position, player.transform.position);
		if (distancia > alcanceDeAtaque) {
			transform.Translate (Vector3.forward * velocidade * Time.deltaTime);
		}else if (distancia <= alcanceDeAtaque && canAtack) {
			atacar ();
		}
	}
	public void adicionarDano(int dano){
		vida = vida - dano;
		if (vida <= 0) {
			morrer ();
		}
	}
	public void atacar(){
		canAtack = false;
		Debug.Log ("atacou");
		Instantiate (ataque);
	}
	public void podeAtacar(){
		canAtack = true;
	}
	public void morrer(){
		//FALTA A FUNÇAO DE ADICIONAR ESPECIAL AO PLAYER
		Destroy(this.gameObject);
	}
}