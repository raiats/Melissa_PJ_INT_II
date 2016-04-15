using UnityEngine;
using System.Collections;

public class MatarJogador : MonoBehaviour {

	public ConfigurarFase config_Fase;

	// Use this for initialization
	void Start () {
		config_Fase = FindObjectOfType<ConfigurarFase> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D colidir){
		if(colidir.name == "Jogador"){
			config_Fase.ResertarJogador ();  
		}
	}
}
