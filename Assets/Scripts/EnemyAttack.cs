using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public GameObject enemyBullet;
	public PlayerController player;
	public Transform shootPoint;
	public float shootDelay;
	private float shootCounter;
	public bool canShot;
	public bool isSingleShot;
	public bool isConstruct;
	public bool isFlying;
	public bool isMissile;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
		shootCounter = 0;
		if (!canShot) {
			gameObject.SetActive (false);
		}
	}

	void Update () {
		shootCounter -= Time.deltaTime;
		if (shootCounter <= 0 && isConstruct) {
			StartCoroutine ("ConstructShoot");
			shootCounter = shootDelay;
		} else if (shootCounter <= 0 && isFlying) {
			StartCoroutine ("FlyShoot");
			shootCounter = shootDelay;
		} else {
			if (shootCounter <= 0 && !isSingleShot) {
				StartCoroutine ("DoubleShoot");
				shootCounter = shootDelay;
			}
			if (shootCounter <= 0 && isSingleShot) {
				Instantiate (enemyBullet, shootPoint.position, gameObject.transform.rotation);

				shootCounter = shootDelay;
			}
		}

	}
	IEnumerator DoubleShoot() {
		Instantiate (enemyBullet, shootPoint.position, gameObject.transform.rotation);
		yield return new WaitForSeconds (0.2f);
		Instantiate (enemyBullet, shootPoint.position, gameObject.transform.rotation);
	}

	IEnumerator ConstructShoot() {
		int i=4;
		Vector3 offset = new Vector3(0.25f,0,0);
		while (0 < i) {
			i--;
			Instantiate (enemyBullet, shootPoint.position + offset, gameObject.transform.rotation);
			yield return new WaitForSeconds (0.1f);
			Instantiate (enemyBullet, shootPoint.position - offset, gameObject.transform.rotation);
		}
	}

	IEnumerator FlyShoot() {
		int i=3;
		Vector3 offset = new Vector3(0.5f,0,0);
		if (!isMissile) {
			while (0 < i) {
				i--;
				if (!isSingleShot) {
					Instantiate (enemyBullet, shootPoint.position + offset, gameObject.transform.rotation);
					yield return new WaitForSeconds (0.1f);
					Instantiate (enemyBullet, shootPoint.position - offset, gameObject.transform.rotation);
				} else {
					Instantiate (enemyBullet, shootPoint.position, gameObject.transform.rotation);
					yield return new WaitForSeconds (0.1f);
				}
			}
		} else {
			Vector3 offset2 = new Vector3(0.3f,0,0);
			Instantiate (enemyBullet, shootPoint.position + offset2, gameObject.transform.rotation);
			yield return new WaitForSeconds (0.2f);
			Instantiate (enemyBullet, shootPoint.position - offset2, gameObject.transform.rotation);

		}
	}
}
