using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSplit : MonoBehaviour {
	public Text textArea;
	public string String;
	//public string[] strings;
	public float speed = 0.1f;

	int characterIndex=0;
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
	}
}