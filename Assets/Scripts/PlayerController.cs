using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	//private bool isMoving;
	//public GameObject point;
	private Vector2 target;
	public GameObject shadow;

	//firing missile
	public GameObject missile;
	public GameObject missileFirePoint;
	private int firePoint = 1;

	//firing bullet
	public GameObject bullet;

	//deathMovement
	public bool isLiving;
	private Vector3 firstScale;
	public GameObject explosion;



	// Use this for initialization
	void Start () {
		isLiving = true;
		firstScale = transform.lossyScale;
		transform.position = new Vector3 (0, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {

		if (isLiving) 
		{
			Move ();
			if (Input.GetKeyDown (KeyCode.Z)) 
			{
				shotMissile ();
			}
			if (Input.GetKeyDown (KeyCode.X)) 
			{
				shot ();
			}
		}

		if (isLiving == false) 
		{
			deathMovement ();
		}
	}

	void Move ()
	{
		// lay toa do 2 goc tren duoi cua camera va toa do player

		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
		Vector2 pos = transform.position;

		//di chuyen bang chuot

		target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		pos = Vector2.MoveTowards (transform.position, target, moveSpeed);

		//dieu khien vi tri cua bong
		shadow.transform.position = new Vector2(transform.position.x - transform.position.x * 0.1f,transform.position.y - transform.position.y * 0.1f);

		//gioi han vi tri di chuyen cua player

		pos.x = Mathf.Clamp (pos.x,min.x + 1f ,max.x - 1f);
		pos.y = Mathf.Clamp (pos.y, min.y + 1f, max.y - 1f);
		transform.position = pos;

	}

	void shotMissile ()
	{
		//int firePoint;
		Vector3 offset = new Vector3 (0.3f, 0, 0);
		if (firePoint == 1) 
		{
			Instantiate (missile, missileFirePoint.transform.position + offset, missile.transform.rotation);
			firePoint = 2;
			return;
		}
		if (firePoint == 2) 
		{
			Instantiate (missile, missileFirePoint.transform.position - offset, missile.transform.rotation);
			firePoint = 1;
			return;
		}
	}

	void deathMovement()
	{
		if (transform.localScale.x > firstScale.x * 3 / 4) {
			transform.localScale = new Vector2 (transform.localScale.x - transform.localScale.x * 0.004f, transform.localScale.y - transform.localScale.y * 0.004f);
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 10);
		} else 
		{
			explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x * 3f, explosion.transform.localScale.y * 3f, explosion.transform.localScale.z * 3f);
			Instantiate (explosion, transform.position, transform.rotation);
			explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x / 3f, explosion.transform.localScale.y / 3f, explosion.transform.localScale.z / 3f);
			Destroy (gameObject);
			isLiving = true;
		}

	}

	void shot()
	{
		Instantiate (bullet, missileFirePoint.transform.position, missileFirePoint.transform.rotation);
	}
}
