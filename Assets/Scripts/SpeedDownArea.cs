using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownArea : MonoBehaviour {
	public float downSpeed = 1f;
	void OnTriggerStay2D(Collider2D other)
	{if (other.name == "Player")
			ScrollBackground.speed = downSpeed;

	}
}
