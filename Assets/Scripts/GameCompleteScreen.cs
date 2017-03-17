using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCompleteScreen : MonoBehaviour {

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

	public int intTotalEnemySurvived;

	private LevelManager levelManager;


	 
	float delayTimer;
	void Start () {
		isComplete = false;
		status = FindObjectOfType<ProgressBar> ();
		levelManager = FindObjectOfType<LevelManager> ();
	

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

			
				intEnemyKilled = PlayerPrefs.GetInt ("TotalEnemyKills");
				theTextEnemyKill.text = "Total Enemy Killed: " + intEnemyKilled;

				intConstructKilled = PlayerPrefs.GetInt ("TotalConstructDestroy");
				theTextConstructKill.text = "Total Construct Destroyed: " + intConstructKilled;
				intTotalEnemySurvived = PlayerPrefs.GetInt ("TotalEnemySurvived");
				theTextConstructKill.text = "Total Enemy Survived: " + intTotalEnemySurvived;
			
				Time.timeScale = 0f;

			}
		}
	}



	public void NextLevel()
	{
		SceneManager.LoadScene (nextLevel, LoadSceneMode.Single);		
	}




}
