using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {

	private ProgressBar status;
	public GameObject levelCompleteCanvas;
	public string nextLevel;
	public float delay = 4f;
	public bool isComplete;

	public Text theTextEnemyKill;
	public Text theTextConstructKill;
	public Text theTextEnemySurvived;

	public int intEnemyKilled;
	public int intConstructKilled;
	private  int holdForTotalEnemyKill=0;
	private  int holdForTotalConstructDestroy=0;
	private LevelManager levelManager;
	private bool isAdded;
	float delayTimer;
	void Start () {
		isComplete = false;
		status = FindObjectOfType<ProgressBar> ();
		levelManager = FindObjectOfType<LevelManager> ();
		isAdded = false;

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
				intEnemyKilled = PlayerPrefs.GetInt ("EnemyKilled");
				theTextEnemyKill.text = "Enemy Killed: " + intEnemyKilled;

				intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");
				theTextConstructKill.text = "Construct Destroyed: " + intConstructKilled;


				theTextEnemySurvived.text = "Enemy Survived: " + (levelManager.totalEnemies - intEnemyKilled- intConstructKilled);

							Time.timeScale = 0f;
				if (!isAdded) 
				{
					holdForTotalEnemyKill = PlayerPrefs.GetInt ("TotalEnemyKills");
					Debug.Log (holdForTotalEnemyKill);

					holdForTotalConstructDestroy = PlayerPrefs.GetInt ("TotalConstructDestroy");
					holdForTotalEnemyKill += intEnemyKilled;
					holdForTotalConstructDestroy += intConstructKilled;
					Debug.Log (holdForTotalEnemyKill);
					PlayerPrefs.SetInt ("TotalEnemyKills", holdForTotalEnemyKill);
					Debug.Log (holdForTotalEnemyKill);

					PlayerPrefs.SetInt ("TotalConstructDestroy", holdForTotalConstructDestroy);
					isAdded = true;
				}


					}
		}
	}



	public void NextLevel()
	{
		Application.LoadLevel (nextLevel);
	}




}