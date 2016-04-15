using UnityEngine;
using System.Collections;

// classe Jogador

public class Jogador : MonoBehaviour {

	// declarando variaveis

	public float andar_j = 25.0f;
	private bool direcao_Jogador = true;
	private float movimento_X;
	private Rigidbody2D rb2D;

	// variaveis relacionadas com detecção da plataforma
	public Transform verificar_Plataforma;
	float verificar_Plataforma_J = 0.2f;
	public LayerMask plataforma_ID_J;
	bool colidir_Plataforma = false;


	void Start (){
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		MovimentarJogador ();
		colidir_Plataforma = Physics2D.OverlapCircle (verificar_Plataforma.position, verificar_Plataforma_J, plataforma_ID_J); 
	}

	void Update(){ 
		if (colidir_Plataforma && Input.GetKeyDown(KeyCode.W) || colidir_Plataforma && Input.GetKeyDown(KeyCode.UpArrow)){
			Vector2 pular = new Vector2 (0.0f, 500.0f);
			rb2D.AddForce (pular);
		}
	}

	// metodo que movimenta jogador
	void MovimentarJogador () {
		// atribuindo movimento horizontal a variavel X
		movimento_X = Input.GetAxis ("Horizontal") * 3.5f;

		// calculando a velocidade em que o jogador anda 
		rb2D.velocity = new Vector2 (movimento_X * andar_j, rb2D.velocity.y);

		// verifica direção do jogador
		if (movimento_X > 0 && !direcao_Jogador){ // mantem a direita
			TrocaDirecao();
		} else if (movimento_X < 0 && direcao_Jogador){ // mantem a esquerda
			TrocaDirecao();
		}
	}
		
	// metodo que troca a direção do jogador
	void TrocaDirecao(){
		direcao_Jogador = !direcao_Jogador;
		Vector3 escala = GetComponent<Transform>().localScale;
		escala.x *= -1;
		GetComponent<Transform>().localScale = escala;
	}
}