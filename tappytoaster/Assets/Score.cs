using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    static int score = 3;
    static int highScore = 15;
    public Text PlayerScore;

    static public void addScore() {
        score++;

        if (score > highScore)
            highScore = score;
    }

    // Update is called once per frame
    void Update() {
        PlayerScore.text = "SCORE: " + score + "\nBEST: " + highScore;
    }
}
