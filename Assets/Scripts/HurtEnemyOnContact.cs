using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour {

	public GameObject explosion;
	public EnemyHealthManager enemyHealthManager;
	public int dameToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			
			Destroy (gameObject);
			enemyHealthManager = other.GetComponent<EnemyHealthManager> ();
			enemyHealthManager.TakeDamage (dameToGive);
		}
	}
}
