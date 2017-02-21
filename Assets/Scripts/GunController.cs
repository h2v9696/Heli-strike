using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	private PlayerController player;

	void Start() {
		
		player = FindObjectOfType<PlayerController> ();
	
	}
	void Update() {
		if (player != null) {

			Vector3 relativePos = player.transform.position - transform.position;
		
			float angle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90;
		
			Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * 6f);
		}
	}
}
