using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

	public int playerHealth;
	//for death effect

	private PlayerController playerController;
	public Explosion explosion;

	private int playerMaxHealth;


	private Animator animator;


	//private Slider healthBar;
	//public GameObject Slider;

	void Start () 
	{
		playerController = GetComponent<PlayerController> ();
		playerMaxHealth = playerHealth;
		//Slider = FindObjectOfType<ProgressBar> ();

		//healthBar = Slider.GetComponent<Slider> ();
		//healthBar.maxValue = playerHealth;
	}

	// Update is called once per frame
	void Update () 
	{
		animator = GetComponent<Animator> ();
		if (playerHealth > playerMaxHealth) 
		{
			playerHealth = playerMaxHealth;
		}

		if (playerHealth <= 0) 
		{
			playerController.isLiving = false;
		}

		//healthBar.value = playerHealth;
	}

	public void TakeDamage(int damageTaken) {
		playerHealth -= damageTaken;


	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "EnemyBullet") 
		{

				animator.SetTrigger ("Damage");

		}

	}
	public int playerCurrentHealth ()
	{
		return playerHealth;
	}
}
