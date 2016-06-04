using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int vida;
	public int especial;
	public Animator anim;

	public Renderer capa;
	public GameObject[] ataqueObject;
	public int velocidade;
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

		if (Input.GetMouseButtonDown (0)) {
			Atack ();
		}

		if (!isWait) {
			v = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			transform.Translate (v * Time.deltaTime);
		
		}
			Vector3 look = this.transform.position;
			look.x += (Input.GetAxis ("Horizontal"));
			look.z += (Input.GetAxis ("Vertical"));
			lookPoint.transform.position = look;
		if (v.x > 0.1f && v.x < - 0.1f) {
				modelo.transform.LookAt (lookPoint);
		} else if (v.z > 0.1f && v.z < - 0.1f) {
				modelo.transform.LookAt (lookPoint);
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
			anim.Play (ataqueInstancia.GetComponent<Ataque>().animatorPlay);
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