using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveName : MonoBehaviour {

    // Handles saving username

    public InputField usernameField; // Game object input field
    private string yourName; // String in the input field

    public void OnSubmit() { // When "Save" clicked
        yourName = usernameField.text; // set name variable to whatever's in the input box
        Debug.Log("Name: " + yourName); // testing, just making sure it works
        PlayerPrefs.SetString("username", yourName); // set the player's username in player preferences
        SceneManager.LoadScene(0); // Go back to the main menu
    }
}
