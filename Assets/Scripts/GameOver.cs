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

	private LevelManager levelManager;
	private int highScore;
	private bool added;
	private bool added2;
	public bool check = false;

	public float dropRate = 0.25f;

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

				if (isOver) {
					if (Random.Range (0.0f, 1.0f) <= dropRate) {

						if (!check) {
							AdManager.Instance.ShowVideo ();
							check = true;
						}
					}
				}

				intEnemyKilled = PlayerPrefs.GetInt ("EnemyKilled");
				totalEnemyKilled = PlayerPrefs.GetInt ("TotalEnemyKills");
				if (!added) {
					totalEnemyKilled += intEnemyKilled;
					added = true;
				}
				PlayerPrefs.SetInt ("TotalEnemyKills", totalEnemyKilled);
				theTextEnemyKill.text = "Enemy Killed: " + totalEnemyKilled;

				intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");
				totalConstructKilled = PlayerPrefs.GetInt ("TotalConstructDestroy");
				if (!added2) {
					totalConstructKilled += intConstructKilled;

					added2 = true;
				}
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
