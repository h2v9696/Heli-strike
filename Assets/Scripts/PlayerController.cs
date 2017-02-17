using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	//private bool isMoving;
	//public GameObject point;
	private Vector2 target;
	public GameObject shadow;
	//firing
	public GameObject missile;
	public GameObject missileFirePoint;
	private int firePoint = 1;


	// Use this for initialization
	void Start () {

		transform.position = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		Move ();
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			Shot ();
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
	void Shot ()
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
}
