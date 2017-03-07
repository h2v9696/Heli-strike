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
				intEnemyKilled = PlayerPrefs.GetInt ("EnemyKilled");
				theTextEnemyKill.text = "Enemy Killed: " + intEnemyKilled;

				intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");
				theTextConstructKill.text = "Construct Destroyed: " + intConstructKilled;


				theTextEnemySurvived.text = "Enemy Survived: " + (levelManager.totalEnemies - intEnemyKilled- intConstructKilled);

							Time.timeScale = 0f;


					}
		}
	}



	public void NextLevel()
	{
		Application.LoadLevel (nextLevel);
	}




}