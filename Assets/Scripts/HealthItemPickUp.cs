using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemPickUp : MonoBehaviour {

	private PlayerHealthManager playerHealthManager;
	public int healthHealPoint;
	private Animator animator;

	private bool collected;


	// Use this for initialization
	void Start () {
		collected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (collected == true && GetComponent<AudioSource>().isPlaying == false)
		{
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{

			GetComponent<AudioSource> ().Play ();
			playerHealthManager = other.GetComponent<PlayerHealthManager> ();
			animator = other.GetComponent<Animator> ();
			playerHealthManager.TakeDamage (-healthHealPoint);
			animator.SetTrigger ("Collect");

			Destroy (GetComponent<Collider2D> ());
			Destroy (GetComponent<SpriteRenderer> ());

			collected = true;
		}
	}
}
