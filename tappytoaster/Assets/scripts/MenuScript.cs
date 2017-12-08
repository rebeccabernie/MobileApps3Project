using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    // Handles the Menu page

    #region Startup
    void Start() {
        // When the app starts up run this method once
        // If the player hasn't already set a username, direct them to username page
        if (!PlayerPrefs.HasKey("username")) // No username set
            SceneManager.LoadScene(3); // Load scene 3 - username screen
        
        else { // Otherwise username does exist, don't need to do anything else
            Debug.Log("Start name: " + PlayerPrefs.GetString("username"));
            return;
        }
    }
    #endregion

    #region Menu Options
    // Use this for initialization
    public void playGame() {
        SceneManager.LoadScene(1); // Load the game screen
    }

    #region Disabled Options
    // High scores not yet implemented
    // Code still works fine but page has no purpose so button is currently disabled
    public void highScores() {
        SceneManager.LoadScene(2); // Load the high scores screen
    }
    // Go back to main menu from the high scores page
    public void backToMenu() {
        SceneManager.LoadScene(0);
    }
    #endregion

    #endregion // end all Menu Options region
}