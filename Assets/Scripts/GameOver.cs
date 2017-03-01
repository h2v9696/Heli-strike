using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	private PlayerController playerController;
	public GameObject gameOverCanvas;
	public string restart;
	public float delay = 4f;
	float delayTimer;
	private PlayerHealthManager playerHealth;
	public bool isOver;



	void Start () {

		playerHealth = FindObjectOfType<PlayerHealthManager> ();
	}
	

	void Update () {

		if (playerHealth.playerHealth<=0) {
			delayTimer += Time.deltaTime;
			if (delayTimer >= delay) {
				isOver = true;
				gameOverCanvas.SetActive (true);
						Time.timeScale = 0;
			}

		}
		
		
	}

	public void Restart()
	{
		
		SceneManager.LoadScene (restart);
	}

	

	/*IEnumerator showGameOverScreen()
	{
		yield return new WaitForSeconds (delay);
		gameOverCanvas.SetActive (true);

		Time.timeScale = 0f;
	}*/
}
