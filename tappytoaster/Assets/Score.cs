using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    static int score = 0;
    static int highScore;
    public Text PlayerScore;
    public static Stopwatch stopWatch = new Stopwatch();

    void Start() {
        stopWatch.Start();
    }


    static public void addScore() {
        score++;

        if (score > highScore)
            highScore = score;
    }

    // Update is called once per frame
    void Update() {
        long duration = stopWatch.ElapsedMilliseconds / 500;
        PlayerScore.text = "" + duration + "\n" + highScore;
    }
}
