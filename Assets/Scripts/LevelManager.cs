using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public int totalEnemies;
	public int intEnemyKilled;
	public int intConstructKilled;
	void Start () {
		PlayerPrefs.SetInt("EnemyKilled",0);
		PlayerPrefs.SetInt("ConstructionDestroyed",0);

	}
	void Update() {
		intEnemyKilled = PlayerPrefs.GetInt ("EnemyKilled");

		intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");
	}
}
