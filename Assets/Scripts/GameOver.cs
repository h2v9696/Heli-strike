using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using admob;

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
	public int intTotalEnemySurvived;
	public int intEnemySurvived;
	private LevelManager levelManager;
	private int highScore;
	private bool added;
	public bool check = false;

	public float dropRate = 0.25f;

	void Start () {
		
		playerHealth = FindObjectOfType<PlayerHealthManager> ();
		levelManager = FindObjectOfType<LevelManager> ();
		highScore = PlayerPrefs.GetInt ("HighScore");

	}
	

	void Update () {

		if (playerHealth.playerHealth<=0) {
			delayTimer += Time.deltaTime;
			if (delayTimer >= delay) {
				isOver = true;
				gameOverCanvas.SetActive (true);

				if (isOver) {
					if (Random.Range (0.0f, 1.0f) <= dropRate) {
						if (!check) {
							AdManager.Instance.ShowVideo ();
							check = true;
						}
					}
				}

				intEnemyKilled = PlayerPrefs.GetInt ("EnemyKilled");
				intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");
				intEnemySurvived = levelManager.totalEnemies - intEnemyKilled - intConstructKilled;

				if (!added) {
					totalEnemyKilled = PlayerPrefs.GetInt ("TotalEnemyKills");
					totalEnemyKilled += intEnemyKilled;

					totalConstructKilled = PlayerPrefs.GetInt ("TotalConstructDestroy");
					totalConstructKilled += intConstructKilled;

					intTotalEnemySurvived = PlayerPrefs.GetInt ("TotalEnemySurvived");
					intTotalEnemySurvived += intEnemySurvived;

					highScore = totalEnemyKilled + totalConstructKilled;
					added = true;
				}
				PlayerPrefs.SetInt ("HighScore", highScore);

				PlayerPrefs.SetInt ("TotalEnemyKills", 0);
				theTextEnemyKill.text = "Enemy Killed: " + totalEnemyKilled;

				PlayerPrefs.SetInt ("TotalConstructDestroy", 0);
				theTextConstructKill.text = "Construct Destroyed: " + totalConstructKilled;


				PlayerPrefs.SetInt ("TotalEnemySurvived", 0);
				theTextEnemySurvived.text = "Enemy Survived: " + intTotalEnemySurvived;
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
