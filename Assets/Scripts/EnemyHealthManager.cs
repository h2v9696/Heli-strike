using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
	public int enemyMaxHealth;
	public int enemyHealth;
	public Explosion explosion;
	public GameObject enemyDeath;
	private Animator animator;
	public bool isConstructEnemy;
	private Sprite deathSprite;
	private EnemyPatrol enemy;
	void Start () {
		enemyHealth = enemyMaxHealth;
		animator = GetComponent<Animator> ();
		deathSprite = Resources.Load<Sprite> ("DeathEnemy");
		enemy = GetComponent<EnemyPatrol> ();
	}

	// Update is called once per frame
	void Update () {
		if (enemyHealth <= (enemyMaxHealth / 2)) {
			if (transform.childCount!=0) {
				var gun = transform.GetChild (0);
			
				Destroy (gun.gameObject);
			}
		}
		if (enemyHealth <= 0) {
			//explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z) * enemyHealth;
			if (!enemy.isFlying) {
				explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z)*3f;
				Instantiate (explosion, transform.position, transform.rotation);
				explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z)/3f;
				//Instantiate (explosion, transform.position, transform.rotation);
				var parent = transform.parent;
				Destroy (parent.gameObject);
				if (isConstructEnemy)
					Instantiate (enemyDeath, transform.position, enemyDeath.transform.rotation);
				
			}
			
		}
	}

	public void TakeDamage(int damageTaken) {
		enemyHealth -= damageTaken;
		animator.SetTrigger ("Damage");

	}
}
