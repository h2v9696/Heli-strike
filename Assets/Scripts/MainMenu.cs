using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using admob;

public class MainMenu : MonoBehaviour {

	public GameObject panelNewGame;
	public GameObject panelHowTo;


	public GameObject audioOnIcon;
	public GameObject audioOffIcon;
	private AudioSource audioSource;


	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
		SetSoundState ();
	}



	public void NewGame()
	{
		PlayerPrefs.SetInt ("TotalEnemyKills", 0);
		PlayerPrefs.SetInt ("TotalConstructDestroy",0);
		PlayerPrefs.SetInt ("TotalEnemySurvived",0);
		PlayerPrefs.SetInt ("HighScore", 0);
		panelNewGame.SetActive (true);
		AdManager.Instance.ShowVideo ();


	}

	public void HowToPlay()
	{
		panelHowTo.SetActive (true);
	}

	public void MoreGame()
	{
		Application.OpenURL ("http://google.com/");
	}

	public void ToggleSound()
	{
		if (PlayerPrefs.GetInt ("Muted", 0) == 0)
			PlayerPrefs.SetInt ("Muted", 1);
		else
			PlayerPrefs.SetInt ("Muted", 0);
		SetSoundState ();
	}

	private void SetSoundState()
	{
		if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
			AudioListener.volume = 1;
			audioOnIcon.SetActive (true);
			audioOffIcon.SetActive (false);
		} else {
			AudioListener.volume = 0;
			audioOnIcon.SetActive (false);
			audioOffIcon.SetActive (true);
		}
	}
	public void PlaySound() {
		audioSource.Play ();
	}
}
