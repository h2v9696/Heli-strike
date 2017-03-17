using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {

	public int bossMaxHealth;
	public int bossHealth;
	public Explosion explosion;
	public Sprite deathSprite;
	private Explosion clone;
	public bool isFlying;

	private Animator animator;
	private bool isExplosion;
	private Vector3 firstScale;
	public int enemyDead;
	public float angle = 5f;
	public float scaleReduce = 0.008f;
	public bool isDeath;
	private GunController disableRotate;


	void Start () {
		firstScale = transform.lossyScale;
		disableRotate = GetComponent<GunController> ();

		bossHealth = bossMaxHealth;
		animator = GetComponent<Animator> ();
		isExplosion = false;
	}

	// Update is called once per frame
	void Update () {

		if (bossHealth <= 0) {
			enemyDead = PlayerPrefs.GetInt("EnemyKilled");
			enemyDead++;
			PlayerPrefs.SetInt ("EnemyKilled", enemyDead);

			if (!isFlying) {
				isDeath = true;
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
		bossHealth -= damageTaken;
		animator.SetTrigger ("Damage");

	}
}
