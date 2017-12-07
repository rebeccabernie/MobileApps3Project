using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {

    static bool sawOnce = false;

	// Use this for initialization
	void Start () {

        if (!sawOnce) {
            GetComponent<SpriteRenderer>().enabled = true;
            Time.timeScale = 0; // Pause
        }

        sawOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { // 0 = left mouse key, screen taps also register as mouse clicks
            Time.timeScale = 1; // Un-pause
            GetComponent<SpriteRenderer>().enabled = false;
            Score.stopWatch.Start();
        }
    }
}
