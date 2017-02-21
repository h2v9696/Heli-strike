using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	public int speed = 10;
	public float lifeTime = 2;
	public int power = 1;
	private PlayerHealthManager player;
	void Start () {
		player = FindObjectOfType<PlayerHealthManager> ();
		//Vector3 relativePos = player.transform.position - transform.position;
	
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * speed;
		//Xoa GO sau lifetime
		Destroy (gameObject, lifeTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {


			player.TakeDamage (power);
			//Debug.Log ("Player took dam");
			Destroy (gameObject);
		}
	}

}
