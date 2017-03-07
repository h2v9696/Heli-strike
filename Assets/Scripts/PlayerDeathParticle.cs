using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathParticle : MonoBehaviour {

	private PlayerController player;

	//for explosion animation
	public Explosion explosion;
	private float timeExplosionDelay;
	private float timeExplosionDelayCounter;
	private Vector3 offset;
	private int currentExplosionPos;
	private Explosion cloneExplosion;


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
					cloneExplosion = Instantiate (explosion, transform.position - offset, transform.rotation);
					cloneExplosion.transform.localScale = new Vector3 (cloneExplosion.transform.localScale.x * 2f, cloneExplosion.transform.localScale.y * 2f, cloneExplosion.transform.localScale.z * 2f);

					currentExplosionPos = 2;
				}
				else if (currentExplosionPos == 2) 
				{
					cloneExplosion = Instantiate (explosion, transform.position + offset, transform.rotation);
					cloneExplosion.transform.localScale = new Vector3 (cloneExplosion.transform.localScale.x * 2f, cloneExplosion.transform.localScale.y * 2f, cloneExplosion.transform.localScale.z * 2f);
					currentExplosionPos = 1;
				}
				timeExplosionDelayCounter = timeExplosionDelay;
			}
			transform.position = new Vector2 (transform.position.x + 0.03f, transform.position.y + 0.03f);
			transform.localScale = new Vector2 (transform.localScale.x - transform.localScale.x * 0.004f, transform.localScale.y - transform.localScale.y * 0.004f);
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 5);
		} else 
		{
			//GetComponent<SpriteRenderer> ().sprite = damageSprite;
			cloneExplosion = Instantiate (explosion, transform.position , transform.rotation);
			cloneExplosion.transform.localScale = new Vector3 (cloneExplosion.transform.localScale.x * 3f, cloneExplosion.transform.localScale.y * 3f, cloneExplosion.transform.localScale.z * 3f);
			Destroy (gameObject);
			player.setIsLiving ();
		}
	}

}
