using UnityEngine;
using System.Collections;

public class asdf : MonoBehaviour {

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.GetComponent<Player> () != null) {
			coll.gameObject.GetComponent<Player> ().vida = 10;
			LevelManager.levelManager.ChangeScene(coll.gameObject.GetComponent<Player>(),"Cena02");
		}
	}
}
