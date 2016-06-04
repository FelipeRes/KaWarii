using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int vida;
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

	void Start () {
		anim = this.GetComponent<Animator> ();
	}

	void Update () {
		Vector3 v = Vector3.zero;


		if (!isWait) {
			v = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			transform.Translate (v * Time.deltaTime * velocity);
		
		}
		Vector3 look = this.transform.position + v;
		look.x += (Input.GetAxis ("Horizontal"));
		look.z += (Input.GetAxis ("Vertical"));
		lookPoint.transform.position = look;
		modelo.transform.LookAt (lookPoint);

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
		atackCount = 0;
	}
	public void Atack(){
		if (canAtack && atackCount < ataqueObject.Length) {
			isWait = true;
			GameObject ataqueInstancia = Instantiate (ataqueObject [atackCount], ataquePoint.position, Quaternion.identity) as GameObject;
			ataqueInstancia.GetComponent<Ataque> ().player = this.gameObject;
			//anim.Play (ataqueInstancia.GetComponent<Ataque>().animatorPlay);
			Invoke ("Return", tempo);
			canAtack = false;
			Invoke ("PodeAtacar", tempo);
			atackCount++;
			Invoke ("ZerarAtackCount", tempo);
		}
	}

	public void adicionarDano(int dano){
		vida -= dano;
	}
}