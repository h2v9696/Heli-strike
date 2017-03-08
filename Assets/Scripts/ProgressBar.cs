using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
	public GameObject camera_curPoint;
	public GameObject backGround_startPoint;

	public GameObject startPoint;
	public GameObject endPoint;
	public GameObject curPoint;
	public GameObject eventPoint;

	public float maxValue;
	public float progress;
	public float distantToEvent;

	private Slider progressBar;  
 	// Use this for initialization
	void Start () {
		eventPoint = GameObject.Find ("EventPoint");
		//camera_curPoint = GameObject.Find ("Main Camera");
		//backGround_startPoint = GameObject.Find ("Background");
		curPoint.transform.SetParent (camera_curPoint.transform);
		startPoint.transform.SetParent (backGround_startPoint.transform);
		eventPoint.transform.SetParent (backGround_startPoint.transform);

		progressBar = GetComponent<Slider> ();
		//float 
		maxValue = endPoint.transform.position.y - startPoint.transform.position.y;
		progressBar.maxValue = maxValue;
	}
	
	// Update is called once per frame
	void Update () {
		//camera_curPoint = GameObject.Find ("Main Camera");
		//backGround_startPoint = GameObject.Find ("Background");
		//float
		distantToEvent =  eventPoint.transform.position.y - curPoint.transform.position.y;
		progress = curPoint.transform.position.y - startPoint.transform.position.y;
		progressBar.value = progress;
	}
}
