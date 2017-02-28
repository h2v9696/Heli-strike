using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour {
	public GameObject panel;
	public string level_1;


	public void Play()
	{Application.LoadLevel (level_1);}

	public void MainMenu()
	{
		panel.SetActive (false);

	}
}
