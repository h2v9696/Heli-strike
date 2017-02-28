using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	private PlayerController playerController;
	public GameObject gameOverCanvas;
	public string restart;



	void Start () {
		playerController = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerController.isLiving==false) {
			gameOverCanvas.SetActive (true);

			Time.timeScale = 0f;
		}
		
	}

	public void Restart()
	{
		Application.LoadLevel (restart);
	}
}
