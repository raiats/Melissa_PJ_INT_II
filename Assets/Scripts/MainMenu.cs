using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){
		SceneManager.LoadScene ("Fase1");
	}

	public void CreditsGame(){
		SceneManager.LoadScene ("Credits");
	}
}
