using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
	public float moveSpeed;
	public Transform points;
	private Transform[] listPoints = new Transform[20];
	private float distance;
	private int nextPoint = 0;
	//public float turnSpeed = 1.5f;
	private float speed;
	public bool canMove;
	public float rotationTime;
	void Start () {
		//transform.rotation = Quaternion.identity;
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
			distance = Vector3.Distance (transform.position, listPoints [nextPoint].position);
			Vector3 relativePos = listPoints [nextPoint].position - transform.position;
			float angle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90;
			//transform.LookAt(transform.position + new Vector3(0,0,1),relativePos);
			Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			//Quaternion rotation = Quaternion.LookRotation (relativePos);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationTime);
			//SmoothLook(relativePos);
			//transform.localRotation = Quaternion.Slerp (transform.localRotation, rotation, Time.deltaTime*2);
			//transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
			transform.position = Vector3.MoveTowards (transform.position, listPoints [nextPoint].position, Time.deltaTime * speed);
			//GetComponent<Rigidbody2D>().velocity = direction*moveSpeed;

			//Debug.Log (direction);
			if (distance <= 0.5f) {
				//speed = turnSpeed;
				//transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				//if (distance <= 0.1f)
				nextPoint++;
			} else
				speed = moveSpeed;
			//Debug.Log (nextPoint);
			if (nextPoint == points.transform.childCount) {
				//nextPoint = points.transform.childCount - 1;
				nextPoint = 0;
				speed = 0;
			}
		}
	}
}
