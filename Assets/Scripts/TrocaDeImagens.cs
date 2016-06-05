using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrocaDeImagens : MonoBehaviour {
	public Image 	tela;
	public Sprite[] imagens 	= new Sprite[4];
	public Text 	textoNaTela;
	private int 	cont;
	public string[] textos 		= new string[4];
	// Use this for initialization
	void Start () {
		cont = 0;
		tela.sprite = imagens [0];
		textoNaTela.text = textos [0];
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			cont++;
			tela.overrideSprite = imagens [cont];
			textoNaTela.text = textos [cont];
			if (cont > 4) {
				UnityEngine.Application.LoadLevel ("naosei");
			}
			
		} else if (Input.GetKeyDown (KeyCode.LeftArrow) && cont > 0) {
			cont--;
			tela.sprite = imagens [cont];
			textoNaTela.text = textos [cont];
			
		}
		
	}
}
