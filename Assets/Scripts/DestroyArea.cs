using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour 
{
	private SpawnPoint spawnPoint;

	void OnTriggerExit2D(Collider2D c)
	{
		
		Destroy (c.gameObject);
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag == "SpawnPoint")
			
		c.gameObject.GetComponent<SpawnPoint> ().SpawnEnemy ();
	}
}
