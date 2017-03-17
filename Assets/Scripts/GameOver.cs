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

public Text theTextEnemyKill;
	public Text theTextConstructKill;
	public Text theTextEnemySurvived;

	public int intEnemyKilled;
	public int intConstructKilled;
	public int totalEnemyKilled;
	public int totalConstructKilled;

	private LevelManager levelManager;
	private int highScore;


	void Start () {

		playerHealth = FindObjectOfType<PlayerHealthManager> ();
		levelManager = FindObjectOfType<LevelManager> ();
	}
	

	void Update () {

		if (playerHealth.playerHealth<=0) {
			delayTimer += Time.deltaTime;
			if (delayTimer >= delay) {
				isOver = true;
				gameOverCanvas.SetActive (true);

				intEnemyKilled = PlayerPrefs.GetInt ("EnemyKilled");
				totalEnemyKilled = PlayerPrefs.GetInt ("TotalEnemyKills");
				totalEnemyKilled += intEnemyKilled;
				PlayerPrefs.SetInt ("TotalEnemyKills", totalEnemyKilled);
				theTextEnemyKill.text = "Enemy Killed: " + totalEnemyKilled;

				intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");
				totalConstructKilled = PlayerPrefs.GetInt ("TotalConstructDestroy");
				totalConstructKilled += intConstructKilled;
				theTextConstructKill.text = "Construct Destroyed: " + totalConstructKilled;
				highScore = totalEnemyKilled + totalConstructKilled;
				PlayerPrefs.SetInt ("HighScore", highScore);


				theTextEnemySurvived.text = "Enemy Survived: " + (levelManager.totalEnemies - intEnemyKilled- intConstructKilled);
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
