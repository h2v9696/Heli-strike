using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour {

	public string titleScreen;
	public bool isPaused;

	public GameObject pauseMenuCanvas;

	void Update()
	{
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
		} else {
			pauseMenuCanvas.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}
	}

	public void Resume()
	{
		isPaused = false;
	}

	//public void MainMenu()
	//{
	//	Application.LoadLevel (titleScreen);
	//}
}
