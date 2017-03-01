using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissleCount : MonoBehaviour {
	private Text theText;
	private PlayerController player;
	// Use this for initialization
	void Start () {
		theText = GetComponent<Text> ();
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		theText.text = " x " + player.numberMissile;
	}
}
