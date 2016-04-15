using UnityEngine;
using System.Collections;

public class ConfigurarFase : MonoBehaviour {

	public GameObject retornaPontoDePartida;
	private Jogador jogador;

	// Use this for initialization
	void Start () {
		jogador = FindObjectOfType<Jogador> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResertarJogador(){
		jogador.transform.transform.position = retornaPontoDePartida.transform.position;
	}
}