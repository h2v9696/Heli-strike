using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	public GameObject enemy;
	//public Transform getChild;
	public void SpawnEnemy()
	{	//getChild = enemy.transform.GetChild (0);
		Instantiate (enemy, this.transform.position, enemy.transform.rotation);
			}
}
