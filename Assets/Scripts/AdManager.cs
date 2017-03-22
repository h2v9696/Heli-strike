using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AdManager : MonoBehaviour {
	public static AdManager Instance{ set; get; }

	public string bannerID;
	public string videoID;

	private void Start () 
	{
		Instance = this;
		DontDestroyOnLoad (gameObject);

		#if UNITY_EDITOR

		#elif UNITY_ANDROID
		Admob.Instance ().initAdmob (bannerID, videoID);
		Admob.Instance().setTesting(true);
		Admob.Instance ().loadInterstitial ();
		#endif
	}

	public void ShowBanner()
	{ 
		#if UNITY_EDITOR
		Debug.Log("Unable to play ads from EDITOR");

		#elif UNITY_ANDROID

		Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.BOTTOM_CENTER, 5);
		#endif

	}

	public void ShowVideo()
	{ 
		Admob.Instance().setTesting(true);
		Admob.Instance ().loadInterstitial ();
		#if UNITY_EDITOR
		Debug.Log("Unable to play ads from EDITOR");
		#elif UNITY_ANDROID
		if (Admob.Instance ().isInterstitialReady ())
		{
		Admob.Instance ().showInterstitial ();
		}
		#endif
	}

	public void RemoveBanner()
	{
		Admob.Instance ().removeBanner ();
	}
}