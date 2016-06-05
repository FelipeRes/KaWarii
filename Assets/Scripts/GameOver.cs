using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


	public GameObject gameOverScreen;
	public Player player;
	void Start(){
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}
	void Update(){
		if (player.vidaCount <= 0) {
			CallGameOver ();
		}
	}


	public void CallGameOver(){
		gameOverScreen.SetActive (true);
	}
}
