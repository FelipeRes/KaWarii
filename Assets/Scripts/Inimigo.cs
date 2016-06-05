﻿using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {
	public int 			vida;
	public GameObject 	player;
	public GameObject 	ataque;
	public Transform 	ataquePoint; 
	public int 			velocidade;
	public float 		alcanceDeAtaque;
	public float 		distancia;
	public bool 		canAtack = true;
	public int 			pontosEspecial;
	public GameObject 	blood;
	public float 		tempoDeAtaque;
	public float 		tempoDeRecuperacao;
	public Animator 	anim;


	public bool isWait;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//isRunnnig sempre comeca false mais se ele se mover fica true
		anim.SetBool ("isRunning", false);
		if (!isWait) {
			transform.LookAt (player.transform.position);
			distancia = Vector3.Distance (this.transform.position, player.transform.position);
			if (distancia > alcanceDeAtaque) {
				transform.Translate (Vector3.forward * velocidade * Time.deltaTime);
				anim.SetBool ("isRunning", true);
			} else if (distancia <= alcanceDeAtaque && canAtack) {
				atacar ();
			}
			
		}
	}
	public void adicionarDano(int dano){
		player.GetComponent<Player> ().AdicionarEspecial (1);
		isWait = true;
		Invoke ("Return", tempoDeRecuperacao);
		this.GetComponent<Rigidbody> ().AddRelativeForce (0, 300*dano, -100*dano);
		GameObject bloodObject = Instantiate (blood, this.transform.position, this.transform.rotation) as GameObject;
		Destroy (bloodObject, 5);
		Debug.Log (dano);
		vida = vida - dano;
		if (vida <= 0) {
			morrer ();
		}
	}
	public virtual void atacar(){
		anim.Play ("atacando");
		canAtack = false;
		Debug.Log ("atacou");
		Invoke ("podeAtacar", tempoDeAtaque);
		player.GetComponent<Player> ().adicionarDano (1);
		//GameObject ataque_Instance = Instantiate (ataque, ataquePoint.position, Quaternion.identity) as GameObject;
	}
	public void podeAtacar(){
		canAtack = true;
	}
	public void morrer(){
		Destroy(this.gameObject);
	}
	void Return(){
		isWait = false;
	}
}