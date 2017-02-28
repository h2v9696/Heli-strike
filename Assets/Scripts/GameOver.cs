using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	private PlayerController playerController;
	public GameObject gameOverCanvas;
	public string restart;
	public float delay = 4f;
	float delayTimer;
	private PlayerHealthManager playerHealth;



	void Start () {
		playerController = FindObjectOfType<PlayerController> ();
		playerHealth = FindObjectOfType<PlayerHealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.playerHealth<=0) {
			delayTimer += Time.deltaTime;
			if (delayTimer >= delay) {
				gameOverCanvas.SetActive (true);

				Time.timeScale = 0f;
			}
			//StartCoroutine(showGameOverScreen ());
		}
		
		
	}

	public void Restart()
	{
		Application.LoadLevel (restart);
	}

	/*IEnumerator showGameOverScreen()
	{
		yield return new WaitForSeconds (delay);
		gameOverCanvas.SetActive (true);

		Time.timeScale = 0f;
	}*/
}
