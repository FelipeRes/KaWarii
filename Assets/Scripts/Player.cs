using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int vida;
	public int especial;
	public Animator anim;

	public Renderer capa;
	public GameObject ataqueObject;
	public int velocidade;
	public int força;
	public bool isWait;

	public GameObject modelo;
	public Transform lookPoint;

	void Start () {

	}

	void Update () {
		Vector3 v = Vector3.zero;

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


	public void Return(){
		isWait = false;
	}

}