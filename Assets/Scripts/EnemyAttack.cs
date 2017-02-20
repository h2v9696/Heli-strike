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

	void Start () {
		player = FindObjectOfType<PlayerController> ();
		shootCounter = 0;
		if (!canShot) {
			gameObject.SetActive (false);
		}
	}

	void Update () {
		shootCounter -= Time.deltaTime;
		if (shootCounter<=0) {
			StartCoroutine ("DoubleShoot");
			shootCounter = shootDelay;
		}

	}
	IEnumerator DoubleShoot(){
		Instantiate (enemyBullet, shootPoint.position, gameObject.transform.rotation);
		yield return new WaitForSeconds (0.1f);
		Instantiate (enemyBullet, shootPoint.position, gameObject.transform.rotation);

	}
}
