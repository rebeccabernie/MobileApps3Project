using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveName : MonoBehaviour {
    public InputField usernameField;
    private string yourName;

    public void OnSubmit() {
        yourName = usernameField.text;
        Debug.Log("Name: " + yourName);
        PlayerPrefs.SetString("username", yourName);
        SceneManager.LoadScene(0);
    }
}
