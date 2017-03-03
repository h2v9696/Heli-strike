using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBulletType : MonoBehaviour {


	private PlayerController playerController;
	private Animator animator;

	private bool collected;
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


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
	
			GetComponent<AudioSource> ().Play ();
			playerController = other.GetComponent<PlayerController> ();
			animator = other.GetComponent<Animator> ();


			playerController.changeBulletType();
			animator.SetTrigger ("Collect");
			if (GetComponent<AudioSource> ().isPlaying == false) {
				Destroy (gameObject);
			}
			Destroy (GetComponent<Collider2D> ());
			Destroy (GetComponent<SpriteRenderer> ());

			collected = true;
		}
	}
}
