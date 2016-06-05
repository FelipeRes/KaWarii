using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float vidaCount;
	public float vida;
	public int espcialCount;
	public int especial;
	public float velocity = 3f;
	public Animator anim;

	public Renderer capa;
	public GameObject[] ataqueObject;
	public int força;
	public bool isWait;

	public GameObject modelo;
	public Transform lookPoint;

	public bool canAtack;
	public int atackCount;

	public float tempo;

	public Transform ataquePoint;
	public ParticleSystem particle;

	void Start () {
		//anim = this.GetComponent<Animator> ();
		vidaCount = vida;
		espcialCount = 0;
	}

	void Update () {
		particle.emissionRate = (int)(vida - vidaCount);
		particle.maxParticles = (int)(vida - vidaCount);
		if (!isWait) {
			Vector3 v = Vector3.zero;
			if (canAtack) {
				v = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
				this.transform.Translate (v*velocity*Time.deltaTime);
				Vector3 look = this.transform.position + v;
				look.x += (Input.GetAxis ("Horizontal"));
				look.z += (Input.GetAxis ("Vertical"));
				lookPoint.transform.position = look;
				modelo.transform.LookAt (lookPoint);

				if (v.x > 0.1 || v.x < -0.1 || v.z > 0.1 || v.z < -0.1) {
					anim.SetBool ("Walk", true);
				} else {
					anim.SetBool ("Walk", false);
				}
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			Atack ();
		}

		}

	public void PodeAtacar(){
		canAtack = true;
	}
	public void Return(){
		isWait = false;
	}
	public void ZerarAtackCount(){
		if (canAtack == true) {
			atackCount = 0;
		}
	}
	public void AdicionarEspecial(int valor){
		especial += valor;
	
	}
	public void curar(int lixeiro){
		vidaCount += lixeiro;
		if (vida < vidaCount) {
			vidaCount = vida;
		}
	
	}
	public void Atack(){
		if (canAtack && atackCount < ataqueObject.Length) {
			isWait = true;
			GameObject ataqueInstancia = Instantiate (ataqueObject [atackCount], ataquePoint.position, ataquePoint.transform.rotation) as GameObject;
			Ataque ataque = ataqueInstancia.GetComponent<Ataque> ();
			ataque.player = this.gameObject;
			anim.Play (ataqueInstancia.GetComponent<Ataque>().animatorPlay);
			Invoke ("Return", ataque.tempo);
			canAtack = false;
			Invoke ("PodeAtacar",  ataque.tempoCombo);
			atackCount++;
			Invoke ("ZerarAtackCount", tempo);
		}
	}

	public void adicionarDano(int dano){
		//isWait = true;
		//Invoke ("Return",dano/2);
		if (vidaCount > 0) {
			vidaCount -= dano;
		}
		espcialCount -= 10;
	}
}