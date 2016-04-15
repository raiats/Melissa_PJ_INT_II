using UnityEngine;
using System.Collections;

public class Virus : MonoBehaviour {


	// declarando variaveis
	public float andar_v; 
	private bool direcao_Virus = true;
	public Transform verificar_Plataforma_Virus;
	public float verificar_Plataforma_V;
	public LayerMask plataforma_ID_V;
	private bool colidir_Plataforma_V;

	void Start () { 
	}

	void Update(){ 

		colidir_Plataforma_V = Physics2D.OverlapCircle (verificar_Plataforma_Virus.position, verificar_Plataforma_V, plataforma_ID_V); 

		if (colidir_Plataforma_V)
			colidir_Plataforma_V = !colidir_Plataforma_V;

		if (direcao_Virus) { 
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (andar_v, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			transform.localScale = new Vector3 (1f, 1f, -1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-andar_v, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}