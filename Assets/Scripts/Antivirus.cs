using UnityEngine;
using System.Collections;

public class Antivirus : MonoBehaviour {

	private Vector2 velocidade_Antivirus = new Vector2 (15, 0);
	private Rigidbody2D rb2D_Antivirus;

	// Use this for initialization
	void Start () {
	
		rb2D_Antivirus = GetComponent<Rigidbody2D> ();
		rb2D_Antivirus.velocity = velocidade_Antivirus * this.transform.localScale.x;
		Destroy (gameObject, 2f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// colidindo com malware
	void OnTriggerEnter2D(Collider2D colidir){

		if(colidir.gameObject.CompareTag("Malware")){
			colidir.gameObject.SetActive (false);

		}
	}
}
