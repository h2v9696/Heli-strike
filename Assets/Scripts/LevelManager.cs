using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public int totalEnemies;

	void Start () {
		PlayerPrefs.SetInt("EnemyKilled",0);
		PlayerPrefs.SetInt("ConstructionDestroyed",0);

	}

}
