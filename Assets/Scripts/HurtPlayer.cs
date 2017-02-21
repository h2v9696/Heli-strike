using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
	public int damageGiven;
	//public GameObject weapon;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			//damageGiven = weapon.power;
			//HealthManager.HurtPlayer (damageToGive);

			var player = other.GetComponent<PlayerController> ();
			Debug.Log ("Player took dam");
		}
	}
}
