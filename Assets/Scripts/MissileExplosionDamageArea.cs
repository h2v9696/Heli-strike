using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosionDamageArea : MonoBehaviour {

	private EnemyHealthManager enemyHealthManager;
	private BossHealthManager bossHealthManager;
	public GameObject shockwave;
	public int dameToGive;
	public float explosionRadius;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy" || other.tag == "ConstructEnemy")
		{
			enemyHealthManager = other.GetComponent<EnemyHealthManager> ();
			enemyHealthManager.TakeDamage (dameToGive * 3);
			MakeRadiusDamage ();
			Instantiate (shockwave, other.transform.position, transform.rotation);
			Destroy (gameObject);
		}
		if (other.tag == "Boss" ) 
		{

			Destroy (gameObject);
			bossHealthManager = other.GetComponent<BossHealthManager> ();
			bossHealthManager.TakeDamage (dameToGive * 3);
		}
	}

	void MakeRadiusDamage()
	{
		Collider2D[] colls = Physics2D.OverlapCircleAll (transform.position, explosionRadius);
		foreach (Collider2D col in colls) 
		{
			if (col.tag == "Enemy" || col.tag == "ConstructEnemy") 
			{
				enemyHealthManager = col.GetComponent<EnemyHealthManager> ();
				enemyHealthManager.TakeDamage (dameToGive);
			}
		}
	}
}
