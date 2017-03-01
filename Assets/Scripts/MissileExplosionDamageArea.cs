using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosionDamageArea : MonoBehaviour {

	private EnemyHealthManager enemyHealthManager;
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
		if (other.tag == "Enemy") 
		{
			enemyHealthManager = other.GetComponent<EnemyHealthManager> ();
			enemyHealthManager.TakeDamage (dameToGive * 3);
			MakeRadiusDamage ();
			Destroy (gameObject);
		}
	}

	void MakeRadiusDamage()
	{
		Collider2D[] colls = Physics2D.OverlapCircleAll (transform.position, explosionRadius);
		foreach (Collider2D col in colls) 
		{
			if (col.tag == "Enemy") 
			{
				enemyHealthManager = col.GetComponent<EnemyHealthManager> ();
				enemyHealthManager.TakeDamage (dameToGive);
			}
		}
	}
}
