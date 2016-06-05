using UnityEngine;
using System.Collections;

public class LataDeLixo : MonoBehaviour {
	public GameObject 	powerUp;
	public Animator 	anim;
	public string 		NomeDaAnimaçao;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void levarDano(){
		GameObject instatiatePowerUp = GameObject.Instantiate (powerUp, transform.position, Quaternion.identity) as GameObject;
		anim.Play (NomeDaAnimaçao);
		Destroy (this.gameObject);
	}
}
