using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyLoop : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Triggered: " + collider.name);

        float skyWidth = ((BoxCollider2D)collider).size.x; // cast collider to box collider 2d
        Vector3 pos = collider.transform.position;
        pos.x += skyWidth * 6;
        collider.transform.position = pos; // move the first tile to the new position

    }
}
