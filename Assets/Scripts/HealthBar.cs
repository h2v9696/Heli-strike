using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	
	private Slider healthBar;  
	public PlayerHealthManager player;
	void Start()
	{	
		player = FindObjectOfType<PlayerHealthManager> ();
		healthBar = GetComponent<Slider> ();
		healthBar.maxValue = player.playerHealth;
	}
	void Update()
	{	healthBar.value = player.playerHealth;
		//healthBar.maxValue = player.playerHealth;
		Debug.Log (healthBar.maxValue);
	}

}
