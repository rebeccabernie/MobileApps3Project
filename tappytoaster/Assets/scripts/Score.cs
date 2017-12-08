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

    void Start() {
        stopWatch.Reset(); // Set the stopwatch to 0
        highScore = PlayerPrefs.GetInt("highScore", 0); // Get the user's current high score, 0 if they've never played before (or never got past 0...)
    }

    #region Score Calculations / Saving
    // Update is called once per frame
    void Update() {
        // Get the current number of ellapsed milliseconds, to get seconds divide by 1000
        // 1000 would give one point per second, bit slow so /500 gives two points per second
        score = ((int)stopWatch.ElapsedMilliseconds) / 500; // Set score to time ellapsed

        if (score > highScore) {
            highScore = score;
        }

        PlayerScore.text = "" + score + "\n" + highScore;
    }

    public static void OnDeath() {
        PlayerPrefs.SetInt("highScore", highScore);
    }
    #endregion
}
