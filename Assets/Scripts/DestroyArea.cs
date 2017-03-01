using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour 
{
	private SpawnPoint spawnPoint;

	void OnTriggerExit2D(Collider2D c)
	{
		Debug.Log ("Left the Area");
		Destroy (c.gameObject);
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.name == "SpawnPoint")
			
		c.gameObject.GetComponent<SpawnPoint> ().SpawnEnemy ();
	}
}
