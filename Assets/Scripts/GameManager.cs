using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Player player;
	public int value;


	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}
		
	void Start () {
	
	}

	void Update () {
		
	}
}
