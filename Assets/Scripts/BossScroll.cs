using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScroll : MonoBehaviour {
	public float speed = 0.5f;
	public ProgressBar theProgressBar;


	void Start()
	{
		theProgressBar = FindObjectOfType<ProgressBar> ();
	}

	void Update ()
	{ Debug.Log (Time.time);
		//speed = ScrollBackground.speed;
		// Theo thời gian,giá trị của Y sẽ thay đổi từ 0 -> 1 và từ 1 trở về 0. Lặp đi lặp lại
		float y = Mathf.Repeat (Time.time * speed, 1);

		// khoảng cách giá trị sai lệch của trục Y
		Vector2 offset = new Vector2 (0, y);

		// Thiết đặt offset cho Material

		if (theProgressBar.distantToEvent <= 0) {
			GetComponent<Renderer> ().sharedMaterial.SetTextureOffset ("_MainTex", offset);
		}	
	}



}
