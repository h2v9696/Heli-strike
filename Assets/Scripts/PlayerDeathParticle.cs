using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathParticle : MonoBehaviour {

	public PlayerController player;

	//for explosion animation
	public GameObject explosion;
	private float timeExplosionDelay;
	private float timeExplosionDelayCounter;
	private Vector3 offset;
	private int currentExplosionPos;

	void Start()
	{
		player = GetComponent<PlayerController> ();
		timeExplosionDelay = 0.5f;
		timeExplosionDelayCounter = timeExplosionDelay;
		offset = new Vector3 (0.2f, 0.5f, 0f);
		currentExplosionPos = 1;
	}

	public void deathParticle(Vector3 firstScale)
	{
		if (transform.localScale.x > firstScale.x * 3 / 4) 
		{
			timeExplosionDelayCounter -= Time.deltaTime;
			if (timeExplosionDelayCounter <= 0) 
			{
				if (currentExplosionPos == 1) 
				{
					Instantiate (explosion, transform.position + offset, transform.rotation);
					currentExplosionPos = 2;
				}
				else if (currentExplosionPos == 2) 
				{
					Instantiate (explosion, transform.position - offset, transform.rotation);
					currentExplosionPos = 1;
				}
				timeExplosionDelayCounter = timeExplosionDelay;
			}

			transform.localScale = new Vector2 (transform.localScale.x - transform.localScale.x * 0.004f, transform.localScale.y - transform.localScale.y * 0.004f);
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 5);
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
