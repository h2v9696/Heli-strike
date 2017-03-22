using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoader : MonoBehaviour {
	public string mainMenu;
	// Use this for initialization
	void Start () {
		SceneManager.LoadScene (mainMenu, LoadSceneMode.Single);		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
