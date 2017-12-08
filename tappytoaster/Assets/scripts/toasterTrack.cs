using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toasterTrack : MonoBehaviour {

    // This class handles the camera moving with the toaster

    Transform toaster;
    public float offsetX; // Toaster isn't in the middle of the camera, slightly off to left

    #region On Start - Position Toaster
    // Use this for initialization
    void Start () {

        // Find the toaster game object using "Player" tag (set in unity), set toasterObj to that
        GameObject toasterObj = GameObject.FindGameObjectWithTag("Player");

        // If can't find toaster... just for testing purposes
        if (toasterObj == null) {
            Debug.LogError("Could not locate toaster...");
            return;
        }

        toaster = toasterObj.transform; // Get position of toaster
        offsetX = transform.position.x - toaster.position.x; // Offset the toaster a bit
        
	}
    #endregion

    #region Update - Move Toaster / Camera
    // Update is called once per frame
    void Update () {
        if (toaster != null) { // i.e. not dead
            Vector3 pos = transform.position; // Can't directly modify transform.position.x so set pos = position
            pos.x = toaster.position.x + offsetX; // Get pos's position x, set it to toaster's position + offset
            transform.position = pos; // Set that to the new/current position
            // and repeat
        }
    }
    #endregion
}
