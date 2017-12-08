using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {

    // This class handles the "Space / Tap / Click to Start" prompt displayed at the start of each run
    // Includes first run and after each death

    #region Start - Game Paused
    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().enabled = true; // On start, prompt the user (set enabled to true, makes the sprite visible)
        Time.timeScale = 0; // Pause time
    }
    #endregion

    #region Update - Unpause / Start
    // Update is called once per frame
    void Update () {
        // If currently paused and the user presses spacebar / taps / clicks
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) { // 0 = left mouse key, screen taps also register as mouse clicks
            Time.timeScale = 1; // Un-pause
            GetComponent<SpriteRenderer>().enabled = false; // Disable the sprite, make it invisible
            Score.stopWatch.Start(); // Start the stopwatch for scorekeeping
        }
    }
    #endregion
}
