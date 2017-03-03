using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMissileItemPickUp : MonoBehaviour {

	private PlayerController playerController;
	public int numberMissileToAdd;
	private Animator animator;
	public bool isUpgradeType;


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

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			

			GetComponent<AudioSource> ().Play ();

			playerController = other.GetComponent<PlayerController> ();
			animator = other.GetComponent<Animator> ();


			playerController.addMissile (numberMissileToAdd);
			animator.SetTrigger ("Collect");
			if (isUpgradeType) 
			{
				playerController.changeMissileType ();
			}
			Destroy (GetComponent<Collider2D> ());
			Destroy (GetComponent<SpriteRenderer> ());
	
			collected = true;
		}
	}
}
