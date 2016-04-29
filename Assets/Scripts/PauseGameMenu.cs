using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGameMenu : MonoBehaviour {

	public GameObject PauseGame;
	public bool paused = false; 

	// Use this for initialization
	void Start () {
		PauseGame.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Escape)) {
			paused = true;

			if (paused) {
				PauseGame.SetActive (true);
				Time.timeScale = 0;
			} else if (!paused){
				paused = false;
				PauseGame.SetActive (false);
				Time.timeScale = 1;
			}

			PauseGame.transform.localScale = this.transform.localScale;
		}
	}

	public void ResumeGame(){
		paused = false;
		PauseGame.SetActive (false);
		Time.timeScale = 1;
	}

	public void RestartGame(){
		SceneManager.LoadScene ("Fase1");
		Time.timeScale = 1;
	}

	public void MainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
}
