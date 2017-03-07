using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {
	private Slider bossHealthBar;

	public GameObject boss;
	public GameObject bossBar;

	// Use this for initialization
	void Start () {
		//boss = GameObject.FindWithTag ("Boss");
		bossHealthBar = GetComponent<Slider> ();
		//bossHealthBar.maxValue = boss.GetComponent<BossHealthManager> ().bossHealth;
	}
	
	// Update is called once per frame
	void Update () {
		boss = GameObject.FindGameObjectWithTag ("Boss");
		//bossBar.SetActive (true);
		bossHealthBar.maxValue = boss.GetComponent<BossHealthManager> ().bossMaxHealth;
		bossHealthBar.value = boss.GetComponent<BossHealthManager> ().bossHealth;
		if (bossHealthBar.value == 0)
			Destroy (bossBar);
	}
}
