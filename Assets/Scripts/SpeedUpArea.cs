using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpArea : MonoBehaviour {
	public float upSpeed = 4f;

	void Start()
	{
		Time.timeScale = 1;
	}
	void OnTriggerStay2D(Collider2D other)
	{if (other.name == "Player")
			ScrollBackground.speed = upSpeed;

	}
}
