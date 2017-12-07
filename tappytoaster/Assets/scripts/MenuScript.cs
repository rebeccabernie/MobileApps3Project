using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    void Start() {
        Debug.Log("Start name: " + PlayerPrefs.GetString("username"));
        if (PlayerPrefs.HasKey("username") == true)
            return;
        
        else {
            SceneManager.LoadScene(3);
        }
    }

    // Use this for initialization
    public void playGame() {
        SceneManager.LoadScene(1);
    }

    public void highScores() {
        SceneManager.LoadScene(2);
    }

}