using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour {

	public float moveSpeed;
	public Transform points;
	private Transform[] listPoints = new Transform[20];
	private float distance;
	private int nextPoint = 0;
	//public float turnSpeed = 1.5f;
	private float speed;
	public bool canMove;
	public float rotationTime;
	public GameObject shadow;

	private BossHealthManager bossHealth;

	public Transform deathPoint;
	public bool cantRotate;
	public float speedAdd = 0.15f;
	public bool isBoss;
	public bool isFlying;
	public bool isLoop;
	public bool isFinalBoss;
	void Start () {


		bossHealth = GetComponent<BossHealthManager> ();

		//Lay list cac diem de di chuyen

		if (points.transform.childCount != 0) {
			for (int i = 0; i < points.transform.childCount; i++) {
				listPoints [i] = points.transform.GetChild (i);
			}
		}
		if (canMove)
			speed = moveSpeed;
		else
			speed = 0;

	}
	void Update () {

		if (points.transform.childCount != 0) {
			if (!isFinalBoss) {
				if (isFlying && (bossHealth.bossHealth <= 0) && deathPoint != null) {
					speed += speedAdd;
					transform.position = Vector3.MoveTowards (transform.position, deathPoint.position, Time.deltaTime * speed);
				} else {
					if ((isBoss || isLoop) && nextPoint == 0) {
						speed = moveSpeed;
					}
					distance = Vector3.Distance (transform.position, listPoints [nextPoint].position);
					Vector3 relativePos = listPoints [nextPoint].position - transform.position;
					if (!cantRotate) {
						float angle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90;
						Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
						transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationTime);
					}
					transform.position = Vector3.MoveTowards (transform.position, listPoints [nextPoint].position, Time.deltaTime * speed);

					if (distance <= 0.5f) {
						nextPoint++;
					} 
					//else	speed = moveSpeed;

					if (nextPoint == points.transform.childCount) {
						if (!isBoss && !isLoop) {
							nextPoint = points.transform.childCount - 1;
							speed = 0;

						} else {
							nextPoint = 0;
							if (isBoss)
								speed = 0.5f;
						}
					}
				}
			} else {
				if (isFlying && (bossHealth.bossHealth <= 0) && deathPoint != null) {
					speed += speedAdd;
					transform.position = Vector3.MoveTowards (transform.position, deathPoint.position, Time.deltaTime * speed);
				} else {
					if (nextPoint == 0 || nextPoint == 3) {
						speed = 2f;

						cantRotate = true;
					} else {
						speed = moveSpeed;
						cantRotate = false;
					}
					distance = Vector3.Distance (transform.position, listPoints [nextPoint].position);
					Vector3 relativePos = listPoints [nextPoint].position - transform.position;
					if (!cantRotate) {
						float angle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90;
						Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
						transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationTime);
					}
					transform.position = Vector3.MoveTowards (transform.position, listPoints [nextPoint].position, Time.deltaTime * speed);

					if (distance <= 0.5f) {
						nextPoint++;
					} 
					if (nextPoint == points.transform.childCount) {
						nextPoint = 0;

						speed = 0.5f;
					}
				}
			}
		} else {
			if (isFlying) {
				if ((bossHealth.bossHealth <= 0) && deathPoint != null) {
					speed += speedAdd;
					transform.position = Vector3.MoveTowards (transform.position, deathPoint.position, Time.deltaTime * speed);
				}
			}
		}
		//Vi tri bong
		if (shadow != null) {
			shadow.transform.position = new Vector3 (transform.position.x - transform.position.x * 0.1f, transform.position.y - transform.position.y * 0.1f, transform.position.z);
		}

	}
}
