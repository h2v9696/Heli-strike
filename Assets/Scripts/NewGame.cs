using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewGame : MonoBehaviour {
	public GameObject panel;
	public string level_1;


	public void Play() {
		SceneManager.LoadScene (level_1, LoadSceneMode.Single);		
	}

	public void MainMenu()
	{
		panel.SetActive (false);

	}
}
