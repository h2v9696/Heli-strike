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
	int finishText = 0;
	int characterIndex=0;

	public float delay = 4f;

	float delayTimer;
	//int stringIndex=0;
	void Start()
	{
		StartCoroutine (SplitTimer());
	}

	IEnumerator SplitTimer()
	{while (1 == 1) 
		{
			yield return new WaitForSeconds (speed);
			if (characterIndex > String.Length) {
				continue;
			}
			textArea.text = String.Substring(0,characterIndex);
			characterIndex++;
			//textArea.text = strings [stringIndex].Substring[0,characterIndex];
		}
	}

	public void SkipSplit()
	{if (characterIndex < String.Length)
			characterIndex = String.Length;
		if (characterIndex == String.Length)
			finishText = 1;
	}

	public void finishStory()
	{if(finishText==1)
		delayTimer += Time.deltaTime;

		if (delayTimer >= delay) {
			Destroy (storyCanvas);
		}
	}
}