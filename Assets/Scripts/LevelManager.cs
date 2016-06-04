using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameManager gameManager;
	public Player player;
	public static LevelManager levelManager;

	void Awake(){
		gameManager = FindObjectOfType<GameManager> ();
		player = FindObjectOfType<Player> ();
	}

	// Use this for initialization
	void Start () {
		levelManager = this.GetComponent<LevelManager>();
		if (player != null) {
			gameManager.player = player;
		} else {
			print ("Player Not Found");
		}
		
	}
	public void CallGameOver(){
		
	}
	public void ChangeScene(Player player, string scene){
		gameManager.player = player;
		Application.LoadLevel (scene);
	}
}
