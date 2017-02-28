using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public float second	;
	public int min;
	string rounder;
	//private PauseScreen thePauseScreen;
	//private bool isPausing;
	private Text theText;
	void Start()
	{   second = 54f;
		theText = GetComponent<Text> ();
	//	thePauseScreen = FindObjectOfType<PauseScreen> ();
	}

	void Update()
	{	second += Time.deltaTime;
		
		//isPausing = thePauseScreen.getIsPaused ();
		//Debug.Log (isPausing);
		if(second >= 59f) 
		{
			second = 0f; 
			min++;
		}
		 rounder = string.Format("{0:00}.{1:00}",min,Mathf.Round(second));
		theText.text = "" + rounder;

	}
}
