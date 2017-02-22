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
	private Slider progressBar;  
 	// Use this for initialization
	void Start () {
		curPoint.transform.SetParent (camera_curPoint.transform);
		startPoint.transform.SetParent (backGround_startPoint.transform);
		progressBar = GetComponent<Slider> ();
		float maxValue = endPoint.transform.position.y - startPoint.transform.position.y;
		progressBar.maxValue = maxValue;
	}
	
	// Update is called once per frame
	void Update () {
		float progress = curPoint.transform.position.y - startPoint.transform.position.y;
		progressBar.value = progress;
	}
}
