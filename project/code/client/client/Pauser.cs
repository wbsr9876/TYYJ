using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
	private bool paused = false;
	private bool speedUp = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.P)) {
						paused = !paused;
				} else if (Input.GetKeyUp (KeyCode.O)) {
			speedUp=!speedUp;
				}

		if (paused)
						Time.timeScale = 0;
				else if (speedUp)
						Time.timeScale = 2;
				else
						Time.timeScale = 1;
	}
}
