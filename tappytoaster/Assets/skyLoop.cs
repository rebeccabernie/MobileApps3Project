using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyLoop : MonoBehaviour {

    // Testing, making sure skyLoop collider collides with background sky
	void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log(collider.name + " triggered");

        float skyWidth = ((BoxCollider2D)collider).size.x; // cast the collider to the BoxCollider2D to get size
        Vector3 pos = collider.transform.position;
        pos.x += skyWidth * 4 - skyWidth/2f; // 4 background tiles
        collider.transform.position = pos; // save new position
    }
}
