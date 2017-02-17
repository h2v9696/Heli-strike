using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour 
{
	void Start()
	{Debug.Log (" ");}
	void OnTriggerExit2D(Collider2D c)
	{
		Debug.Log ("Left the Area");
		Destroy (c.gameObject);
	}


}
