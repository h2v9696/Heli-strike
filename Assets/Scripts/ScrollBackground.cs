using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public static float speed = 0.5f;
	public ProgressBar theProgressBar;

	void Start()
	{
		theProgressBar = FindObjectOfType<ProgressBar> ();
	}


	void Update()
	{	
		if (theProgressBar.progress >= theProgressBar.maxValue)
			speed = 0f;

		GetComponent<Rigidbody2D> ().velocity = (transform.up * speed * -1);


	}


}
