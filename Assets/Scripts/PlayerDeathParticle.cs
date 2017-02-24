using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathParticle : MonoBehaviour {

	public PlayerController player;
	public GameObject explosion;

	void Start()
	{
		player = GetComponent<PlayerController> ();
	}

	public void deathParticle(Vector3 firstScale)
	{
		if (transform.localScale.x > firstScale.x * 3 / 4) {
			transform.localScale = new Vector2 (transform.localScale.x - transform.localScale.x * 0.004f, transform.localScale.y - transform.localScale.y * 0.004f);
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 10);
		} else 
		{
			//GetComponent<SpriteRenderer> ().sprite = damageSprite;
			explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x * 3f, explosion.transform.localScale.y * 3f, explosion.transform.localScale.z * 3f);
			Instantiate (explosion, transform.position, transform.rotation);
			explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x / 3f, explosion.transform.localScale.y / 3f, explosion.transform.localScale.z / 3f);
			Destroy (gameObject);
			player.setIsLiving ();
		}
	}

}
