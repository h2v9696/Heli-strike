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
	private bool added2;
	private bool added3;
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
				if (!added) {
					totalEnemyKilled = PlayerPrefs.GetInt ("TotalEnemyKills");
					totalEnemyKilled += intEnemyKilled;
					added = true;
				}
				PlayerPrefs.SetInt ("TotalEnemyKills", 0);
				theTextEnemyKill.text = "Enemy Killed: " + totalEnemyKilled;

				intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");
				if (!added2) {
					totalConstructKilled = PlayerPrefs.GetInt ("TotalConstructDestroy");
					totalConstructKilled += intConstructKilled;
					added2 = true;
				}
				PlayerPrefs.SetInt ("TotalConstructDestroy", 0);
				theTextConstructKill.text = "Construct Destroyed: " + totalConstructKilled;
				highScore = totalEnemyKilled + totalConstructKilled;
				PlayerPrefs.SetInt ("HighScore", highScore);

				intEnemySurvived = levelManager.totalEnemies - intEnemyKilled - intConstructKilled;
				if (!added3) {
					intTotalEnemySurvived = PlayerPrefs.GetInt ("TotalEnemySurvived");
					intTotalEnemySurvived += intEnemySurvived;
					added3 = true;
				}
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
