using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSplit : MonoBehaviour {
	public Text textArea;
	public string String;
	//public string[] strings;
	public float speed = 0.1f;
	public GameObject storyCanvas;
	public bool finishText = false;
	int characterIndex=0;
	public bool doneStory=false;

	public float delay = 4f;

	float delayTimer;
	//int stringIndex=0;
	void Start()
	{	Time.timeScale = 0;
		StartCoroutine (SplitTimer());

	}

	IEnumerator SplitTimer()
	{while (1 == 1) 
		{	Time.timeScale = 0;
			//yield return new WaitForSeconds (speed);
			yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(speed)); //waitforsecond bi anh huong boi timeScale => lam ham waitforreal ko phu thuoc
		
			if (characterIndex > String.Length) {
				finishText = true;
				continue;
			}
			textArea.text = String.Substring(0,characterIndex);
			characterIndex++;

			//textArea.text = strings [stringIndex].Substring[0,characterIndex];
		}

	}
	void Update()
	{
		
	}


	public void SkipSplit()
	{
		switch (finishText) {

		case false:
			if (characterIndex < String.Length) {
				characterIndex = String.Length;
				finishText = true;

			}
			break;

		case true:
			Destroy (storyCanvas);
			doneStory = true;
			break;
			

		}
	}

	public static class CoroutineUtil
	{
		public static IEnumerator WaitForRealSeconds(float time)
		{
			float start = Time.realtimeSinceStartup;
			while (Time.realtimeSinceStartup < start + time) {
				yield return null;
			}
		}
	}
}