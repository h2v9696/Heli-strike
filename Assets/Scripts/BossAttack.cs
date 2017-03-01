using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {
	public GameObject enemyBullet;
	public PlayerController player;
	public Transform shootPoint;
	public float shootDelay;
	private float shootCounter;
	public bool isSide;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
		shootCounter = 0;
	}

	void Update () {
		shootCounter -= Time.deltaTime;
		if (shootCounter <= 0) {
			if (!isSide)
				StartCoroutine ("Shoot");
			else StartCoroutine ("SideShoot");
			shootCounter = shootDelay;
		}
	}

	IEnumerator Shoot() {
		int i=9;
		while (0 < i) {
				i--;
				Instantiate (enemyBullet, shootPoint.position, gameObject.transform.rotation);
				yield return new WaitForSeconds (0.2f);
		}
	}
	IEnumerator SideShoot() {
		int i=9;
		while (0 < i) {
			i--;
			Instantiate (enemyBullet, shootPoint.position, gameObject.transform.rotation);
			yield return new WaitForSeconds (0.2f);
		}
	}
}
