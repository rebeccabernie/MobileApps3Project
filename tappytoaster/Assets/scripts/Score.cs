using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score = 0;
    static int highScore;
    public Text PlayerScore;
    public static Stopwatch stopWatch = new Stopwatch();

    void Start() {
        stopWatch.Reset();
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    // Update is called once per frame
    void Update() {
        score = ((int)stopWatch.ElapsedMilliseconds) / 500;

        if (score > highScore) {
            highScore = score;
        }

        PlayerScore.text = "" + score + "\n" + highScore;
    }

    public static void OnDeath() {
        PlayerPrefs.SetInt("highScore", highScore);
    }

}
