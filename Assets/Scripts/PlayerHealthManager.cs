using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

	public int playerHealth;
	//for death effect

	public PlayerController playerController;
	public Explosion explosion;


	private Animator animator;


	private Slider healthBar;
	public ProgressBar Slider;

	void Start () 
	{
		playerController = GetComponent<PlayerController> ();
		Slider = FindObjectOfType<ProgressBar> ();
		healthBar = Slider.GetComponent<Slider> ();
		//healthBar.maxValue = playerHealth;
	}

	// Update is called once per frame
	void Update () 
	{
		animator = GetComponent<Animator> ();
		healthBar.value = playerHealth;
	}

	public void TakeDamage(int damageTaken) {
		playerHealth -= damageTaken;


	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "EnemyBullet") 
		{
			if (playerHealth <= 0) 
			{
				playerController.isLiving = false;
			} else 
			{
				animator.SetTrigger ("Damage");
			}
		}
	}
}
