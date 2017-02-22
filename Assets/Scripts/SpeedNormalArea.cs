using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedNormalArea : MonoBehaviour {
	public float normalSpeed = 2f;
	void OnTriggerStay2D(Collider2D other)
	{if (other.name == "Player")
			ScrollBackground.speed = normalSpeed;

	}
}
