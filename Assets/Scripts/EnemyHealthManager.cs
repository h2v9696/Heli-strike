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
	public bool isDeath;
	public bool isFlying;
	private bool isExplosion;
	private Explosion clone;
	public float angle = 5f;
	public float scaleReduce = 0.008f;
	//public bool isBoss;
	void Start () {
		firstScale = transform.lossyScale;
		enemyHealth = enemyMaxHealth;
		animator = GetComponent<Animator> ();
		//deathSprite = Resources.Load<Sprite> ("DeathEnemy");
		isExplosion = false;
	}

	// Update is called once per frame
	void Update () {
		if (enemyHealth <= (enemyMaxHealth / 2)) {
			if (transform.childCount!=0) {
				var gun = transform.Find ("Gun");
				if (gun!=null)
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
