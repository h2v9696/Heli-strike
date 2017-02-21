using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

	public int playerHealth;
	public Explosion explosion;
	private Animator animator;
	private Slider healthBar;
	public GameObject Slider;

	void Start () {
		healthBar = Slider.GetComponent<Slider> ();
		//healthBar.maxValue = playerHealth;
	}

	// Update is called once per frame
	void Update () {
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
				Instantiate (explosion, transform.position, transform.rotation);

				Destroy (gameObject);
			} else 
			{
				animator.SetTrigger ("Damage");
			}
		}
	}
}
