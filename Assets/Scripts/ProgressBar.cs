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

	public bool haveEventPoint=false;
	private Slider progressBar;  
 	// Use this for initialization
	void Start () {
		
		//backGround_startPoint = GameObject.Find("Background");
		//camera_curPoint = GameObject.Find ("Main Camera");
		//startPoint = GameObject.Find ("StartPoint");
		//endPoint = GameObject.Find ("EndPoint");
		//curPoint = GameObject.Find ("CurPoint");

		curPoint.transform.SetParent (camera_curPoint.transform);
		startPoint.transform.SetParent (backGround_startPoint.transform);
		if (eventPoint = GameObject.Find ("EventPoint")) {
			haveEventPoint = true;
			eventPoint.transform.SetParent (backGround_startPoint.transform);
		}

		progressBar = GetComponent<Slider> ();
		//float 



		//maxValue = endPoint.transform.position.y - startPoint.transform.position.y;
		//progressBar.maxValue = maxValue;
	}
	
	// Update is called once per frame
	void Update () {
		maxValue = endPoint.transform.position.y - startPoint.transform.position.y;
		progressBar.maxValue = maxValue;


		if (haveEventPoint) {
			distantToEvent = eventPoint.transform.position.y - curPoint.transform.position.y;
		}
		progress = curPoint.transform.position.y - startPoint.transform.position.y;
		progressBar.value = progress;
	}
}
