using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public float speed = 0.5f;
	private float fixSpeed;
	void Start() {
		fixSpeed = speed;
	}

	void Update()
	{
		speed = fixSpeed;

		GetComponent<Rigidbody2D> ().velocity = (transform.up * speed * -1);
		Debug.Log (speed);

	}
	public float GetSpeed() {
		return speed;
	}
	public void SetSpeed(float newSpeed) {
		fixSpeed = newSpeed;
	}

}
