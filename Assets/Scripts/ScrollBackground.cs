using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public float speed = 0.5f;

	void Update()
	{
		//Vector2 offset = new Vector2 (0,Time.time * speed);
		//GetComponent<Renderer>().material.SetTextureOffset("_MainText",offset);

		//GetComponent<Renderer> ().material.mainTextureOffset = offset;
		//GetComponent<Renderer>().sharedMaterial.SetTextureOffset(

		//layers = new Transform[transform.childCount];
		//for (int i = 0; i < transform.childCount; i++) {
		//	layers [i] = transform.GetChild (i);
		//}

		GetComponent<Rigidbody2D> ().velocity = (transform.up * speed * -1);
	}
}
