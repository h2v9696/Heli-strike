using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBulletType : MonoBehaviour {


	private PlayerController playerController;
	private Animator animator;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			playerController = other.GetComponent<PlayerController> ();
			animator = other.GetComponent<Animator> ();


			playerController.changeBulletType();
			animator.SetTrigger ("Collect");
			Destroy (gameObject);
		}
	}
}
