using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMissileItemPickUp : MonoBehaviour {

	private PlayerController playerController;
	public int numberMissileToAdd;
	private Animator animator;
	public bool isUpgradeType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			playerController = other.GetComponent<PlayerController> ();
			animator = other.GetComponent<Animator> ();


			playerController.addMissile (numberMissileToAdd);
			animator.SetTrigger ("Collect");
			if (isUpgradeType) 
			{
				playerController.changeMissileType ();
			}
			Destroy (gameObject);
		}
	}
}
