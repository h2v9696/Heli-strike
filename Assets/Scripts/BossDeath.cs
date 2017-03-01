using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour {

	public Explosion explosion;
	private float timeExplosionDelay;
	private float timeExplosionDelayCounter;
	private Vector3 offset;
	private int currentExplosionPos;
	private Explosion cloneExplosion;
	private BossHealthManager boss;

	void Start() {
		boss = FindObjectOfType<BossHealthManager> ();
		timeExplosionDelay = 0.5f;
		timeExplosionDelayCounter = timeExplosionDelay;
		offset = new Vector3 (0.2f, 0.5f, 0f);
		currentExplosionPos = 1;
	}

	public void Update() {
		if (boss.isDeath) {
			timeExplosionDelayCounter -= Time.deltaTime;
			if (timeExplosionDelayCounter <= 0) {
				if (currentExplosionPos == 1) {
					cloneExplosion = Instantiate (explosion, transform.position + offset, transform.rotation);
					cloneExplosion.transform.localScale = new Vector3 (cloneExplosion.transform.localScale.x, cloneExplosion.transform.localScale.y, cloneExplosion.transform.localScale.z) * 2f;

					currentExplosionPos = 2;
				} else if (currentExplosionPos == 2) {
					cloneExplosion = Instantiate (explosion, transform.position - offset, transform.rotation);
					cloneExplosion.transform.localScale = new Vector3 (cloneExplosion.transform.localScale.x, cloneExplosion.transform.localScale.y, cloneExplosion.transform.localScale.z) * 2f;
					currentExplosionPos = 1;
				}
				timeExplosionDelayCounter = timeExplosionDelay;
			}
			var parent = transform.parent;
			Destroy (parent.gameObject);
			cloneExplosion = Instantiate (explosion, transform.position, transform.rotation);
			cloneExplosion.transform.localScale = new Vector3 (cloneExplosion.transform.localScale.x, cloneExplosion.transform.localScale.y, cloneExplosion.transform.localScale.z) * 4f;

		}
	}
}

