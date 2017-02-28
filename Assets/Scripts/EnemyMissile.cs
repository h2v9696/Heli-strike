using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour {

	public int moveSpeed;
	public float lifeTime;
	public int power;

	public GameObject missileFireTail;
	public GameObject missileFireTailShadow;


	private PlayerHealthManager player;
	void Start () {
		player = FindObjectOfType<PlayerHealthManager> ();
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * moveSpeed;
		Destroy (gameObject, lifeTime);
	}
	void Update ()
	{
		missileFireTail.transform.localScale = new Vector2 (missileFireTail.transform.localScale.x + missileFireTail.transform.localScale.x * 0.4f * Time.deltaTime, missileFireTail.transform.localScale.y + missileFireTail.transform.localScale.y * 0.4f * Time.deltaTime);
		missileFireTail.transform.position = new Vector2 (missileFireTail.transform.position.x, missileFireTail.transform.position.y);

		missileFireTailShadow.transform.localScale = new Vector2 (missileFireTailShadow.transform.localScale.x + missileFireTailShadow.transform.localScale.x * 0.2f * Time.deltaTime, missileFireTailShadow.transform.localScale.y + missileFireTailShadow.transform.localScale.y * 0.4f * Time.deltaTime);
		missileFireTailShadow.transform.position = new Vector2 (missileFireTailShadow.transform.position.x, missileFireTailShadow.transform.position.y);
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			//damageGiven = weapon.power;
			//HealthManager.HurtPlayer (damageToGive);


			player.TakeDamage (power);
			Destroy (gameObject);
		}
	}
}
