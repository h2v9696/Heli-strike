using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {

	private ProgressBar status;
	public GameObject levelCompleteCanvas;
	public string nextLevel;
	public float delay = 4f;
	float delayTimer;
	void Start () {
		status = FindObjectOfType<ProgressBar> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(status.progress>=status.maxValue)
		{
			delayTimer += Time.deltaTime;
		if (delayTimer >= delay) 
			{
			levelCompleteCanvas.SetActive (true);
			Time.timeScale = 0f;
			}
		}
	}
	public void NextLevel()
	{
		Application.LoadLevel (nextLevel);
	}
}