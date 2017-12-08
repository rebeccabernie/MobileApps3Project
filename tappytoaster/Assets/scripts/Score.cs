using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // This handles scoring / saving scores

    public static int score = 0;
    static int highScore;
    public Text PlayerScore;
    public static Stopwatch stopWatch = new Stopwatch(); // Use stopwatch for easy time elapsed counting

    #region On Start - Reset Time, Get High Score
    void Start() {
        stopWatch.Reset(); // Set the stopwatch to 0
        highScore = PlayerPrefs.GetInt("highScore", 0); // Get the user's current high score, 0 if they've never played before (or never got past 0...)
    }
    #endregion

    #region Score Calculations / Saving
    // Update is called once per frame
    void Update() {
        // Get the current number of ellapsed milliseconds, to get seconds divide by 1000
        // 1000 would give one point per second, bit slow so /500 gives two points per second
        score = ((int)stopWatch.ElapsedMilliseconds) / 500; // Set score to time ellapsed

        if (score > highScore) { // If current score is more than user's existing high score
            highScore = score; // Set the high score to the current score
        }

        // Update the scoreboard on screen
        PlayerScore.text = "" + score + "\n" + highScore;
    }

    public static void OnDeath() {
        // Only need to set a new high score once per game (points aren't taken away, highest score at death)
        PlayerPrefs.SetInt("highScore", highScore); // Set the highscore in player preferences
    }
    #endregion
}
