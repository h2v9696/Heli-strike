using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	public int moveSpeed;
	public float lifeTime;

	public GameObject missileFireTail;
	public GameObject missileFireTailShadow;


	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * moveSpeed;
		Destroy (gameObject, lifeTime);
	}
	void Update ()
	{
		missileFireTail.transform.localScale = new Vector2 (missileFireTail.transform.localScale.x + missileFireTail.transform.localScale.x * 0.4f * Time.deltaTime, missileFireTail.transform.localScale.y + missileFireTail.transform.localScale.y * 0.4f * Time.deltaTime);
		missileFireTail.transform.position = new Vector2 (missileFireTail.transform.position.x, missileFireTail.transform.position.y - missileFireTail.transform.position.y * 0.03f * Time.deltaTime);

		missileFireTailShadow.transform.localScale = new Vector2 (missileFireTailShadow.transform.localScale.x + missileFireTailShadow.transform.localScale.x * 0.4f * Time.deltaTime, missileFireTailShadow.transform.localScale.y + missileFireTailShadow.transform.localScale.y * 0.4f * Time.deltaTime);
		missileFireTailShadow.transform.position = new Vector2 (missileFireTailShadow.transform.position.x, missileFireTailShadow.transform.position.y - missileFireTailShadow.transform.position.y * 0.03f * Time.deltaTime);
	}
	

}
