using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBossV2 : MonoBehaviour {

	public GameObject bossScreen;
	public GameObject beforeBsOne;
	public GameObject beforeBsTwo;
	//public GameObject EndPoint
	private ProgressBar progressBar;
	private float chieuDaiMotScreen;
	public GameObject endPoint;
	public GameObject bossAlive;

	void Start()
	{
		chieuDaiMotScreen =  beforeBsTwo.transform.position.y - beforeBsOne.transform.position.y;
		progressBar = FindObjectOfType<ProgressBar>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{	
		
		if (other.tag == "Player") {
			Instantiate (bossScreen, this.transform.position + new Vector3 (0, chieuDaiMotScreen, 0),
				bossScreen.transform.rotation);
			if (bossAlive = GameObject.FindGameObjectWithTag ("Boss"))
				endPoint.transform.position += new Vector3 (0, chieuDaiMotScreen, 0);
			Destroy (GetComponent<BoxCollider2D> ());
		}
	}
}
