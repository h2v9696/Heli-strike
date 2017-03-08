/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public static float speed = 0.5f;
	public ProgressBar theProgressBar;

	void Start()
	{
		theProgressBar = FindObjectOfType<ProgressBar> ();
	}


	void Update()
	{	
		if (theProgressBar.progress >= theProgressBar.maxValue)
			speed = 0f;

		GetComponent<Rigidbody2D> ().velocity = (Vector3.up * speed * -1);


	}


}

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public static float speed = 0.5f;
	public ProgressBar theProgressBar;
	public GameObject eventPoint;
	public GameObject eventCompleteEnemy;
	private int enemyAlive =0;

	void Start()
	{
		theProgressBar = FindObjectOfType<ProgressBar> ();
		eventPoint = GameObject.Find ("EventPoint");

	}


		void Update()
		{	
		if (theProgressBar.progress >= theProgressBar.maxValue)
			speed = 0f;

	if (theProgressBar.distantToEvent <= 0) 
		{

		if (eventCompleteEnemy = GameObject.FindGameObjectWithTag ("Boss"))
			enemyAlive = 1;
		else
			enemyAlive = 0;


	}


	switch(enemyAlive)
		{
		case(1):
			speed = 0f;
			break;

		default:
			
			break;
		}

		GetComponent<Rigidbody2D>().velocity = (Vector3.up * speed * -1);
		}
			}





		