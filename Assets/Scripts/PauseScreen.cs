using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour {

	//public string titleScreen;

	public bool isPaused;

	public GameObject pauseMenuCanvas;

	void Update()
	{
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			isPaused = !isPaused;
		}
	}

	public void Resume()
	{
		isPaused = false;
	}

	public bool getIsPaused()
	{
		return isPaused;
	}

	//public void MainMenu()
	//{
	//	Application.LoadLevel (titleScreen);
	//}
}
