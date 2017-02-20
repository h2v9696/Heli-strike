using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;
	public Explosion explosion;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
			Instantiate (explosion, transform.position, transform.rotation);

			Destroy (gameObject);
		}
	}
	public void TakeDamage(int damageTaken) {
		enemyHealth -= damageTaken;


	}
}
