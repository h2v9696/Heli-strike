using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float maxMoveSpeed;
	private PauseScreen pauseMenu;
	public bool isPausing;

	private float distance;
	private float previousDistance;
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
	private bool canUpSpeed;

	//firing bullet
	public GameObject bullet;
	public float bulletShotDelay;
	private float bulletShotDelayCounter;

	//deathMovement
	public bool isLiving;
	private Sprite damageSprite;
	private Vector3 firstScale;
	//public GameObject explosion;
	private PlayerDeathParticle playerDeathParticle;

	public GameObject[] fireType;
	public int currentFireType;
	private bool isFireBullet;
	//count number of missile of player
	public int numberMissile;
	private int maxNumberMissile;


	//for audio when shooting
	public AudioSource shootingSound;



	// Use this for initialization
	void Start () 
	{
		isLiving = true;
		firstScale = transform.lossyScale;
		transform.position = new Vector3 (0, 0, 0);
		damageSprite = Resources.Load<Sprite> ("DamagePlayer");

		pauseMenu = FindObjectOfType<PauseScreen> ();
		isPausing = pauseMenu.getIsPaused();
		playerDeathParticle = GetComponent<PlayerDeathParticle> ();
		isFireBullet = true;
		maxNumberMissile = numberMissile;


		maxMoveSpeed = moveSpeed;
		distance = 0f;
		previousDistance = 0f;

		canUpSpeed = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		isPausing = pauseMenu.getIsPaused();
		if (isLiving && !isPausing ) 
		{
			Move ();



		
			if (Input.GetMouseButtonDown (0)) 
			{
				if (isFireBullet) 
				{
					shot (fireType [currentFireType]);
					bulletShotDelayCounter = bulletShotDelay;
				} else 
				{
					shotMissile ();
					numberMissile -=1;
					missileShotDelayCounter = missileShotDelay;
				}
			}
			if (Input.GetMouseButton (0)) 
			{
				if (isFireBullet) 
				{
					bulletShotDelayCounter -= Time.deltaTime;
					if (bulletShotDelayCounter <= 0) 
					{
						shot (fireType[currentFireType]);
						bulletShotDelayCounter = bulletShotDelay;
					}

				} else 
				{
					missileShotDelayCounter -= Time.deltaTime;
					if (missileShotDelayCounter <= 0) 
					{
						shotMissile ();
						numberMissile -=1;
						missileShotDelayCounter = missileShotDelay;
					}
				}
			}

			//change bullet fire type
			/*
			 if (Input.GetMouseButtonDown (1)) 
			{
				currentFireType++;
				if (currentFireType >= fireType.Length)
					currentFireType = 0;
			}
			*/

			//change fire type
			if (Input.GetAxis ("Mouse ScrollWheel") != 0f) 
			{
				isFireBullet = !isFireBullet;
			}

			if (Input.GetKeyDown (KeyCode.Z)) 
			{
				isFireBullet = true;
			}
			if (Input.GetKeyDown (KeyCode.X)) 
			{
				isFireBullet = false;
			}


			//fire missile by key
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				shotMissile ();
				numberMissile -=1;
				missileShotDelayCounter = missileShotDelay;
			}
			if (Input.GetKey (KeyCode.Space)) 
			{
				missileShotDelayCounter -= Time.deltaTime;
				if (missileShotDelayCounter <= 0) 
				{
					shotMissile ();
					numberMissile -=1;
					missileShotDelayCounter = missileShotDelay;
				}
			}

			//for reset number of missile
			if (numberMissile < 0)
				numberMissile = 0;
			if (numberMissile > maxNumberMissile)
				numberMissile = maxNumberMissile;
		}

		if (isLiving == false) 
		{
			GetComponent<SpriteRenderer> ().sprite = damageSprite;
			playerDeathParticle.deathParticle(firstScale);
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

		// dieu khien toc do di chuyen qua moi frame
		if (distance > previousDistance) 
		{
			moveSpeed = maxMoveSpeed * distance * 0.5f;
			if (moveSpeed > maxMoveSpeed * 2f) 
			{
				moveSpeed = maxMoveSpeed * 2f;
			}

		}
		else if (distance < previousDistance) 
		{
			moveSpeed = maxMoveSpeed * distance * 0.2f ;
			if (moveSpeed < maxMoveSpeed * 0.2f) 
			{
				moveSpeed = maxMoveSpeed * 0.2f;
			}
		}

		previousDistance = distance;
		distance = Vector2.Distance (target, (Vector2)transform.position);


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
		if (numberMissile > 0) 
		{
			if (firePoint == 1) {
				Instantiate (missile, missileFirePoint.transform.position + offset, missile.transform.rotation);
				firePoint = 2;
				return;
			}
			if (firePoint == 2) {
				Instantiate (missile, missileFirePoint.transform.position - offset, missile.transform.rotation);
				firePoint = 1;
				return;
			}


		}

	}


	void shot(GameObject fireType)
	{
		shootingSound.Play ();
		Transform firePosition;
		for (int i = 0; i < fireType.transform.childCount; i++) 
		{
			firePosition = fireType.transform.GetChild (i);
			Instantiate (bullet, firePosition.transform.position, firePosition.transform.rotation);
		}
	}


	public void setIsLiving()
	{
		isLiving = true;

	}



	public void addMissile(int numberToAdd)
	{
		numberMissile += numberToAdd;
	}


	public void changeMissileType()
	{
		missile = Resources.Load<GameObject> ("Missile_2");
		missileShotDelay = missileShotDelay / 2;
	}

	public void changeBulletType()
	{
		currentFireType += 1;
		if (currentFireType >= fireType.Length)
			currentFireType = fireType.Length;
		if (canUpSpeed == false) {
			canUpSpeed = true;
		} else if (canUpSpeed == true) 
		{
			bulletShotDelay = bulletShotDelay / 2;
			canUpSpeed = false;
		}
	}
}
