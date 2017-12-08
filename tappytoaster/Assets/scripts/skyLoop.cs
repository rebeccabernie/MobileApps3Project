using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyLoop : MonoBehaviour {

    // This class loops the sky background

    #region Trigger a Background Tile Movement
    void OnTriggerEnter2D(Collider2D collider) {
        //Debug.Log("Triggered: " + collider.name);

        // Collider is the same width as a panel, get the collider's width and set the background width to that
        float skyWidth = ((BoxCollider2D)collider).size.x; // Cast collider to box collider 2d
        Vector3 pos = collider.transform.position; // set pos to the position of the collider
        pos.x += skyWidth * 6; // new position = width x 6 (6 panels)
        collider.transform.position = pos; // move the first tile to the new position
    }
    #endregion
}
