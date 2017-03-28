using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {
	private PlayerController player;

	void Start () {
		player = FindObjectOfType<PlayerController> ();

	}


	public void Shoot() {
		player.shotMissile ();
		player.numberMissile -= 1;
	}
}
