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
	public float deathAnimationTime=.25f;
	private Vector3 firstScale;
	public bool isDeath;
	public bool isFlying;
	private float angle=0;

	void Start () {
		firstScale = transform.lossyScale;
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
			if (!isFlying) {
				explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z) * 3f;
				Instantiate (explosion, transform.position, transform.rotation);
				explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z) / 3f;
				//Instantiate (explosion, transform.position, transform.rotation);
				var parent = transform.parent;
				Destroy (parent.gameObject);
				if (isConstructEnemy)
					Instantiate (enemyDeath, transform.position, enemyDeath.transform.rotation);
				
			} else {
				GetComponent<SpriteRenderer> ().sprite = deathSprite;
				if (deathAnimationTime >= 0) {
					explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z) ;
					Instantiate (explosion, transform.position, transform.rotation);
					explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x, explosion.transform.localScale.y, explosion.transform.localScale.z) ;
					deathAnimationTime -= 1;

				}

				if (transform.localScale.x > firstScale.x * 3 / 4) {
					
					transform.localScale = new Vector2 (transform.localScale.x - transform.localScale.x * 0.004f, transform.localScale.y - transform.localScale.y * 0.004f);
					Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
					angle += 10;

					//Quaternion rotation = Quaternion.LookRotation (relativePos);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * 10f);				
				} else {
					
					var parent = transform.parent;
					Destroy (parent.gameObject);
				}
			}
			
		}
	}

	public void TakeDamage(int damageTaken) {
		enemyHealth -= damageTaken;
		animator.SetTrigger ("Damage");

	}
}
