using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarraAtaqueEspecial : MonoBehaviour {

	public Player player;
	public RectTransform barraDeAtaqueEspecial;

	void Start () {

	}

	void Update () {
		Vector2 barra = new Vector2(1 - (player.vidaCount/player.vida), 1);
		barraDeAtaqueEspecial.anchorMax = barra;
	}
}