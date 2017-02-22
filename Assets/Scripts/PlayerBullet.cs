using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public int moveSpeed;
	public float lifeTime;
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * moveSpeed;
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
