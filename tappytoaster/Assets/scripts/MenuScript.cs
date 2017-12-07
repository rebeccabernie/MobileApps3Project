using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    void Start() {
        if (!PlayerPrefs.HasKey("username"))
            SceneManager.LoadScene(3);
        
        else {
            Debug.Log("Start name: " + PlayerPrefs.GetString("username"));
            return;
        }
    }

    // Use this for initialization
    public void playGame() {
        SceneManager.LoadScene(1);
    }

    public void highScores() {
        SceneManager.LoadScene(2);
    }

    public void backToMenu() {
        SceneManager.LoadScene(0);
    }

}