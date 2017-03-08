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
	public Sprite deathSprite;
	private Vector3 firstScale;
	public bool isFlying;
	private bool isExplosion;
	private Explosion clone;
	public float angle = 5f;
	public float scaleReduce = 0.008f;
	public int enemyDead;
	public int constructEnemyDead;
	public bool isBoss;
	private GunController disableRotate;
	void Start () {
		firstScale = transform.lossyScale;
		enemyHealth = enemyMaxHealth;
		animator = GetComponent<Animator> ();
		isExplosion = false;
		disableRotate = GetComponent<GunController> ();
	}

	void Update () {
		enemyDead = PlayerPrefs.GetInt("EnemyKilled");
		constructEnemyDead = PlayerPrefs.GetInt ("ConstructionDestroyed");
		if (enemyHealth <= (enemyMaxHealth / 2)) {
			if (transform.childCount!=0) {
				var gun = transform.Find ("Gun");
				if (gun != null) {
					if (!isBoss) {
						Destroy (gun.gameObject);
					} else {
						if (enemyHealth <= 0) {
							Destroy (gun.gameObject);

						}
					}
				}
			}
		}
		if (enemyHealth <= 0) {

			if (!isFlying) {

				// Can add them hieu ung no
				clone = Instantiate (explosion, transform.position, transform.rotation);
				clone.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z) * 3f;
				var parent = transform.parent;
				Destroy (parent.gameObject);
				if (isConstructEnemy) {
					if (enemyDeath == null) {
						GetComponent<SpriteRenderer> ().sprite = deathSprite;
					}
					else {
						Instantiate (enemyDeath, transform.position, enemyDeath.transform.rotation);
					}
					constructEnemyDead++;
					PlayerPrefs.SetInt ("ConstructionDestroyed", constructEnemyDead);

				} else {
					enemyDead++;
					PlayerPrefs.SetInt ("EnemyKilled", enemyDead);

				}
				
			} else {
				if (disableRotate != null) {
					disableRotate.gunCantRotate = true;
				}
				if (deathSprite != null)
					GetComponent<SpriteRenderer> ().sprite = deathSprite;

				if (!isExplosion) {
					clone = Instantiate (explosion, transform.position, transform.rotation);
					clone.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z) * 2f;
					isExplosion = true;
				}
				clone.transform.position = transform.position;

				if (transform.localScale.x > firstScale.x * 3 / 4) {
					
					transform.localScale = new Vector2 (transform.localScale.x - transform.localScale.x * scaleReduce, transform.localScale.y - transform.localScale.y * 0.004f);
					transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + angle);		
				} else {
					var parent = transform.parent;
					Destroy (parent.gameObject);
					enemyDead++;
					PlayerPrefs.SetInt ("EnemyKilled", enemyDead);
					clone = Instantiate (explosion, transform.position, transform.rotation);
					clone.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z) * 2f;

				}
			}
			
		}
	}

	public void TakeDamage(int damageTaken) {
		enemyHealth -= damageTaken;
		animator.SetTrigger ("Damage");

	}
}
