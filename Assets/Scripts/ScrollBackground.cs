using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public static float speed = 0.5f;



	void Update()
	{
		

		GetComponent<Rigidbody2D> ().velocity = (transform.up * speed * -1);


	}


}
