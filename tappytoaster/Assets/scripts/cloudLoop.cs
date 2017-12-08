using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudLoop : MonoBehaviour {

    // This class handles looping cloud objects

    // Allow random heights for cloud pairs (cloud pairs are top / bottom)
    float cloudMax = 0.6f; // Maximum height a cloud pair can be set to 
    float cloudMin = -0.35f; // Minimum height

    #region On Start - Initial Pos and Random Heights
    void Start() {
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("cloud"); // Find cloud objects

        // Loop through clouds array and set them to random heights on start
        foreach(GameObject cloud in clouds) { // For each pair
            Vector3 pos = cloud.transform.position; // Get the current position
            pos.y = Random.Range(cloudMin, cloudMax); // Set the new position to a random range between min / max set above
            cloud.transform.position = pos; // move the first tile to the new position
        }
    }
    #endregion

    #region Cloud Looping / Random Heights
    void OnTriggerEnter2D(Collider2D collider) {
        // Handles looping of clouds
        Debug.Log("Triggered: " + collider.name);

        float cloudWidth = ((BoxCollider2D)collider).size.x; // cast collider to box collider 2d
        Vector3 pos = collider.transform.position; // Get the current position
        pos.x += cloudWidth * 6; // 6 tiles of clouds, set new position to 6 tiles forward

        // If the collider is a cloud (only moves clouds, not sky etc), change its height
        if (collider.tag == "cloud") {
            pos.y = Random.Range(cloudMin, cloudMax);
        }

        // Perform transformation - move first tile to the new position at a random height
        collider.transform.position = pos;
    }
    #endregion
}
