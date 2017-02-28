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
	private Vector3 firstScale;
	public bool isDeath;
	public bool isFlying;
	private bool isExplosion;
	private Explosion clone;

	void Start () {
		firstScale = transform.lossyScale;
		enemyHealth = enemyMaxHealth;
		animator = GetComponent<Animator> ();
		deathSprite = Resources.Load<Sprite> ("DeathEnemy");
		isExplosion = false;
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
			if (!isFlying) {
				// Can add them hieu ung no
				clone = Instantiate (explosion, transform.position, transform.rotation);
				clone.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z) * 3f;
				//Instantiate (explosion, transform.position, transform.rotation);
				var parent = transform.parent;
				Destroy (parent.gameObject);
				if (isConstructEnemy)
					Instantiate (enemyDeath, transform.position, enemyDeath.transform.rotation);
				
			} else {
				GetComponent<SpriteRenderer> ().sprite = deathSprite;

				if (!isExplosion) {
					clone = Instantiate (explosion, transform.position, transform.rotation);
					clone.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z) * 2f;
					isExplosion = true;
				}
				clone.transform.position = transform.position;

				if (transform.localScale.x > firstScale.x * 3 / 4) {
					
					transform.localScale = new Vector2 (transform.localScale.x - transform.localScale.x * 0.006f, transform.localScale.y - transform.localScale.y * 0.004f);
					transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 5);		
				} else {
					var parent = transform.parent;
					Destroy (parent.gameObject);
					Instantiate (explosion, transform.position, transform.rotation);
				}
			}
			
		}
	}

	public void TakeDamage(int damageTaken) {
		enemyHealth -= damageTaken;
		animator.SetTrigger ("Damage");

	}
}
