using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {

	public int bossMaxHealth;
	public int bossHealth;

	private Animator animator;

	public bool isDeath;


	void Start () {
		bossHealth = bossMaxHealth;
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		if (bossHealth <= 0) {

			isDeath = true;

		}
	}

	public void TakeDamage(int damageTaken) {
		bossHealth -= damageTaken;
		animator.SetTrigger ("Damage");

	}
}
