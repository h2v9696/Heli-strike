using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour {

	private ProgressBar status;
	public GameObject levelCompleteCanvas;
	public string nextLevel;
	public float delay = 4f;
	public bool isComplete;

	public Text theTextEnemyKill;
	public Text theTextConstructKill;
	public Text theTextEnemySurvived;
	public Text title;

	public int intEnemyKilled;
	public int intConstructKilled;
	public int intEnemySurvived;
	//private  int holdForTotalEnemyKill=0;
	//private  int holdForTotalConstructDestroy=0;
	//private  int holdForTotalEnemySurvived = 0;
	private int intTotalEnemySurvived;
	public bool isLastLevel;
	private int highScore;
	public int totalEnemyKilled;
	public int totalConstructKilled;
	private bool added;

	private LevelManager levelManager;

	float delayTimer;
	void Start () {
		isComplete = false;
		status = FindObjectOfType<ProgressBar> ();
		levelManager = FindObjectOfType<LevelManager> ();
		highScore = PlayerPrefs.GetInt ("HighScore");
	}
	

	void Update () 
	{
		if(status.progress>=status.maxValue)
		{
			delayTimer += Time.deltaTime;

				if (delayTimer >= delay) 
					{
				isComplete = true;
				levelCompleteCanvas.SetActive (true);
				if (!isLastLevel) {
					
					intEnemyKilled = PlayerPrefs.GetInt ("EnemyKilled");
					intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");
					intEnemySurvived = levelManager.totalEnemies - intEnemyKilled - intConstructKilled;


					if (!added) {
						totalEnemyKilled = PlayerPrefs.GetInt ("TotalEnemyKills");
						totalEnemyKilled += intEnemyKilled;
						PlayerPrefs.SetInt ("TotalEnemyKills", totalEnemyKilled);

						totalConstructKilled = PlayerPrefs.GetInt ("TotalConstructDestroy");
						totalConstructKilled += intConstructKilled;
						PlayerPrefs.SetInt ("TotalConstructDestroy", totalConstructKilled);

						highScore = totalEnemyKilled + totalConstructKilled;
						PlayerPrefs.SetInt ("HighScore", highScore);

						intTotalEnemySurvived = PlayerPrefs.GetInt ("TotalEnemySurvived");
						intTotalEnemySurvived += intEnemySurvived;
						PlayerPrefs.SetInt ("TotalEnemySurvived", intTotalEnemySurvived);
						added = true;
					}
					theTextEnemyKill.text = "Enemy Killed: " + intEnemyKilled;

					theTextConstructKill.text = "Construct Destroyed: " + intConstructKilled;

					theTextEnemySurvived.text = "Enemy Survived: " + intEnemySurvived;
				}

				if (isLastLevel) {
					title.text = "GAME COMPLETE";

					intEnemyKilled = PlayerPrefs.GetInt ("EnemyKilled");
					intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");
					intEnemySurvived = levelManager.totalEnemies - intEnemyKilled - intConstructKilled;

					if (!added) {
						totalEnemyKilled = PlayerPrefs.GetInt ("TotalEnemyKills");
						totalEnemyKilled += intEnemyKilled;
						PlayerPrefs.SetInt ("TotalEnemyKills", totalEnemyKilled);

						totalConstructKilled = PlayerPrefs.GetInt ("TotalConstructDestroy");
						totalConstructKilled += intConstructKilled;
						PlayerPrefs.SetInt ("TotalConstructDestroy", totalConstructKilled);

						highScore = totalEnemyKilled + totalConstructKilled;
						PlayerPrefs.SetInt ("HighScore", highScore);

						intTotalEnemySurvived = PlayerPrefs.GetInt ("TotalEnemySurvived");
						intTotalEnemySurvived += intEnemySurvived;
						PlayerPrefs.SetInt ("TotalEnemySurvived", intTotalEnemySurvived);
						added = true;
					}
					theTextEnemyKill.text = "Total Enemy Killed: " + totalEnemyKilled;

					theTextConstructKill.text = "Total Construct Destroyed: " + totalConstructKilled;

					theTextEnemySurvived.text = "Total Enemy Survived: " + intTotalEnemySurvived;

				}

							Time.timeScale = 0f;
				/*if (!isAdded) 
				{
					holdForTotalEnemyKill = PlayerPrefs.GetInt ("TotalEnemyKills");
					//Debug.Log (holdForTotalEnemyKill);


					holdForTotalConstructDestroy = PlayerPrefs.GetInt ("TotalConstructDestroy");
					holdForTotalEnemySurvived = PlayerPrefs.GetInt ("TotalEnemySurvived");

					holdForTotalEnemySurvived += levelManager.totalEnemies - intEnemyKilled - intConstructKilled;
					holdForTotalEnemyKill += intEnemyKilled;
					holdForTotalConstructDestroy += intConstructKilled;

					//Debug.Log (holdForTotalEnemyKill);
					PlayerPrefs.SetInt ("TotalEnemyKills", holdForTotalEnemyKill);
					//Debug.Log (holdForTotalEnemyKill);

					PlayerPrefs.SetInt ("TotalConstructDestroy", holdForTotalConstructDestroy);
					PlayerPrefs.SetInt ("TotalEnemySurvived", holdForTotalEnemySurvived);
					isAdded = true;
				}*/


					}
		}
	}
		
	public void NextLevel()
	{
		SceneManager.LoadScene (nextLevel, LoadSceneMode.Single);		

	}

}
	