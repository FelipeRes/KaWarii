using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarraDeFofura : MonoBehaviour {

	public Player player;
	public RectTransform barraDeFofura;

	void Start () {

	}

	void Update () {
		Vector2 barra = new Vector2(1f - (player.vidaCount/player.vida), 1);
		barraDeFofura.anchorMax = barra;
	
	}
}