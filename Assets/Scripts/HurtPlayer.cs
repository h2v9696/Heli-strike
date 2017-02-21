using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
	public int damageGiven;
	private PlayerHealthManager player;
	void Start () {
		player = FindObjectOfType<PlayerHealthManager> ();
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			
			//damageGiven = weapon.power;
			//HealthManager.HurtPlayer (damageToGive);

			player.TakeDamage (0);
			Debug.Log ("Player took dam");
		}
	}
}
