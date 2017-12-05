using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public Text score;

    private string scoreStr = "Score: 1";
    private int scoreInt = 1;

	// Use this for initialization
	void Start () {
        score.text = "Score: " + scoreInt;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
