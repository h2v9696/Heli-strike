using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public int totalEnemies;
	public int intEnemyKilled;
	public int intConstructKilled;
	public GameObject spawnEnemies;
	public GameObject constructEnemies;


	//private bool isAdded;

	//private LevelComplete levelComplete;
	void Start () {
		totalEnemies = spawnEnemies.transform.childCount + constructEnemies.transform.childCount;
		//levelComplete = FindObjectOfType<LevelComplete> ();
		PlayerPrefs.SetInt("EnemyKilled",0);
		PlayerPrefs.SetInt("ConstructionDestroyed",0);
		//isAdded = false;

	}
	void Update() {
		
		intEnemyKilled = PlayerPrefs.GetInt ("EnemyKilled");

		intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");


	}
}
