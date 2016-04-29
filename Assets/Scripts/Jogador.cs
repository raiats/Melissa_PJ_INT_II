using UnityEngine;
using System.Collections;

// classe Jogador

public class Jogador : MonoBehaviour {

	// declarando variaveis

	public float andar_j = 25.0f;
	private bool direcao_Jogador = true;
	private float movimento_X;
	private Rigidbody2D rb2D;

	// variaveis relacionadas ao tiro do antivirus

	private float tempo_Antivirus = 0.2f; // tempo de acionamento
	private float controle_Antivirus = 0f; // controle do acionamento 
	public Transform disparar_Antivirus; // posição do antivirus
	public GameObject antivirus; // objeto antivirus

	// variaveis relacionadas com detecção da plataforma

	public Transform verificar_Plataforma;
	public LayerMask plataforma_ID_J;


	void Start (){
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		MovimentarJogador ();
	}

	void Update(){ 
		if (rb2D.velocity.y==0 && Input.GetKeyDown(KeyCode.W) || rb2D.velocity.y==0 && Input.GetKeyDown(KeyCode.UpArrow)){
			Vector2 pular = new Vector2 (0.0f, 500.0f);
			rb2D.AddForce (pular);

		}

		// calcula o tempo para disparar 
		if (controle_Antivirus > 0) {
			controle_Antivirus -= Time.deltaTime;
		}

		if(Input.GetKey("space") || Input.GetKey(KeyCode.Space)){
			DispararAntivirus ();

			controle_Antivirus = tempo_Antivirus;
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

	void DispararAntivirus(){
		// controle de disparo e direção
		if (controle_Antivirus <= 0f) {
		
			if(antivirus != null){
				var copiar_Antivirus = Instantiate (antivirus, disparar_Antivirus.position, Quaternion.identity) as GameObject;
				copiar_Antivirus.transform.localScale = this.transform.localScale;
			}

		}
	}
}