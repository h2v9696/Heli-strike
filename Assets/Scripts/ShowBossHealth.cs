using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBossHealth : MonoBehaviour {
	public GameObject boss;
	public GameObject bossBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(boss = GameObject.FindGameObjectWithTag ("Boss"))
			bossBar.SetActive (true);
	}
}
