using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour {

	//public GameObject explosion;
	private EnemyHealthManager enemyHealthManager;
	private BossHealthManager bossHealthManager;
	public int dameToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy" ||other.tag == "ConstructEnemy") 
		{
			
			Destroy (gameObject);
			enemyHealthManager = other.GetComponent<EnemyHealthManager> ();
			enemyHealthManager.TakeDamage (dameToGive);
		}
		if (other.tag == "Boss" ) 
		{

			Destroy (gameObject);
			bossHealthManager = other.GetComponent<BossHealthManager> ();
			bossHealthManager.TakeDamage (dameToGive);
		}
	}
}
