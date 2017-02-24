using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	//private PauseScreen pauseMenu;
	//private bool isPausing;
	//private bool isMoving;
	//public GameObject point;
	private Vector2 target;
	public GameObject shadow;


	//firing missile
	public GameObject missile;
	public GameObject missileFirePoint;
	public float missileShotDelay;
	private float missileShotDelayCounter;
	private int firePoint = 1;

	//firing bullet
	public GameObject bullet;
	public float bulletShotDelay;
	private float bulletShotDelayCounter;

	//deathMovement
	public bool isLiving;
	private Sprite damageSprite;
	private Vector3 firstScale;
	public GameObject explosion;

	public GameObject[] fireType;
	public int currentFireType;



	// Use this for initialization
	void Start () {
		isLiving = true;
		firstScale = transform.lossyScale;
		transform.position = new Vector3 (0, 0, 0);
		damageSprite = Resources.Load<Sprite> ("DamagePlayer");
		//pauseMenu = FindObjectOfType<PauseScreen> ();
		//isPausing = pauseMenu.isPaused;
	}
	
	// Update is called once per frame
	void Update () {

		if (isLiving ) 
		{

			//change fire type
			if (Input.GetMouseButtonDown (1)) 
			{
				currentFireType++;
				if (currentFireType >= fireType.Length)
					currentFireType = 0;
			}

			Move ();
			if (Input.GetKeyDown (KeyCode.Z)) 
			{
				shotMissile ();
				missileShotDelayCounter = missileShotDelay;
	
			}
			if (Input.GetKey (KeyCode.Z)) 
			{
				missileShotDelayCounter -= Time.deltaTime;
				if (missileShotDelayCounter <= 0) 
				{
					shotMissile ();
					missileShotDelayCounter = missileShotDelay;
				}

			}
			if (Input.GetKeyDown (KeyCode.X)) 
			{
				shot (fireType[currentFireType]);
				bulletShotDelayCounter = bulletShotDelay;

			}
			if (Input.GetKey(KeyCode.X)) 
			{
				bulletShotDelayCounter -= Time.deltaTime;
				if (bulletShotDelayCounter <= 0) 
				{
					shot (fireType[currentFireType]);
					bulletShotDelayCounter = bulletShotDelay;
				}

			}
		}

		if (isLiving == false) 
		{
			GetComponent<SpriteRenderer> ().sprite = damageSprite;
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
			//GetComponent<SpriteRenderer> ().sprite = damageSprite;
			explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x * 3f, explosion.transform.localScale.y * 3f, explosion.transform.localScale.z * 3f);
			Instantiate (explosion, transform.position, transform.rotation);
			explosion.transform.localScale = new Vector3 (explosion.transform.localScale.x / 3f, explosion.transform.localScale.y / 3f, explosion.transform.localScale.z / 3f);
			Destroy (gameObject);
			isLiving = true;
		}

	}

	void shot(GameObject fireType)
	{
		Transform firePosition;
		for (int i = 0; i < fireType.transform.childCount; i++) 
		{
			firePosition = fireType.transform.GetChild (i);
			Instantiate (bullet, firePosition.transform.position, firePosition.transform.rotation);
		}
	}
}
